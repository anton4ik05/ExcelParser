using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelParser.Models;
using ExcelParser.Providers;
using IronXL;
using Serilog;

namespace ExcelParser.Services
{
    /// <summary>
    /// Сервис для парсинга файлов
    /// </summary>
    public class ParseService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ParseService()
        {
            _logger = Log.ForContext<ParseService>();
        }

        /// <summary>
        /// Парсер остатков
        /// </summary>
        public IEnumerable<Remnant> ParseRemnants(FileInfo fileInfo)
        {
            _logger.Debug("Parse excel file on path: {0}", fileInfo.FullName);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File not found on path: {0}", fileInfo.FullName);
            }

            if (!FileProvider.IsExcelFile(fileInfo))
            {
                throw new FormatException("File is not excel file");
            }

            _logger.Debug("Load workbook");

            WorkBook workBook = WorkBook.Load(fileInfo.FullName);

            _logger.Debug("Load workbook... OK.");

            _logger.Debug("Open worksheet");

            WorkSheet sheet = workBook.WorkSheets.First(x => x.Name == "Запрос на загрузку данных");

            _logger.Debug("Open worksheet... OK. Sheet name: {name}", sheet.Name);



            List<Remnant> remnants = new List<Remnant>();

            return remnants;
        }

        /// <summary>
        /// Парсер закупок
        /// </summary>
        public void ParseBuys()
        {

        }
    }
}
