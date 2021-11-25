using System;
using Module2HW5.Configs;
using Module2HW5.Enum;
using Module2HW5.Service.Abstractions;

namespace Module2HW5.Service
{
    public class LoggerService : ILogger
    {
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly LoggerConfig _loggerConfig;
        public LoggerService(IConfigService configService, IFileService fileService)
        {
            _configService = configService;
            _fileService = fileService;
            _loggerConfig = _configService.Config.LoggerConfig;
            FileServiceStart();
        }

        public void Error(string text)
        {
            WriteMessage(LogType.Error, text);
        }

        public void Info(string text)
        {
            WriteMessage(LogType.Info, text);
        }

        public void Warning(string text)
        {
            WriteMessage(LogType.Warning, text);
        }

        public void WriteMessage(LogType type, string text)
        {
            var log = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)} : {type} : {text}";
            Console.WriteLine(log);
            _fileService.Write(log);
        }

        public void FileServiceStart()
        {
            var name = DateTime.UtcNow.ToString(_loggerConfig.FileName);
            var extension = _loggerConfig.FileExtension;
            var dirPath = _loggerConfig.DirectoryPath;
            var capacity = _loggerConfig.DirectoryCapacity;
            _fileService.InitStream(capacity, name, extension, dirPath);
        }
    }
}
