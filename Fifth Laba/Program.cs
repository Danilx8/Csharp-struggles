/**************************
 *                        *
 *     Данил Луговских    *
 *         ПИ-221         *
 *   Строки и коллекции   *
 *                        *
 *************************/

using System;

namespace Fifth_Laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Фиксер документов\n1.Исправить слова" +
                "\n2.Исправить телефонные номера");
            int UserChoice = 0;
            while (UserChoice < 1 || UserChoice > 2)
            {
                bool Success = (int.TryParse(Convert.ToString(Console.ReadLine()),
                    out UserChoice));
                if (Success == false)
                {
                    Console.WriteLine("Данные введены неверно");
                }
            }

            Director director = new Director();
            Console.Clear();
            Console.Write("Введите полный путь к файлу, в котором вы будете" +
                "проводить изменеия: ");
            string UserFilePath = Console.ReadLine();
            try
            {
                switch (UserChoice)
                {
                    case 1:
                        director.SetBuilder(new StringSearch());
                        director.FixDocument(UserFilePath);
                        break;
                    case 2:
                        director.SetBuilder(new NumberSearch());
                        director.FixDocument(UserFilePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так\n" + ex);
            }
            finally
            {
                Console.WriteLine("Изменения совершены успешно");
                Console.ReadKey();
            }
        }
    }
}
