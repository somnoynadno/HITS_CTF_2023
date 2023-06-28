using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Other.Utilities;
using BoardApp.Services.Contracts;
using Npgsql;

namespace BoardApp.Services.Implementations
{
    public class BoardService : IBoardService, IAsyncDisposable
    {
        private readonly NpgsqlConnection _conn;

        public BoardService(IConfiguration configuration)
        {
            _conn = new NpgsqlConnection(configuration["ASPNETCORE_DB_CONN"]);
        }
        public async Task<OperationResult> EnterBoard(Guid boardId, Guid userId)
        {
            var result = await AccessBoard(boardId);

            if (result.IsFailed)
            {
                return result;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"INSERT INTO BoardMembers (BoardId, UserId) VALUES ('{boardId}', '{userId}')");
        }

        public async Task<OperationResult> AddMember(Guid boardId, Guid userId, Guid initiatorId)
        {
            var boardResult = await AccessBoardAsCreator(boardId, initiatorId);

            if (boardResult.IsFailed)
            {
                return boardResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"INSERT INTO BoardMembers (BoardId, UserId) VALUES ('{boardId}', '{userId}')");
        }

        public async Task<OperationResult> RemoveMember(Guid boardId, Guid userId, Guid initiatorId)
        {
            var boardResult = await AccessBoardAsCreator(boardId, initiatorId);

            if (boardResult.IsFailed)
            {
                return boardResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"DELETE FROM BoardMembers bm " +
                $"WHERE bm.BoardId = '{boardId}' AND bm.UserId = '{userId}'");
        }

        public async Task<OperationResult<BoardDTO>> CreateBoard(CreateBoardDTO dto, Guid initiatorId)
        {
            var nameTakenResult = await BoardNameIsTaken(dto.Name, Guid.Empty);
            if (nameTakenResult.IsFailed)
            {
                return new OperationResult<BoardDTO>(nameTakenResult.Exception!);
            }

            var boardId = Guid.NewGuid();
            var boardResult = await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"INSERT INTO Boards (Id, Name, AuthorId, IsPrivate) VALUES ('{boardId}', '{dto.Name}', '{initiatorId}', {dto.IsPrivate})");

            if (boardResult.IsFailed)
            {
                return new OperationResult<BoardDTO>(boardResult.Exception!);
            }

            var createResult = await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"INSERT INTO BoardMembers (BoardId, UserId) VALUES ('{boardId}', '{initiatorId}')");

            if (createResult.IsFailed)
            {
                return new OperationResult<BoardDTO>(createResult.Exception!);
            }

