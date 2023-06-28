using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Services.Contracts;
using Npgsql;

namespace BoardApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly NpgsqlConnection _conn;
        public UserService(IConfiguration configuration)
        {
            _conn = new NpgsqlConnection(configuration["DB_CONN"]);
        }
        public async Task<OperationResult> CreateUser(CreateUserDTO dto)
        {
            await _conn.OpenAsync();

            var ifExistsScr = $"SELECT EXISTS (SELECT 1 FROM Users WHERE Username = '{dto.Username}')";

            using var cmd = new NpgsqlCommand(ifExistsScr, _conn);
            if ((bool) (await cmd.ExecuteScalarAsync())!)
            {
                await _conn.CloseAsync();
                return new OperationResult(new AlreadyExistsException("Username taken"));
            }

            var id = Guid.NewGuid();
            var scrInsert = $"INSERT INTO Users(Id, Username, Password) VALUES ('{id}', '{dto.Username}', '{dto.Password}')";

            using var cmdInsert = new NpgsqlCommand(scrInsert, _conn);
            var rowsAffected = await cmdInsert.ExecuteNonQueryAsync();

            if (rowsAffected < 1)
            {
                await _conn.CloseAsync();
                return new OperationResult(new DbFailureException("Db shitted"));
            }

            await _conn.CloseAsync();

            return new OperationResult();
        }

        public async Task<OperationResult> EditUser(Guid userId, EditUserDTO dto)
        {
            await _conn.OpenAsync();

            var ifExistsScr = $"SELECT EXISTS (SELECT 1 FROM Users WHERE Id = '{userId}')";
            using var cmdExists = new NpgsqlCommand(ifExistsScr, _conn);

            if (!(bool) (await cmdExists.ExecuteScalarAsync())!) 
            {
                await _conn.CloseAsync();
                return new OperationResult(new NotFoundException($"User '{userId}' does not exist"));
            }

            var srcIsNameTaken = $"SELECT EXISTS (SELECT 1 FROM Users WHERE Username = '{dto.Username}')";
            using var cmdNameTaken = new NpgsqlCommand(srcIsNameTaken, _conn);

            if ((bool) (await cmdNameTaken.ExecuteScalarAsync())!)
            {
                await _conn.CloseAsync();
                return new OperationResult(new AlreadyExistsException($"Username '{dto.Username}' already taken"));
            }

            var srcUpdate = $"UPDATE Users SET Username = '{dto.Username}' WHERE Id = '{userId}'";
            using var cmdUpdate = new NpgsqlCommand(srcUpdate, _conn);

            var affectedRows = await cmdUpdate.ExecuteNonQueryAsync();
            if (affectedRows < 1)
            {
                await _conn.CloseAsync();
                return new OperationResult(new DbFailureException("DB had a prolapsus"));
            }

            await _conn.CloseAsync();

            return new OperationResult();
        }

        public async Task<OperationResult<UserDTO>> GetUser(Guid userId)
        {
            await _conn.OpenAsync();

            var src = "SELECT " +
                    "u.Id AS UserId, u.Username AS Username, " +
                    "b.Id AS BoardId, b.IsPrivate as IsPrivate, " +
                    "b.Name AS Boardname, b.AuthorId as CreatorId " +
                "FROM Users u " +
                "LEFT JOIN BoardMembers bm ON u.Id = bm.UserId " +
                "LEFT JOIN Boards b ON bm.BoardId = b.Id " +
                $"WHERE u.Id = '{userId}'";

            Console.WriteLine(src);

            var cmd = new NpgsqlCommand(src, _conn);
            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
            {
                await _conn.CloseAsync();
                return new OperationResult<UserDTO>(new NotFoundException($"User '{userId}' does not exist"));
            }


            var response = new UserDTO
            {
                Id = Guid.Parse(reader["UserId"].ToString()!),
                Username = reader["Username"].ToString()!,
                Boards = new List<BoardShortDTO>()
            };

            var boardId = reader["BoardId"];

            while (!(reader["BoardId"].GetType() == typeof(DBNull) || reader["Boardname"].GetType() == typeof(DBNull)))
            {
                response.Boards.Add(new BoardShortDTO
                {
                    Id = Guid.Parse(reader["BoardId"].ToString()!),
                    Name = reader["Boardname"].ToString()!,
                    IsPrivate = (bool)reader["IsPrivate"],
                    CreatorId = Guid.Parse(reader["CreatorId"].ToString()!),
                });

                if (!await reader.ReadAsync())
                {
                    break;
                }
            }

            return new OperationResult<UserDTO>(response);
        }

        public async Task<OperationResult<List<UserShortDTO>>> GetUsers()
        {
            return await GetUsersFromQuery("SELECT Id, Username FROM Users");
        }

        public async Task<OperationResult<List<UserShortDTO>>> GetUsersNotInBoard(Guid boardId)
        {
            return await GetUsersFromQuery($"SELECT u.Id, u.Username " +
                $"FROM Users u " +
                $"WHERE NOT EXISTS (" +
                $"SELECT 1 FROM BoardMembers bm WHERE bm.UserId = u.Id AND bm.BoardId = '{boardId}'" +
            $")");
        }

        private async Task<OperationResult<List<UserShortDTO>>> GetUsersFromQuery(string query)
        {
            await _conn.OpenAsync();

            var cmd = new NpgsqlCommand(query, _conn);
            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                await _conn.CloseAsync();
                return new OperationResult<List<UserShortDTO>>(new List<UserShortDTO>());
            }

            var result = new List<UserShortDTO>();
            while (await reader.ReadAsync())
            {
                result.Add(new UserShortDTO
                {
                    Id = Guid.Parse(reader["Id"].ToString()!),
                    Username = reader["Username"].ToString()!
                });
            }

            await _conn.CloseAsync();
            return new OperationResult<List<UserShortDTO>>(result);
        }
    }
}
