using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecondLaba
{
    class Excel: Document
    {
        int RowCount;
        int ColumnCount;

        public override void Info()
        {
            Console.WriteLine("\nИмя файла - {0};\nИмя автора - {1};\nКлючевые слова - {2};\n" +
                "Тема - {3};\nПуть к файлу- {4};\nЧисло строк - {5};\nЧисло столбцов - {6};",
                Name, Author, KeyWords, Topic, Path, RowCount, ColumnCount);
        }

        public Excel(string Name, string Author, string KeyWords, string Topic, string Path, int RowCount, int ColumnCount) 
        {
            this.Name = Name;
            this.Author = Author;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
            this.Path = Path;
            this.RowCount = RowCount;
            this.ColumnCount = ColumnCount;
        }
    }
}
