using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fourth_Laba
{
    internal static class Editor
    {
        public static void InitiateEdit(string UserPath)
        {
            Console.Write("Что будете делать с указанным файлом?\n\n1. Изменить текст\n2. Откатить изменения\n\nВведите число: ");
            int Choice = 0;
            while (Choice < 1 || Choice > 2)
            {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false)
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз");
                }
            }

            switch (Choice)
            {
                case 1:
                    FileStream file = new FileStream(UserPath, FileMode.OpenOrCreate);
                    FileReader(file, textFile.FileName);
                    Console.Clear();
                    Console.WriteLine("Введите новое содержание файла(нажмите ~ для выхода):");
                    char ch;
                    int element;
                    string Input = "";
                    do
                    {
                        element = Console.Read();
                        try
                        {
                            ch = Convert.ToChar(element);
                            Input += ch;
                        }
                        catch(OverflowException)
                        {
                            Console.WriteLine($"{element} - не подходящее значение");
                            ch = Char.MinValue;
                        }
                    } while (ch != '~');
                    FileWriter(Input, file);
                    Console.Clear();
                    Console.WriteLine("Изменения добавлены успешно");
                    Console.ReadKey();
                    break;
                case 2:
                    try
                    {
                        RestoreData();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Не было изменений");
                        Console.ReadKey();
                    }
                    break;
            }

        }

        static TextClass textFile = new TextClass();
        static Caretaker ct = new Caretaker();

        private static void FileReader(FileStream file, string FileName)
        {
            string outString = "";
            var reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                outString += reader.ReadLine();
            }

            textFile.Content = outString;
            textFile.FileName = FileName;
            ct.SaveState(textFile);
        }

        private static void FileWriter(string input, FileStream file)
        {
            StreamWriter write = new StreamWriter(file, Encoding.Default);
            write.Write(input);
            textFile.Content = input;
        }

        private static void RestoreData()
        {
            ct.RestoreState(textFile);
        }
    }
}
