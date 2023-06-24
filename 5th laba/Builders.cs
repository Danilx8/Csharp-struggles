using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Fifth_Laba
{
    interface IStringBuilder
    {
        void CreateInstance();
        void CreateMask();
        void Correct(string FilePath);
    }

    class StringSearch: IStringBuilder
    {
        private MyDictionary Dictionary;
        private string Model;
        
        public StringSearch()
        {
            Dictionary = new MyDictionary();
        }

        void IStringBuilder.CreateInstance()
        {
            Console.Write("Введите правильную форму слова: ");
            Model = Console.ReadLine();
            Console.Write("Введите неправильные вариации вашего слова через запятую " +
                "(для завершения нажмите enter: ");
            string WordsInput = Console.ReadLine();
            string[] WrongWords = WordsInput.Split(',');
            Dictionary.SetDictionary(Model, WrongWords);
        }

        void IStringBuilder.CreateMask()
        {
            Dictionary<int, List<char>> LettersOptions = new Dictionary<int, List<char>>();
            char[] RightLetters = Model.ToCharArray();
            List<char> Temp = new List<char>();
            for (int ElementIndex = 0; ElementIndex < RightLetters.Length; ++ElementIndex)
            {
                Temp.Add(RightLetters[ElementIndex]);
                LettersOptions.Add(ElementIndex, Temp);
                Temp.Clear();
            }

            foreach (string WrongWord in Dictionary.GetWrongWords(Model))
            {
                foreach (char Letter in WrongWord.ToCharArray())
                {
                    for (int LetterIndex = 0; LetterIndex <
                        Math.Min(Model.ToCharArray().Length, WrongWord.ToCharArray().Length);
                        ++LetterIndex)
                    {
                        if (Letter != RightLetters[LetterIndex])
                        {
                            LettersOptions[LetterIndex].Add(Letter);
                        }
                    }
                }
            }

            StringBuilder StringBuilder = new StringBuilder(Dictionary.GetMask());
            for (int LetterIndex = 0; LetterIndex < LettersOptions.Count; ++LetterIndex)
            {
                StringBuilder.Append('[');
                foreach (char Letter in LettersOptions[LetterIndex])
                {
                    StringBuilder.Append(Letter);
                }
                StringBuilder.Append(']');
            }
            Dictionary.SetMask(StringBuilder.ToString());
        }

        void IStringBuilder.Correct(string FilePath)
        {
            string Content;
            using (StreamReader Reader = new StreamReader(FilePath))
            {
                Content = Reader.ReadToEnd();
            }
            string Pattern = Dictionary.GetMask();
            Content = Regex.Replace(Content, Pattern, Model);
            using (StreamWriter Writer = new StreamWriter(FilePath, false))
            {
                Writer.Write(Content);
            }
        }
    }

    class NumberSearch: IStringBuilder
    {
        private MyDictionary Dictionary;
        private string Model;
        public NumberSearch()
        {
            Dictionary = new MyDictionary();
        }
        
        void IStringBuilder.CreateInstance()
        {
            Console.Write("Введите номер, на который будут заменены все номера " +
                "неправильного формата, в правильном формате: ");
            Model = Console.ReadLine();
            Dictionary.SetDictionary(Model, null);
        }

        void IStringBuilder.CreateMask()
        {
            Dictionary.SetMask("\\(\\d{3}\\)\\s\\d{3}-\\d{2}-\\d{2}");
        }

        void IStringBuilder.Correct(string FilePath)
        {
            string Content;
            using (StreamReader Reader = new StreamReader(FilePath))
            {
                Content = Reader.ReadToEnd();
            }
            string Pattern = Dictionary.GetMask();
            Content = Regex.Replace(Content, Pattern, Model);
            using (StreamWriter Writer = new StreamWriter(FilePath, false))
            {
                Writer.Write(Content);
            }
        }
    }
}