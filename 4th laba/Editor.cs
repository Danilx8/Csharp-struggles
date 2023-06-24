using System;
using System.Collections.Generic;
using System.IO;

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

            FileStream File = new FileStream(UserPath, FileMode.OpenOrCreate);
            switch (Choice)
            {
                case 1:
                    FileReader(File, FileName);
                    Console.Clear();
                    Console.WriteLine("Введите новое содержание файла(нажмите ~ для выхода):");
                    char Character;
                    int Element;
                    string Input = "";
                    do
                    {
                        Element = Console.Read();
                        try
                        {
                            Character = Convert.ToChar(Element);
                            Input += Character;
                        }
                        catch(OverflowException)
                        {
                            Console.WriteLine($"{Element} - не подходящее значение");
                            Character = Char.MinValue;
                        }
                    } while (Character != '~');
                    FileWriter(Input, UserPath, FileName);
                    Console.Clear();
                    Console.WriteLine("Изменения добавлены успешно");
                    Console.ReadKey();
                    break;
                case 2:
                    FileReader(File, FileName);
                    Caretaker.SaveState(TextFile);
                    break;
                case 3:
                    try
                    {
                        File.Close();
                        RestoreData(UserPath, FileName);
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("Не было изменений");
                        Console.ReadKey();
                    }
                    break;
            }
            File.Close();
        }

        static TextClass TextFile = new TextClass();
        static Caretaker Caretaker = new Caretaker();

        private static void FileReader(FileStream File, string FileName)
        {
            string outString = "";
            var Reader = new StreamReader(File);

            while (!Reader.EndOfStream)
            {
                outString += Reader.ReadLine();
            }
            try
            {
                TextFile.Content.Add(FileName, outString);
                TextFile.FileName.Add(FileName);
            }
            catch (Exception)
            {
                TextFile.Content[FileName] = outString;       
            }
            Reader.Close();
        }

        private static void FileWriter(string input, string UserPath, string FileName)
        {
            using (StreamWriter writer = new StreamWriter(UserPath, true))
            {
                writer.Write(input);
            }
        }

        private static void RestoreData(string UserPath, string FileName)
        {
            Caretaker.RestoreState(TextFile);
            using (StreamWriter Writer = new StreamWriter(UserPath, false))
            {
                Writer.Write(TextFile.Content[FileName]);
            }
        }
    }
}
