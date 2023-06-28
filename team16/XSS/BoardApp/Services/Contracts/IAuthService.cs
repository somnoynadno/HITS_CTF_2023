using BoardApp.Models.DTO;
using System.Security.Claims;

namespace BoardApp.Services.Contracts
{
    public interface IAuthService
    {
        Task<OperationResult<ClaimsPrincipal>> Register(CreateUserDTO dto);
        Task<OperationResult<ClaimsPrincipal>> Login(LoginDTO dto);
    }
}
