using System.IO;
using System.Linq;

namespace ExcelParser.Providers
{
    /// <summary>
    /// Файловый провайдер
    /// </summary>
    public class FileProvider
    {
        private static readonly string[] ExcelFileExtensions = new string[] { ".xls", ".xlsx" };

        /// <summary>
        /// Метод получения файлов в каталоге и в подкаталогах
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Возвращает массив Excel файлов</returns>
        public static FileInfo[] GetDirectoryExcelFiles(string path) => GetDirectoryExcelFiles(new DirectoryInfo(path));

        /// <summary>
        /// Метод получения Excel файлов в каталоге и его подкаталогах
        /// </summary>
        /// <param name="directory">Каталог</param>
        /// <returns>Возвращает массив Excel файлов</returns>
        public static FileInfo[] GetDirectoryExcelFiles(DirectoryInfo directory) =>
            directory.GetFiles("*.xls?", new EnumerationOptions { RecurseSubdirectories = true });

        /// <summary>
        /// Метод получения флага о том, что файл является Excel документом
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает флаг: true если файл является Excel документом, иначе - false</returns>
        public static bool IsExcelFile(string path) => IsExcelFile(new FileInfo(path));

        /// <summary>
        /// Метод получения флага о том, что файл является Excel документом
        /// </summary>
        /// <param name="file">Файл</param>
        /// <returns>Возвращает флаг: true если файл является Excel документом, иначе - false</returns>
        public static bool IsExcelFile(FileInfo file) => ExcelFileExtensions.Contains(file.Extension);

        /// <summary>
        /// Метод получения флага о том, что файл является каталогом
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает флаг: true если файл является каталогом, иначе - false</returns>
        public static bool IsDirectory(string path) => Directory.Exists(path);
    }
}
