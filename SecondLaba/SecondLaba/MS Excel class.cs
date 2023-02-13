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
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path, ";\n Rows amount: ", RowCount, 
                ";\n Columns amount: ", ColumnCount);
        }

        Excel() {    }
    }
}
