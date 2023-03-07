using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth_Laba
{
    internal static class Indexator
    {
        public static void PerformIndexation(string Path)
        {
            List<string> extensions = new List<string>();
            Console.WriteLine("Вводите расширения, по которым вы бы хотели" +
                " проводить индексацию. Для остановки введите ~");
            while (!extensions.Contains("~"))
            {
                extensions.Add(Console.ReadLine());
            }
            extensions.Remove("~");

            Console.Write("\nВведите имя файла c расширением, в который нужно сохранить результат индексации: ");
            string loggingFileName = Path + @"\" + Console.ReadLine();
            FileStream indexatedFile = new FileStream(loggingFileName, FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(indexatedFile))
                foreach (string currentExtension in extensions)
                {
                    var extensionFiles = Directory.EnumerateFiles(Path, "*." + currentExtension,
                        SearchOption.AllDirectories);
                    writer.WriteLine(currentExtension + ":\n");
                    foreach (string currentFile in extensionFiles)
                    {
                        string fileName = currentFile.Substring(Path.Length);
                        writer.WriteLine(fileName);
                    }
                }
            indexatedFile.Close();
        }
    }
}
