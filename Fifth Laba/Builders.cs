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
        void Correct(string filePath, string model, string[] wrongs);
    }

    class StringSearch: IStringBuilder
    {
        private MyDictionary dictionary;
        public StringSearch()
        {
            dictionary = new MyDictionary();
        }

        private string CreateWordMask(string Key)
        {
            Dictionary<int, List<char>> LettersOptions = new Dictionary<int, List<char>>();
            char[] rightLetters = Key.ToCharArray();

            for (int letterIndex = 0; letterIndex < rightLetters.Length; ++letterIndex)
            {
                LettersOptions[letterIndex].Add(rightLetters[letterIndex]);
            }

            foreach (string wrongWord in dictionary.wrongWordsList[Key])
            {
                foreach (char letter in wrongWord.ToCharArray())
                {
                    for (int letterIndex = 0; letterIndex <
                        Math.Min(Key.ToCharArray().Length, wrongWord.ToCharArray().Length);
                        ++letterIndex)
                    {
                        if (letter != rightLetters[letterIndex])
                        {
                            LettersOptions[letterIndex].Add(letter);
                        }
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder(dictionary.mask);
            for (int letterIndex = 0; letterIndex < LettersOptions.Count; ++letterIndex)
            {
                stringBuilder.Append('[');
                foreach (char letter in LettersOptions[letterIndex])
                {
                    stringBuilder.Append(letter);
                }
                stringBuilder.Append(']');
            }
            dictionary.mask = stringBuilder.ToString();
            return dictionary.mask;
        }

        void IStringBuilder.Correct(string filePath, string model, string[] wrongs)
        {
            dictionary.SetDictionary(model, wrongs);
            string content = new StreamReader(filePath).ReadToEnd();
            //Regex regex = new Regex(dictionary.GetMask(model));
            string pattern = dictionary.GetMask(model);
            content = Regex.Replace(content, pattern, model);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(content);
            }
        }
    }

    class NumberSearch: IStringBuilder
    {
        private MyDictionary dictionary;
        public NumberSearch()
        {
            dictionary = new MyDictionary();
        }

        void IStringBuilder.Correct(string filePath, string model, string[] wrongs)
        {

        }
    }
}
