using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            int Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите степень:");
            int Power = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Math.Exp(Math.Log(Number) * Power));
            Console.ReadKey();
        }
    }
}
