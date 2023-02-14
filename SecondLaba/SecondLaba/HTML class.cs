using System;

namespace SecondLaba
{
    class HTML : Document
    {
        string IDs;
        string Classes;

        public override void Info()
        {
            Console.WriteLine("\nИмя файла - {0};\nИмя автора - {1};\nКлючевые слова - {2};\n" +
                "Тема - {3};\nПуть к файлу- {4};\nИдентификаторы - {5};\nКлассы - {6};",
                Name, Author, KeyWords, Topic, Path, IDs, Classes);
        }
        public HTML(string Name, string Author, string KeyWords, string Topic, string Path, string IDs, string Classes)
        {
            this.Name = Name;
            this.Author = Author;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
            this.Path = Path;
            this.IDs = IDs;
            this.Classes = Classes;
        }
    }
}
