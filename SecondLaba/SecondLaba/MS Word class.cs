using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class Word : Document
    {
        string Title;
        string Fonts;

        public override void Info()
        {
            Console.WriteLine("\nИмя файла - {0};\nИмя автора - {1};\nКлючевые слова - {2};\n" +
                "Тема - {3};\nПуть к файлу- {4};\nЗаголовок - {5};\nШрифты - {6};",
                Name, Author, KeyWords, Topic, Path, Title, Fonts);
        }
        public Word(string Name, string Author, string KeyWords, string Topic, string Path, string Title, string Fonts)
        {
            this.Name = Name;
            this.Author = Author;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
            this.Path = Path;
            this.Title = Title;
            this.Fonts = Fonts;
        }
    }
}