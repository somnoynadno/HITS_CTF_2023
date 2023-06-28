using Npgsql;

namespace SqliCtf.Extensions
{
    public static class InitializeDbExtension
    {
        private static async Task ExecuteScript(string connectionString, string scriptPath)
        {
            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var script = new FileInfo(scriptPath)
                .OpenText()
                .ReadToEnd();

            using var cmd = new NpgsqlCommand(script, connection);
            await cmd.ExecuteNonQueryAsync();

        }
        public static async Task<WebApplication> InitDb(this WebApplication app)
        {
            await ExecuteScript(app.Configuration["ASPNETCORE_INIT_CONN"]!, "./Sql/createDb.sql");
            await ExecuteScript(app.Configuration["ASPNETCORE_DEFAULT_CONN"]!, "./Sql/createTables.sql");

            using var connection = new NpgsqlConnection(app.Configuration["ASPNETCORE_DEFAULT_CONN"]!);
            await connection.OpenAsync();
            using var cmd = new NpgsqlCommand(
                $"insert into ChatMessages(Id, ChatId, AuthorId, Value) values (gen_random_uuid(), '5069fae4-619d-4466-8d0d-05d6d4fcaa2d', '53b7aead-1aaf-422b-a8ac-5befe13210ba', '{app.Configuration["FLAG"]}')",
                connection
                );

            await cmd.ExecuteNonQueryAsync();

            return app;
        }
    }
}
