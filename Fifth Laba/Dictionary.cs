using System;
using System.Collections.Generic;
using System.Text;

namespace Fifth_Laba
{
    class MyDictionary
    {
        private Dictionary<string, List<string>> WrongWordsList = new Dictionary<string, List<string>>();
        private string Mask = "";

        public void SetDictionary(string Word, string[] wrongWords)
        {
            if (wrongWords != null)
            {
                List<string> TempList = new List<string>();
                foreach (string currentWrongWord in wrongWords)
                {
                    TempList.Add(currentWrongWord);
                }
                WrongWordsList.Add(Word, TempList);
            }
        }

        public List<string> GetWrongWords(string Key)
        {
            return WrongWordsList[Key];
        }

        public void SetMask(string Mask)
        {
            this.Mask = Mask;
        }

        public string GetMask()
        {
            return Mask;
        }
    }
}
