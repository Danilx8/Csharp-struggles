using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fourth_Laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Добро пожаловать в файловый менеджер. Введите полный путь к рабочей папке: ");
            string UserPath = @"C:\";
            bool Success = false;
            while (Success == false)
            {
                UserPath = Console.ReadLine();
                if (Directory.Exists(UserPath) && UserPath != string.Empty)
                {
                    Success = true;
                }
                else
                {
                    Console.WriteLine("Неверный формат пути, попробуйте снова");
                }
            }
            int Choice = 0;
            while (Choice != 4)
            {   
                Console.Clear();
                Console.WriteLine($"Файловый менеджер\n{UserPath}");
                Console.WriteLine("1. Редактировать файл\n2. Найти файлы по ключевым словам\n" +
                    "3. Проиндексировать все файлы в рабочей папке в отдельный файл\n4. Выход");
                while (Choice < 1 || Choice > 4)
                {
                    if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false)
                    {
                        Console.WriteLine("Данные введены неверно. Попробуйте ещё раз");
                    }
                }
                Console.Clear();
                string FileName;
                switch (Choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите имя .txt файла, который вы хотите отредактировать: ");
                        FileName = Console.ReadLine();
                        Editor.InitiateEdit(UserPath + @"\" + FileName + ".txt", FileName);
                        Choice = 0;
                        break;
                    case 2:
                        Console.Write("Введите ключевые слова для поиска: ");
                        string UserKeywords = Console.ReadLine();
                        Console.Clear();
                        Searcher.KeywordsFilesSearcher(UserPath, UserKeywords);
                        Console.ReadKey();
                        Choice = 0;
                        break;
                    case 3:
                        Indexator.PerformIndexation(UserPath);
                        Choice = 0;
                        break;
                }
            }
        }
    }
}
