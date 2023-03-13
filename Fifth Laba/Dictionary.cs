using System;
using System.Collections.Generic;
using System.Text;

namespace Fifth_Laba
{
    class MyDictionary
    {
        private Dictionary<string, List<string>> wrongWordsList = new Dictionary<string, List<string>>();
        private string mask = "";

        public void SetDictionary(string Word, string[] wrongWords)
        {
            List<string> temp = new List<string>();
            foreach(string currentWrongWord in wrongWords)
            {
                temp.Add(currentWrongWord);
            }
            wrongWordsList.Add(Word, temp);
        }

        public List<string> GetWrongWords(string Key)
        {
            return wrongWordsList[Key];
        }

        public void SetMask(string Mask)
        {
            mask = Mask;
        }

        public string GetMask()
        {
            return mask;
        }
    }
}
