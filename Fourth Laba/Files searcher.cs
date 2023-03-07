using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fourth_Laba
{
    internal class Searcher
    {
        public static void KeywordsFilesSearcher(string Path, string Keywords)
        {
            List<string> ReadyList = new List<string>();
            try
            {
                var txtFiles = Directory.EnumerateFiles(Path, "*.txt", SearchOption.AllDirectories);

                foreach (string currentFile in txtFiles)
                {
                    string fileName = currentFile.Substring(Path.Length);
                    if(File.ReadLines(Path + fileName).Any(line => line.Contains(Keywords)) || fileName.Contains(Keywords))
                    {
                        ReadyList.Add(fileName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (ReadyList.Count != 0)
            {
                for (int ElementIndex = 0; ElementIndex < ReadyList.Count; ++ElementIndex)
                {
                    Console.Write($"{ElementIndex + 1}. {ReadyList[ElementIndex]}\n");
                }
            }
            else
            {
                Console.WriteLine("Нет подходящих файлов");
            }
        }
    }
}