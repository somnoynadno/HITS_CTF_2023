using BoardApp.Models.Exceptions;
using Npgsql;

namespace BoardApp.Other.Utilities
{
    public static class SqlQueryUtilities
    {
        public static async Task<OperationResult> EnsureQueryExecuted(NpgsqlConnection conn, string query)
        {
            if (conn.FullState == System.Data.ConnectionState.Closed) await conn.OpenAsync();
            using var cmd = new NpgsqlCommand(query, conn);

            var affectedRows = await cmd.ExecuteNonQueryAsync();

            if (affectedRows < 1)
            {

                return new OperationResult(new DbFailureException("DB had a prolapsus"));
            }

            return new OperationResult();
        }
    }
}
