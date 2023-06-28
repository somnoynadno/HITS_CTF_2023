using Npgsql;

namespace BoardApp.DB
{
    public static class InitializeDbExtension
    {
        public static async Task InitializeDb(this WebApplication app, string cs)
        {
            using var conn = new NpgsqlConnection(cs);

            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand(
                await new FileInfo("./DAL/SQL/Init.sql").OpenText().ReadToEndAsync(),
                conn
            ))
            {
                await cmd.ExecuteNonQueryAsync();
            }


            await using (var cmdSeed = new NpgsqlCommand(
                await new FileInfo("./DAL/SQL/seeddata.sql").OpenText().ReadToEndAsync(),
                conn
            ))
            {
                await cmdSeed.ExecuteNonQueryAsync();
            };


            await using (var cmdFlag = new NpgsqlCommand(
                $"UPDATE public.messages SET Content = '{app.Configuration["CTF_FLAG"]}' WHERE Id = 'c86c8e64-6942-4703-9932-58b2fa8dbcac'",
                conn
            ))
            {
                await cmdFlag.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }
    }
}
