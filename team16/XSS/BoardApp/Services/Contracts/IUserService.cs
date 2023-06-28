using BoardApp.Models.DTO;

namespace BoardApp.Services.Contracts
{
    public interface IUserService
    {
        Task<OperationResult<UserDTO>> GetUser(Guid userId);
        Task<OperationResult<List<UserShortDTO>>> GetUsersNotInBoard(Guid boardId);
        Task<OperationResult> CreateUser(CreateUserDTO dto);
        Task<OperationResult> EditUser(Guid userId, EditUserDTO dto);
        Task<OperationResult<List<UserShortDTO>>> GetUsers();
    }
}
