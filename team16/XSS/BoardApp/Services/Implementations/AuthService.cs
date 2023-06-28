using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Services.Contracts;
using FeastHub.Common.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Npgsql;
using System.Security.Authentication;
using System.Security.Claims;

namespace BoardApp.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly NpgsqlConnection _conn;
        public AuthService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _conn = new NpgsqlConnection(configuration["DB_CONN"]); // TODO: засунуть строку подключения в переменные четверга
        }
        public async Task<OperationResult<ClaimsPrincipal>> Login(LoginDTO dto)
        {
            await _conn.OpenAsync();

            var scr = $"SELECT Id FROM Users WHERE Username = '{dto.Username}' AND Password = '{dto.Password}'";
            using var cmd = new NpgsqlCommand(scr, _conn);

            var id = await cmd.ExecuteScalarAsync();

            if (id is null)
            {
                await _conn.CloseAsync();
                return new OperationResult<ClaimsPrincipal>(new InvalidCredentialException($"Invalid credentials"));
            }

            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, id.ToString()!)
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            return new OperationResult<ClaimsPrincipal>(new ClaimsPrincipal(identity));
        }

        public async Task<OperationResult<ClaimsPrincipal>> Register(CreateUserDTO dto)
        {
            if (!dto.Password.Equals(dto.RepeatPassword))
            {
                return new OperationResult<ClaimsPrincipal>(new InvalidCredentialException("Passwords are not equal"));
            }

            var result = await _userService.CreateUser(dto);
            
            if (result.IsFailed)
            {
                return new OperationResult<ClaimsPrincipal>(result.Exception!);
            }

            return await Login(new LoginDTO { Username = dto.Username, Password = dto.Password });
        }
    }
}
