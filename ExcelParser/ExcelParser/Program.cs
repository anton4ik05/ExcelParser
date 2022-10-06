using ExcelParser.Providers;
using Serilog.Events;
using Serilog;
using System;
using System.Configuration;
using System.IO;
using ExcelParser.Services;

namespace ExcelParser
{
    public class Program
    {
        private const int MaxFileShowCount = 15;

        private static ILogger _logger = null!;

        static void Main(string[] args)
        {
            ConfigureLogging();

            ParseService parseService = new();
            UploadService uploadService = new();

            try
            {
                _logger = Log.ForContext<Program>();

                string path = ConfigurationManager.AppSettings["Path"];
                if (string.IsNullOrEmpty(path)) throw new Exception("Путь к файлам не указан");

                FileInfo[] files = GetFiles(path);

                foreach (var fileInfo in files)
                {
                    Console.WriteLine("Название файла: " + fileInfo.Name);
                    Console.WriteLine("============================================");
                    Console.WriteLine("1. Остатки");
                    Console.WriteLine("2. Закупки");
                    var keyParse = Console.ReadKey().KeyChar;

                    switch (keyParse)
                    {
                        case '1':
                            parseService.ParseRemnants(fileInfo);
                            break;
                        case '2':
                            parseService.ParseBuys();
                            break;
                        default: _logger.Error("Неверный выбор"); break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal("Unhandled exception. Message: {message}, exception: {@exception}", ex.Message, ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        /// <summary>
        /// Метод получения файлов
        /// </summary>
        /// <param name="args">Путь к файлам</param>
        /// <returns>Возвращает массив файлов</returns>
        private static FileInfo[] GetFiles(string args)
        {
            FileInfo[] files;

            if (FileProvider.IsDirectory(args))
            {
                _logger.Debug("Search excel files in folder on path: {path}", args);

                files = FileProvider.GetDirectoryExcelFiles(args);
                if (files.Length == 0)
                {
                    _logger.Debug("Excel files not found in folder.");
                }

                LogFileList(files);
            }
            else
            {
                files = new FileInfo[] { new FileInfo(args) };

                _logger.Debug("Parse excel file in folder on path: {path}", args);
            }

            return files;
        }

        /// <summary>
        /// Метод логирования списка файлов
        /// </summary>
        /// <param name="files">Массив файлов</param>
        private static void LogFileList(FileInfo[] files)
        {
            if (_logger.IsEnabled(LogEventLevel.Debug))
            {
                _logger.Debug("Found {fileCount} files", files.Length);

                for (int i = 0; i < files.Length && i < MaxFileShowCount; i++)
                {
                    _logger.Debug("{fileName}", files[i]);
                }

                if (files.Length > MaxFileShowCount)
                {
                    _logger.Debug("...");
                }
            }
        }

        /// <summary>
        /// Метод конфигурации логгера
        /// </summary>
        private static void ConfigureLogging()
        {
            const string outputTemplate = "{Timestamp:HH:mm:ss:fff} [{Level:u3}] <{SourceContext}> {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Debug(outputTemplate: outputTemplate)
              .WriteTo.Console(outputTemplate: outputTemplate)
              .WriteTo.File("log.log", LogEventLevel.Verbose, outputTemplate, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3)
              .CreateLogger();
        }

    }
}
