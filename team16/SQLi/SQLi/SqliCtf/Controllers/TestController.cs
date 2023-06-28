using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SqliCtf.DTO;

namespace SqliCtf.Controllers
{
    [ApiController]
    [Route("users")]
    public class TestController : ControllerBase
    {
        private readonly string _cs;
        private readonly NpgsqlConnection _conn;
        public TestController(IConfiguration configuration)
        {
            _cs = configuration["ASPNETCORE_DEFAULT_CONN"]!;
            _conn = new NpgsqlConnection(_cs);
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteSql(string orderBy = "Username")
        {
            await _conn.OpenAsync();

            var scr = $"SELECT * FROM Users ORDER BY {orderBy}";
            var cmd = new NpgsqlCommand(scr, _conn);
            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                return Ok("Deadass bruh");
            }

            var names = new List<string>();

            for (var i = 0; i < reader.FieldCount; i++) {
                names.Add(reader.GetName(i));
            }

            var response = new List<UserDto>();

            while(reader.Read())
            {
                response.Add(new UserDto
                {
                    Id = Guid.Parse(reader["id"].ToString()!),
                    Name = reader["Username"].ToString()!,
                    Age = int.Parse(reader["Age"].ToString()!)
                });
            }

            await _conn.CloseAsync();

            return Ok(response);
        }
    }
}
