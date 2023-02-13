/*******************
 *                 *
 * Луговских Данил *
 *    ПИ - 221     *
 *      ООП        *
 *                 *
 *******************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    internal class Program
    {
        class Document
        {
            string Name;
            string Author;
            string KeyWords;
            string Topic;
            string Path;

            public virtual void Info()
            {
                Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                    ";\n Topic = ", Topic, ";\n Path = ", Path);
            }
        }

        class Word: Document
        {
            int RowCount;
            int ColumnCount;

            public override void Info()
            {
                
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
