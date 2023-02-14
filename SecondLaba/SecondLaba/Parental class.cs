using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SecondLaba
{
    class Document
    {
        public string Name;
        public string Author;
        public string KeyWords;
        public string Topic;
        public string Path;

        public virtual void Info()
        {
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path);
        }
    }
}
