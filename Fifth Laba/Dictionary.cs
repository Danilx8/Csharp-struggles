using System;
using System.Collections.Generic;
using System.Text;

namespace Fifth_Laba
{
    class MyDictionary
    {
        public Dictionary<string, List<string>> wrongWordsList = new Dictionary<string, List<string>>();
        public string mask = "";

        public void SetDictionary(string Word, string[] wrongWords)
        {
            List<string> temp = new List<string>();
            foreach(string currentWrongWord in wrongWords)
            {
                temp.Add(currentWrongWord);
            }
            wrongWordsList.Add(Word, temp);
        }

        public string GetMask(string Key)
        {
            return mask;
        }
    }
}
