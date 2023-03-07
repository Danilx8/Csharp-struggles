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
        public static void InitiateEdit(string UserPath, string FileName)
        {
            Console.Write("Что будете делать с указанным файлом?\n\n1. Изменить текст\n" +
                "2. Запомнить состояние\n3. Откатить изменения\n\nВведите номер опции: ");
            int Choice = 0;
            while (Choice < 1 || Choice > 3)
            {
                if (int.TryParse(Convert.ToString(Console.ReadLine()), out Choice) == false)
                {
                    Console.WriteLine("Данные введены неверно. Попробуйте ещё раз");
                }
            }

            FileStream file = new FileStream(UserPath, FileMode.OpenOrCreate);
            FileReader(file, FileName);
            switch (Choice)
            {
                case 1:
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
                    FileWriter(Input, UserPath);
                    Console.Clear();
                    Console.WriteLine("Изменения добавлены успешно");
                    Console.ReadKey();
                    break;
                case 2:
                    ct.SaveState(textFile);
                    break;
                case 3:
                    try
                    {
                        RestoreData(UserPath);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Не было изменений");
                        Console.ReadKey();
                    }
                    break;
            }
            file.Close();
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
            reader.Close();
        }

        private static void FileWriter(string input, string UserPath)
        {
            StreamWriter writer = new StreamWriter(UserPath, true);
            writer.Write(input);
            textFile.Content = input;
            writer.Close();
        }

        private static void RestoreData(string UserPath)
        {
            ct.RestoreState(textFile);
            StreamWriter writer = new StreamWriter(UserPath, false);
            writer.Write(textFile.Content);
            writer.Close();
        }
    }
}
