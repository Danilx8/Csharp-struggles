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
        public static List<string> KeywordsFilesSearcher(string Path, string Keywords)
        {
            List<string> ReadyList = new List<string>();
            try
            {
                var txtFiles = Directory.EnumerateFiles(Path, "*.txt", SearchOption.AllDirectories);

                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(Path.Length + 1);
                    if(File.ReadLines(Path + fileName).Any(line => line.Contains(Keywords)))
                    {
                        ReadyList.Add(fileName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ReadyList;
        }
    }
}