using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Models.AppSettings
{
    internal class Configuration
    {
        [JsonPropertyName("Database_Configuration")]
        public DatabaseConfiguration? Database_Configuration { get; set; }
        
        [JsonPropertyName("LogType")]
        public Log? LogType { get; set; }
    }
}
