/*************************
 *                       *
 *    Луговских Данил    *
 *       ПИ - 221        *
 *         ООП           *
 *                       *
 ************************/

using System;

namespace SecondLaba
{
    class Singletone
    {
        int Type;
        enum Types
        {
            EXCEL,
            PDF,
            TXT,
            WORD,
            HTML
        };

        string Name;
        string Author;
        string KeyWords;
        string Topic;
        string Path;

        int RowCount;
        int ColumnCount;

        string Certificate;
        int DPI;

        int Day;
        int Month;
        int Year;

        string Title;
        string Fonts;

        string IDs;
        string Classes;

        public Singletone() { }

        private void EnterData(int Type)
        {
            Console.Write("Введите дополнительные данные.\nВведите имя файла: ");
            Name = Console.ReadLine();
            Console.Write("Введите имя автора: ");
            Author = Console.ReadLine();
            Console.Write("Введите ключевые слова файла: ");
            KeyWords = Console.ReadLine();
            Console.Write("Введите тему файла: ");
            Topic = Console.ReadLine();
            Console.Write("Введите полный путь к файлу: ");
            Path = Console.ReadLine();
            switch (Type)
            {
                case (int)Types.EXCEL:
                    Console.Write("Введите количество строк: ");
                    RowCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    ColumnCount = Convert.ToInt32(Console.ReadLine());
                    Excel ExcelDoc = new Excel(Name, Author, KeyWords, Topic, Path, RowCount, ColumnCount);
                    ExcelDoc.Info();
                    break;
                case (int)Types.PDF:
                    Console.Write("Введите сертификат: ");
                    Certificate = Console.ReadLine();
                    Console.Write("Введите количество точек на дюйм: ");
                    DPI = Convert.ToInt32(Console.ReadLine());
                    PDF PDFDoc = new PDF(Name, Author, KeyWords, Topic, Path, Certificate, DPI);
                    PDFDoc.Info();
                    break;
                case (int)Types.TXT:
                    Console.Write("Введите день создания документа: ");
                    Day = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите месяц создания документа: ");
                    Month = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите год создания документа: ");
                    Year = Convert.ToInt32(Console.ReadLine());
                    TXT TXTDoc = new TXT(Name, Author, KeyWords, Topic, Path, Day, Month, Year);
                    TXTDoc.Info();
                    break;
                case (int)Types.WORD:
                    Console.Write("Введите заголовок: ");
                    Title = Console.ReadLine();
                    Console.Write("Введите названия шрифтов, используемых в файле: ");
                    Fonts = Console.ReadLine();
                    Word WordDoc = new Word(Name, Author, KeyWords, Topic, Path, Title, Fonts);
                    WordDoc.Info();
                    break;
                case (int)Types.HTML:
                    Console.Write("Введите названия идентификаторов, используемых в документе: ");
                    IDs = Console.ReadLine();
                    Console.Write("Введите названия классов, используемых в документе: ");
                    Classes = Console.ReadLine();
                    HTML HTMLDoc = new HTML(Name, Author, KeyWords, Topic, Path, IDs, Classes);
                    HTMLDoc.Info();
                    break;
            }
        }
        public void InitializeBeauty()
        {
            Console.WriteLine("Выберите необходимый файл (0 - Excel, 1 - PDF, 2 - TXT, 3 - Word, 4 - HTML): ");
            Type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Тип выбран!");
            EnterData(Type);
        }
    }

    class Program
    {
        static void Main()
        {
            Singletone Loner = new Singletone();
            Loner.InitializeBeauty();
            Console.ReadKey();
        }
    }
}