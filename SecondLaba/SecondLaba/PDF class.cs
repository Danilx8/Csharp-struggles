using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class PDF: Document
    {
        string Certificate;
        string Fonts;
        int DPI;

        public override void Info()
        {
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path, ";\n Certificate: ", Certificate,
                ";\n Fonts: ", Fonts, ";\n DPI: ", DPI);
        }

        PDF() {     }
    }
}
