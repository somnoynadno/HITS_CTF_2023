using BoardApp.Models.DTO;

namespace BoardApp.Services.Contracts
{
    public interface IMessageService
    {
        Task<OperationResult> SendMessage(Guid boardId, CreateMessageDTO dto, Guid initiatorId);
        Task<OperationResult> EditMessage(Guid messageId, EditMessageDTO dto, Guid initiatorId);
        Task<OperationResult> DeleteMessage(Guid messageId, Guid initiatorId);

    }
}
