using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class TXT: Document
    {
        string Date;
        int Articul;

        public override void Info()
        {
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path, ";\n Date: ", Date, ";\n Articul: ", Articul);
        }
        TXT() {     }
    }
}
