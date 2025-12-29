using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Models.AppSettings
{
    internal class Log
    {
        [JsonPropertyName("Trace")]
        public LogTypeObject? Trace { get; set; }

        [JsonPropertyName("Debug")]
        public LogTypeObject? Debug { get; set; }

        [JsonPropertyName("Info")]
        public LogTypeObject? Info { get; set; }

        [JsonPropertyName("Notice")]
        public LogTypeObject? Notice { get; set; }

        [JsonPropertyName("Warn")]
        public LogTypeObject? Warn { get; set; }

        [JsonPropertyName("Error")]
        public LogTypeObject? Error { get; set; }

        [JsonPropertyName("Fatal")]
        public LogTypeObject? Fatal { get; set; }
    }
}
