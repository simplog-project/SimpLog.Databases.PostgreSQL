﻿namespace SimpLog.Databases.PostgreSQL.Models.AppSettings
{
    internal class DatabaseConfiguration
    {
        public string? Connection_String { get; set; }

        public bool? Use_OleDB { get; set; }

        public bool? Global_Enabled_Save { get; set; } = true;
    }
}
