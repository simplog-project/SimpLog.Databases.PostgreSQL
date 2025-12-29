using Npgsql;
using SimpLog.Databases.PostgreSQL.Models.AppSettings;
using System.Text;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Services.DatabaseServices
{
    internal class DatabaseMigrations
    {
        public static Configuration conf = ConfigurationServices.ConfigService.BindConfigObject();

        /// <summary>
        /// Create PostgreSql tables if not exists
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmd"></param>
        public static async Task CreatePostgreSqlIfNotExists(NpgsqlConnection connection)
        {
            StringBuilder query = new StringBuilder();
            query.Append($" create table if not exists StoreLog ");
            query.Append($"    ( ");
            query.Append($"    \"{"ID"}\" serial ");
            query.Append($"   ,\"{"Log_Type"}\" varchar(50) ");
            query.Append($"   ,\"{"Log_Error"}\" varchar(50) ");
            query.Append($"   ,\"{"Log_Created"}\" varchar(50) ");
            query.Append($"   ,\"{"Log_FileName"}\" varchar(50) ");
            query.Append($"   ,\"{"Log_Path"}\" varchar(50) ");
            query.Append($"   ,\"{"Log_SendEmail"}\" boolean ");
            query.Append($"   ,\"{"Email_ID"}\" int ");
            query.Append($"   ,\"{"Saved_In_Database"}\" varchar(50) ");
            query.Append($"    ); ");

            query.Append($" create table if not exists EmailLog ");
            query.Append($"    ( ");
            query.Append($"    \"{"ID"}\" serial ");
            query.Append($"   ,\"{"From_Email"}\" varchar(50) ");
            query.Append($"   ,\"{"To_Email"}\" varchar(50) ");
            query.Append($"   ,\"{"Bcc"}\" varchar(50) ");
            query.Append($"   ,\"{"Email_Subject"}\" varchar(50) ");
            query.Append($"   ,\"{"Email_Body"}\" varchar(50) ");
            query.Append($"   ,\"{"Time_Sent"}\" varchar(50) ");
            query.Append($"    ); ");

            using var cmd = new NpgsqlCommand(query.ToString(), connection);

            if (connection.State != System.Data.ConnectionState.Open)
                await connection.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
