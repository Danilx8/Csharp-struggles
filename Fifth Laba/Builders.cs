using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fifth_Laba
{
    interface IStringBuilder
    {
        void CreateInstance(string Key);
        void CreateMask(string Key);
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

        void IStringBuilder.CreateInstance(string Key)
        {
            Model = Key;
            Console.Write("Введите неправильные вариации вашего слова через запятую " +
                "(для завершения нажмите enter: ");
            string WordsInput = Console.ReadLine();
            string[] WrongWords = WordsInput.Split(',');
            Dictionary.SetDictionary(Key, WrongWords);
        }

        void IStringBuilder.CreateMask(string Key)
        {
            Dictionary<int, List<char>> LettersOptions = new Dictionary<int, List<char>>();
            char[] RightLetters = Key.ToCharArray();

            for (int LetterIndex = 0; LetterIndex < RightLetters.Length; ++LetterIndex)
            {
                LettersOptions[LetterIndex].Add(RightLetters[LetterIndex]);
            }

            foreach (string WrongWord in Dictionary.GetWrongWords(Key))
            {
                foreach (char Letter in WrongWord.ToCharArray())
                {
                    for (int LetterIndex = 0; LetterIndex <
                        Math.Min(Key.ToCharArray().Length, WrongWord.ToCharArray().Length);
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
                foreach (char letter in LettersOptions[LetterIndex])
                {
                    StringBuilder.Append(letter);
                }
                StringBuilder.Append(']');
            }
            Dictionary.SetMask(StringBuilder.ToString());
        }

        void IStringBuilder.Correct(string FilePath)
        {
            string Content = new StreamReader(FilePath).ReadToEnd();
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
        public NumberSearch()
        {
            Dictionary = new MyDictionary();
        }
        
        void IStringBuilder.CreateInstance(string Key)
        {
            Dictionary.SetDictionary(Key, null);
        }

        void IStringBuilder.CreateMask(string Key)
        {
            Dictionary.SetMask("\\(\\d{3}\\)\\s\\d{3}-\\d{2}-\\d{2}");
        }

        void IStringBuilder.Correct(string FilePath)
        {
            string Content = new StreamReader(FilePath).ReadToEnd();
            string Pattern = Dictionary.GetMask();
            Content = Regex.Replace(Content, Pattern, " ");
            using (StreamWriter Writer = new StreamWriter(FilePath, false))
            {
                Writer.Write(Content);
            }
        }
    }
}