﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLaba
{
    class Word: Document
    {
        string Title;
        string Fonts;

        public override void Info()
        {
            Console.WriteLine("Name = ", Name, ";\n Author = ", Author, ";\n Keywords = ", KeyWords,
                ";\n Topic = ", Topic, ";\n Path = ", Path, ";\n Title: ", Title, ";\n Fonts: ", Fonts);
        }
        Word() {     }
    }
}