﻿using SimpLog.Databases.PostgreSQL.Models;
using SimpLog.Databases.PostgreSQL.Services.FileServices;
using System.Threading.Tasks;

namespace SimpLog.Databases.PostgreSQL.Services.SimpLogServices
{
    public class SimpLog
    {
        private FileService _fileService = new FileService();

        /// <summary>
        /// If there is no configuration set up in appsettings.json, log is enabled. If there is disabled from the
        /// configuration, take it in mind here.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="saveInDatabase"></param>
        /// <returns></returns>
        public async Task Trace(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Trace, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task Debug(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task Info(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);
        
        public async Task Notice(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task Warn(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task Error(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task Fatal(string message, bool? saveInDatabase = true)
            => await _fileService.Save(message, LogType.Debug, saveInDatabase, string.Empty, false, string.Empty, string.Empty);

        public async Task SaveIntoPostgreSQL(string message, bool? saveInDatabase = true, LogType logType = LogType.Info, string? saveType = null, bool? isSentEmail = null, bool? isSavedIntoFile = false, string? path_to_save_log = null, string? log_file_name = null)
            => await _fileService.Save(message, logType, saveInDatabase, saveType, isSentEmail, path_to_save_log, log_file_name);
    }
}
