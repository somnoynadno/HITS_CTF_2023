using BoardApp.Models.DTO;

namespace BoardApp.Services.Contracts
{
    public interface IBoardService
    {
        Task<OperationResult<BoardShortDTO>> AccessBoard(Guid boardId);
        Task<OperationResult<List<BoardShortDTO>>> GetBoards(string? name = default);
        Task<OperationResult<BoardDTO>> GetBoard(Guid boardId, Guid userId);
        Task<OperationResult<BoardDTO>> CreateBoard(CreateBoardDTO dto, Guid initiatorId);
        Task<OperationResult> EditBoard(Guid boardId, EditBoardDTO dto, Guid initiatorId);
        Task<OperationResult> DeleteBoard(Guid boardId, Guid initiatorId);
        Task<OperationResult> EnterBoard(Guid boardId, Guid userId);
        Task<OperationResult> AddMember(Guid boardId, Guid userId, Guid initiatorId);
        Task<OperationResult> RemoveMember(Guid boardId, Guid userId, Guid initiatorId);
    }
}
