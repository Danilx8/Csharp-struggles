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
                var TxtFiles = Directory.EnumerateFiles(Path, "*.txt", SearchOption.AllDirectories);

                foreach (string currentFile in TxtFiles)
                {
                    string FileName = currentFile.Substring(Path.Length);
                    if(File.ReadLines(Path + FileName).Any(line => line.Contains(Keywords)) || FileName.Contains(Keywords))
                    {
                        ReadyList.Add(FileName);
                    }
                }
            }
            catch (Exception CurrentException)
            {
                Console.WriteLine(CurrentException.Message);
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