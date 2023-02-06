using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba_Second_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string Number = Console.ReadLine();

            Console.WriteLine("Новое число: ");
            for (int ElementIndex = 0; ElementIndex < Number.Length; ++ElementIndex)
            {
                if (ElementIndex == 0)
                {
                    Console.Write(Number[ElementIndex]);
                } else if (ElementIndex >= 1 && ElementIndex < Number.Length - 1)
                {
                    Console.Write(Number[ElementIndex + 1]);
                } else
                {
                    Console.Write(Number[1]);
                }
            }
            Console.ReadKey();
        }
    }
}
