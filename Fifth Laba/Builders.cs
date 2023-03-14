using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fifth_Laba
{
    interface IStringBuilder
    {
        void CreateMask(string Key);
        void Correct(string FilePath, string Model, string[] WrongWords);
    }

    class StringSearch: IStringBuilder
    {
        private MyDictionary Dictionary;
        public StringSearch()
        {
            Dictionary = new MyDictionary();
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

        void IStringBuilder.Correct(string FilePath, string Model, string[] WrongWords)
        {
            Dictionary.SetDictionary(Model, WrongWords);
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

        

        void IStringBuilder.Correct(string FilePath, string Model, string[] WrongWords)
        {

        }
    }
}