using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Services.Contracts;
using BoardApp.Other.Utilities;
using Npgsql;

namespace BoardApp.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly NpgsqlConnection _conn;
        public MessageService(IConfiguration configuration)
        {
            _conn = new NpgsqlConnection(configuration["DB_CONN"]);
        }
        public async Task<OperationResult> DeleteMessage(Guid messageId, Guid initiatorId)
        {
            var msgResult = await AccessMessage(messageId, initiatorId);
            if (msgResult.IsFailed)
            {
                return msgResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"DELETE FROM Messages WHERE Id = '{messageId}'");
        }

        public async Task<OperationResult> EditMessage(Guid messageId, EditMessageDTO dto, Guid initiatorId)
        {
            var msgResult = await AccessMessage(messageId, initiatorId);
            if (msgResult.IsFailed)
            {
                return msgResult;
            }

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"UPDATE Messages SET Content = {dto.Content} WHERE Id = '{messageId}'");
        }

        public async Task<OperationResult> SendMessage(Guid boardId, CreateMessageDTO dto, Guid initiatorId)
        {
            var scrIsMember = $"SELECT EXISTS (SELECT 1 FROM BoardMembers WHERE BoardId = '{boardId}' AND UserId = '{initiatorId}')";
            using var cmdIsMemeber = new NpgsqlCommand(scrIsMember, _conn);

            await _conn.OpenAsync();
            if (!(bool) (await cmdIsMemeber.ExecuteScalarAsync())!)
            {
                await _conn.CloseAsync();
                return new OperationResult(new AccessDeniedException($"You are not a member of board '{boardId}'"));
            }

            await _conn.CloseAsync();

            return await SqlQueryUtilities.EnsureQueryExecuted(_conn, $"INSERT INTO Messages (Id, AuthorId, BoardId, Content) VALUES (gen_random_uuid(), '{initiatorId}', '{boardId}', '{dto.Content}')");
        }

        private async Task<OperationResult> AccessMessage(Guid messageId, Guid userId)
        {
            await _conn.OpenAsync();

            var scr = $"SELECT m.AuthorId AS MessageAuthorId, m.BoardId AS BoardId " +
                $"FROM Messages m " +
                $"WHERE m.Id = '{messageId}'";

            using var cmd = new NpgsqlCommand(scr, _conn);
            var reader = await cmd.ExecuteReaderAsync();

            if (! await reader.ReadAsync())
            {
                await _conn.CloseAsync();
                return new OperationResult(new NotFoundException($"Message '{messageId}' does not exist"));
            }

            var authorId = new Guid(reader["MessageAuthorId"].ToString()!);
            var boardId = new Guid(reader["BoardId"].ToString()!);

            await reader.CloseAsync();

            var scrBoardCreator = $"SELECT b.AuthorId " +
                $"FROM Boards b " +
                $"WHERE b.Id = '{boardId}'";

            using var cmdBoardCreator = new NpgsqlCommand(scrBoardCreator, _conn);
            var boardCreator = await cmdBoardCreator.ExecuteScalarAsync();

            if (boardCreator is null)
            {
                await _conn.CloseAsync();
                return new OperationResult(new NotFoundException($"ayo wtf message exists but has no board??"));
            }

            if (authorId != userId && new Guid(boardCreator.ToString()!) != userId)
            {
                await _conn.CloseAsync();
                return new OperationResult(new AccessDeniedException($"You are either not the author of the message '{messageId}', or not the author of the board, you stupid fucking n-"));
            }

            await _conn.CloseAsync();
            return new OperationResult();
        }
    }
}
