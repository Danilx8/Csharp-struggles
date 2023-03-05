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
            int Choice = 0;
            while (Choice != 4)
            {   
                Console.Write("Добро пожаловать в файловый менеджер. Введите имя рабочей папки: ");
                bool Success = false;
                string UserPath;
                string FolderName = @"C://";
                while (!Success)
                {
                    try
                    {
                        FolderName = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e}. Повторите ввод, пожалуйста");
                    }
                    finally
                    {
                        Success = true;
                    }
                }
                UserPath = Path.GetFullPath(FolderName);

                Console.Clear();
                Console.WriteLine($"Файловый менеджер\n{UserPath}");
                Console.Write("1. Редактировать файл\n2. Найти файлы по ключевым словам\n" +
                    "3. Проиндексировать все файлы в рабочей папке в отдельный файл\n4. Выход");
                while (Choice < 1 || Choice > 4)
                {
                    if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false)
                    {
                        Console.WriteLine("Данные введены неверно. Попробуйте ещё раз");
                    }
                }
                Console.Clear();
                switch (Choice)
                {
                    case 1:
                        Editor.InitiateEdit(UserPath);
                        break;
                    case 2:
                        Console.Write("Введите ключевые слова для поиска: ");
                        string UserKeywords = Console.ReadLine();
                        Console.Clear();
                        Searcher.KeywordsFilesSearcher(UserPath, UserKeywords);
                        Console.ReadKey();
                        break;
                    case 3:

                        break;
                }
            }
        }
    }
}
