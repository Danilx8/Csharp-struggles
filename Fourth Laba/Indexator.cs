using System;
using System.Collections.Generic;
using System.IO;

namespace Fourth_Laba
{
    internal static class Indexator
    {
        public static void PerformIndexation(string Path)
        {
            List<string> Extensions = new List<string>();
            Console.WriteLine("Вводите расширения, по которым вы бы хотели" +
                " проводить индексацию. Для остановки введите ~");
            while (!Extensions.Contains("~"))
            {
                Extensions.Add(Console.ReadLine());
            }
            Extensions.Remove("~");

            Console.Write("\nВведите имя файла c расширением, в который нужно сохранить результат индексации: ");
            string LoggingFileName = Path + @"\" + Console.ReadLine();
            FileStream IndexatedFile = new FileStream(LoggingFileName, FileMode.OpenOrCreate);
            using (StreamWriter Writer = new StreamWriter(IndexatedFile))
                foreach (string CurrentExtension in Extensions)
                {
                    var ExtensionFiles = Directory.EnumerateFiles(Path, "*." + CurrentExtension,
                        SearchOption.AllDirectories);
                    Writer.WriteLine(CurrentExtension + ":\n");
                    foreach (string CurrentFile in ExtensionFiles)
                    {
                        string FileName = CurrentFile.Substring(Path.Length);
                        Writer.WriteLine(FileName);
                    }
                }
            IndexatedFile.Close();
        }
    }
}
