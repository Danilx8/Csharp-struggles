using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class TXT : Document
    {
        int Day;
        int Month;
        int Year;

        public override void Info()
        {
            Console.WriteLine("\nИмя файла - {0};\nИмя автора- {1};\nКлючевые слова- {2};\n" + 
                "Тема - {3};\nПуть к файлу - {4};\nДата создания - {5}.{6}.{7};", 
                Name, Author, KeyWords, Topic, Path, Day, Month, Year);
        }
        public TXT(string Name, string Author, string KeyWords, string Topic, string Path, int Day, int Month, int Year)
        {
            this.Name = Name;
            this.Author = Author;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
            this.Path = Path;
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }
    }
}
