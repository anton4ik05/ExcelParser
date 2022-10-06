using System;

namespace ExcelParser.Services
{
    /// <summary>
    /// Сервис для отправки данных
    /// </summary>
    public class UploadService
    {
        public void Upload()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("1. Загрузка через API");
            Console.WriteLine("2. Загрузка вручную");
            var keyUpload = Console.ReadLine();

            //switch (keyUpload)
            //{
            //    case "1":
                    
            //        break;
            //    default: 
            //}
        }
    }
}
