using Npgsql;
using SimpLog.Databases.PostgreSQL.Entities;
using SimpLog.Databases.PostgreSQL.Models;
using SimpLog.Databases.PostgreSQL.Models.AppSettings;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Services.DatabaseServices
{
    internal class DatabaseServices
    {
        public static Configuration conf = ConfigurationServices.ConfigService.BindConfigObject();

        private const string insertQuery = @"
                INSERT INTO ""StoreLog""(
                    ""Log_Type"", 
                    ""Log_Error"", 
                    ""Log_Created"", 
                    ""Log_FileName"", 
                    ""Log_Path"", 
                    ""Log_SendEmail"", 
                    ""Email_ID"", 
                    ""Saved_In_Database""
                ) VALUES(
                    @Log_Type, 
                    @Log_Error, 
                    @Log_Created, 
                    @Log_FileName, 
                    @Log_Path, 
                    @Log_SendEmail, 
                    @Email_ID, 
                    @Saved_In_Database
                );";

        /// <summary>
        /// Call this once at application startup to ensure DB and table exist
        /// </summary>
        public static async Task InitializeDatabase()
        {
            using var connection = new NpgsqlConnection(conf.Database_Configuration.Connection_String);
            await connection.OpenAsync();
            await DatabaseMigrations.CreatePostgreSqlIfNotExists(connection);
        }

        /// <summary>
        /// Depending on the name of the DB, goes to the function for that stuff.
        /// </summary>
        /// <param name="storeLog"></param>
        public static Task SaveIntoDatabase(StoreLog storeLog)
            => InsertIntoPostgreSql(storeLog);

        /// <summary>
        /// Insert log into PostgreSql database.
        /// </summary>
        /// <param name="storeLog"></param>
        /// <param name="isEmailSend"></param>
        public static async Task InsertIntoPostgreSql(StoreLog storeLog)
        {
            await using var connection = new NpgsqlConnection(conf.Database_Configuration.Connection_String);

            await connection.OpenAsync();

            await DatabaseMigrations.CreatePostgreSqlIfNotExists(connection);

            await using var command = new NpgsqlCommand(insertQuery, connection);

            command.Parameters.Add("@Log_Type", NpgsqlTypes.NpgsqlDbType.Char, 50).Value = storeLog.Log_Type;
            command.Parameters.Add("@Log_Error", NpgsqlTypes.NpgsqlDbType.Varchar).Value = storeLog.Log_Error;
            command.Parameters.Add("@Log_Created", NpgsqlTypes.NpgsqlDbType.Varchar).Value = storeLog.Log_Created;
            command.Parameters.Add("@Log_FileName", NpgsqlTypes.NpgsqlDbType.Varchar, 255).Value = storeLog.Log_FileName ?? (object)DBNull.Value;
            command.Parameters.Add("@Log_Path", NpgsqlTypes.NpgsqlDbType.Varchar, 500).Value = storeLog.Log_Path ?? (object)DBNull.Value;
            command.Parameters.Add("@Log_SendEmail", NpgsqlTypes.NpgsqlDbType.Boolean).Value = storeLog.Log_SendEmail ?? false;
            command.Parameters.Add("@Email_ID", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0;
            command.Parameters.Add("@Saved_In_Database", NpgsqlTypes.NpgsqlDbType.Boolean).Value = storeLog.Saved_In_Database ?? true;

            await command.ExecuteNonQueryAsync();
        }
    }
}
