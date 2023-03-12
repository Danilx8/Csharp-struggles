using System.Collections.Generic;

namespace Fifth_Laba
{
    static class Dictionary
    {
        static Dictionary<string, List<string>> wrongWordsList = new Dictionary<string, List<string>>();
        public static void SetDictionary(string Word, string[] wrongWords)
        {
            List<string> temp = new List<string>();
            foreach(string currentWrongWord in wrongWords)
            {
                temp.Add(currentWrongWord);
            }
            wrongWordsList.Add(Word, temp);
        }

        public static List<string> GetList(string Key)
        {
            return wrongWordsList[Key];
        }
    }
}
