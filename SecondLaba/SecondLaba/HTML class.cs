using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class HTML: Document
    {
        string IDs;
        string Classes;

        public override void Info()
        {
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path, ";\n IDs: ", IDs, ";\n Classes: ", Classes);
        }
        HTML() { }
    }
}
