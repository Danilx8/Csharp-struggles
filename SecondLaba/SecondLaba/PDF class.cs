using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class PDF : Document
    {
        string Certificate;
        int DPI;

        public override void Info()
        {
            Console.WriteLine("\nИмя файла - {0};\nИмя автора - {1};\nКлючевые слова - {2};\n" +
                "Тема - {3};\nПуть к файлу- {4};\nСертификат - {5};\nКоличество точек на дюйм - {6};",
                Name, Author, KeyWords, Topic, Path, Certificate, DPI);
        }

        public PDF(string Name, string Author, string KeyWords, string Topic, string Path, string Certificate, 
            int DPI)
        {
            this.Name = Name;
            this.Author = Author;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
            this.Path = Path;
            this.Certificate = Certificate;
            this.DPI = DPI;
        }
    }
}
