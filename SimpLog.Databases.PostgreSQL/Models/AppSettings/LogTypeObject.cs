using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Models.AppSettings
{
    internal class LogTypeObject
    {
        [JsonPropertyName("SaveInDatabase")]
        public bool? SaveInDatabase { get; set; }
    }
}
