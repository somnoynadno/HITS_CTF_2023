using CtfReverseBackend.DAL;
using CtfReverseBackend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CtfReverseBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
        private static readonly Random random = new();
        public HomeController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginCredentials credentials)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Login == credentials.Username && x.Password == credentials.Password)
                ?? throw new BadHttpRequestException("Invalid credentials");

            return new string(Enumerable.Repeat(alphabet, 300)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet("flag")]
        public string Flag()
        {
            return _configuration["ASPNETCORE_FLAG"] ?? "HITS{no_flag_xdddd}";
        }
    }
}