            return await GetBoard(boardId, initiatorId);
        }

        public async Task<OperationResult> DeleteBoard(Guid boardId, Guid initiatorId)
        {
            var boardResult = await AccessBoardAsCreator(boardId, initiatorId);

            if (boardResult.IsFailed)
            {
                return boardResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"DELETE FROM Boards WHERE Id = '{boardId}'");
        }

        public async Task<OperationResult> EditBoard(Guid boardId, EditBoardDTO dto, Guid initiatorId)
        {
            if (dto.Name is not null)
            {
                var nameTakenResult = await BoardNameIsTaken(dto.Name, boardId);
                if (nameTakenResult.IsFailed)
                {
                    return new OperationResult<BoardDTO>(nameTakenResult.Exception!);
                }
            }

            var boardResult = await AccessBoardAsCreator(boardId, initiatorId);

            if (boardResult.IsFailed)
            {
                return boardResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"UPDATE Boards SET Name = '{dto.Name}', IsPrivate = {dto.IsPrivate} WHERE Id = '{boardId}'");
        }

        public async Task<OperationResult<BoardDTO>> GetBoard(Guid boardId, Guid userId)
        {
            var boardResult = await AccessBoardAsMember(boardId, userId);
            if (boardResult.IsFailed)
            {
                return new OperationResult<BoardDTO>(boardResult.Exception!);
            }

            //await _conn.OpenAsync();

            var srcBoard = $"SELECT b.Id AS BoardId, b.Name AS BoardName, " +
                $"b.IsPrivate AS IsPrivate, b.AuthorId AS BoardAuthorId, " +

                $"u.Id AS UserId, u.Username AS Username " +
                $"FROM Boards b " +
                $"INNER JOIN BoardMembers bm ON b.Id = bm.BoardId " +
                $"INNER JOIN Users u ON bm.UserId = u.Id " +
                $"WHERE b.Id = '{boardId}'";

            var srcMessages = $"SELECT u.Id AS UserId, u.Username AS Username, " +
                $"m.Id AS MessageId, m.Content AS Content " +
                $"FROM Messages m " +
                $"INNER JOIN Users u ON m.AuthorId = u.Id " +
                $"WHERE m.BoardId = '{boardId}'";

            BoardDTO response;
            //Console.WriteLine(src);
            await using (var cmdBoard = new NpgsqlCommand(srcBoard, _conn))
            {
                var reader = await cmdBoard.ExecuteReaderAsync();

                await reader.ReadAsync();

                var boardAuthorId = Guid.Parse(reader["BoardAuthorId"].ToString()!);
                response = new BoardDTO
                {
                    Id = Guid.Parse(reader["BoardId"].ToString()!),
                    Name = reader["BoardName"].ToString()!,
                    IsPrivate = (bool)reader["IsPrivate"],
                    Messages = new List<MessageDTO>(),
                    Creator = new UserShortDTO
                    {
                        Id = boardAuthorId
                    },
                    Members = new List<UserShortDTO>()
                };

                do
                {
                    var boardUserId = Guid.Parse(reader["UserId"].ToString()!);
                    var username = reader["Username"].ToString()!;

                    response.Members.Add(new UserShortDTO
                    {
                        Id = boardUserId,
                        Username = username
                    });

                    if (boardUserId == boardAuthorId)
                    {
                        response.Creator.Username = username;
                    }

                } while (await reader.ReadAsync());
                await reader.CloseAsync();
            }

            await using (var cmdMessages = new NpgsqlCommand(srcMessages, _conn))
            {
                var reader = await cmdMessages.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {

                    response.Messages.Add(new MessageDTO
                    {
                        Id = Guid.Parse(reader["MessageId"].ToString()!),
                        Author = new UserShortDTO
                        {
                            Id = Guid.Parse(reader["UserId"].ToString()!),
                            Username = reader["Username"].ToString()!
                        },
                        Content = reader["Content"].ToString()!
                    });
                }
                await reader.CloseAsync();
            }
            return new OperationResult<BoardDTO>(response);
        }

        public async Task<OperationResult<List<BoardShortDTO>>> GetBoards(string? name = default)
        {
            await _conn.OpenAsync();

            var src = $"SELECT Id, Name, IsPrivate, AuthorId FROM Boards";
            using var cmd = new NpgsqlCommand(src, _conn);

            var reader = await cmd.ExecuteReaderAsync();

            var response = new List<BoardShortDTO>();

            while (await reader.ReadAsync())
            {
                Guid boardId = new ();
                var isBoardIdParsed = Guid.TryParse(reader["Id"].ToString(), out boardId);

                Guid creatorId = new();
                var isCreatorIdParsed = Guid.TryParse(reader["AuthorId"].ToString(), out creatorId);

                response.Add(new BoardShortDTO
                {
                    Id = isBoardIdParsed ? boardId : new Guid(),
                    Name = reader["Name"].ToString()!,
                    IsPrivate = (bool)reader["IsPrivate"],
                    CreatorId = isCreatorIdParsed ? creatorId : new Guid()
                });
            }
            await reader.CloseAsync();

            return new OperationResult<List<BoardShortDTO>>(response);
        }

        private async Task<OperationResult> AccessBoardAsCreator(Guid boardId, Guid authorId)
        {
            if (_conn.FullState == System.Data.ConnectionState.Closed) await _conn.OpenAsync();

            var src = $"SELECT Id, AuthorId FROM Boards WHERE Id = '{boardId}'";
            using var cmd = new NpgsqlCommand(src, _conn);

            var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await reader.CloseAsync();
                return new OperationResult(new NotFoundException($"Board '{boardId}' does not exist"));
            }

            if (Guid.Parse(reader["AuthorId"].ToString()!) != authorId)
            {
                await reader.CloseAsync();
                return new OperationResult(new AccessDeniedException($"You are not the author of the '{boardId}' board"));
            }
            await reader.CloseAsync();

            return new OperationResult();
        }

        public async Task<OperationResult<BoardShortDTO>> AccessBoard(Guid boardId)
        {
            if (_conn.FullState == System.Data.ConnectionState.Closed) await _conn.OpenAsync();

            var src = $"SELECT Name, IsPrivate, AuthorId " +
                $"FROM Boards b " +
                $"WHERE Id = '{boardId}'";

            using var cmd = new NpgsqlCommand(src, _conn);

            var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await reader.CloseAsync();
                return new OperationResult<BoardShortDTO>(new NotFoundException($"Board '{boardId}' does not exist"));
            }

            if ((bool)reader["IsPrivate"])
            {
                await reader.CloseAsync();
                return new OperationResult<BoardShortDTO>(new AccessDeniedException($"You do not have enough rights to access this resource"));
            }

            var result = new BoardShortDTO
            {
                CreatorId = new Guid(reader["AuthorId"].ToString()!),
                Id = boardId,
                IsPrivate = (bool)reader["IsPrivate"],
                Name = reader["Name"].ToString()!
            };
            await reader.CloseAsync();

            return new OperationResult<BoardShortDTO>(result);
        }

        private async Task<OperationResult> AccessBoardAsMember(Guid boardId, Guid memberId)
        {
            if (_conn.FullState == System.Data.ConnectionState.Closed) await _conn.OpenAsync();

            var src = $"SELECT BoardId, UserId " +
                $"FROM BoardMembers " +
                $"WHERE BoardId = '{boardId}'";

            using var cmd = new NpgsqlCommand(src, _conn);

            var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await reader.CloseAsync();
                return new OperationResult(new NotFoundException($"Board '{boardId}' does not exist"));
            }

            do
            {
                if (Guid.Parse(reader["UserId"].ToString()!) == memberId)
                {
                    await reader.CloseAsync();
                    return new OperationResult();
                }
            }
            while (await reader.ReadAsync());
            await reader.CloseAsync();


            return new OperationResult(new AccessDeniedException($"You're not a member of '{boardId}' board"));
        }
        private async Task<OperationResult> BoardNameIsTaken(string name, Guid boardId)
        {
            if (_conn.FullState == System.Data.ConnectionState.Closed) await _conn.OpenAsync();

            var scrExists = $"SELECT EXISTS (SELECT 1 FROM Boards WHERE Name = '{name}' AND Id != '{boardId}')";
            using var cmdExists = new NpgsqlCommand(scrExists, _conn);

            if ((bool)(await cmdExists.ExecuteScalarAsync())!)
            {
                return new OperationResult(new AlreadyExistsException($"Boardname '{name}' is already taken"));
            }

            return new OperationResult();
        }
        public async ValueTask DisposeAsync()
        {
            await _conn.CloseAsync();
            await _conn.DisposeAsync();
        }
    }
}
