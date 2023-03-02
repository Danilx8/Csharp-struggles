using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth_Laba
{
    internal class Searcher
    {
        private int count = 0;
        private List<TextInfoClass> files = new List<TextInfoClass>();

        public void AddFileToBase(FileStream file, string Keywords, string FileName)
        {
            TextInfoClass Newbie = new TextInfoClass(Keywords, FileName);
            ++count;
            files.Add(Newbie);
        }

        public TextInfoClass KeyWordsSearch(string KeyWords)
        {
            for (int ElementIndex = 0; ElementIndex < count; ++ElementIndex)
            {
                if (files[ElementIndex].Keywords == KeyWords)
                {
                    return files[ElementIndex];
                }
            }
            return null;
        }
    }
}