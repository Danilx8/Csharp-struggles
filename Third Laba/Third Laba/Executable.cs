using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_Laba
{
    internal class Executable
    {
        static Matrix FirstMatrix;
        static Matrix SecondMatrix;
        static void Main(string[] args)
        {
            int UserInput = 0;
            int MatricesSize = 0;
            do
            {
                while (! Console.KeyAvailable)
                {
                    UserInput = DisplayMenu();
                    switch (UserInput)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Введите размерность своих матриц: ");
                            while (MatricesSize == 0)
                            {
                                MatricesSize = InputHandler();
                            }
                            GenerateFirstMatrix(MatricesSize);
                            GenerateSecondMatrix(MatricesSize);
                            break;
                        case 2:
                            Console.Clear();

                            break;
                    }
                }
            } while(Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Матричный калькулятор");
            Console.WriteLine();
            Console.WriteLine("1. Сгенерировать матрицу");           
            Console.WriteLine("2. Приступить к расчётам");
            if (FirstMatrix.GetSize() > 0 && SecondMatrix.GetSize() > 0)
            {
                Console.WriteLine("3. Список матриц");
            }
            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите ESC");
            int Result = 0;
            while ((Result < 1) || (Result > 3))
            {
                Result = InputHandler();
            }
            return Result;
        }

        static public void GenerateFirstMatrix(int MatrixSize)
        {
            Matrix FirstMatrix = new Matrix(MatrixSize);
        }


        static public void GenerateSecondMatrix(int MatrixSize)
        {
            Matrix SecondMatrix = new Matrix(MatrixSize);
        }

        static private int InputHandler()
        {
            bool Success = (int.TryParse(Convert.ToString(Console.ReadLine()), out int Input));
            if (Success == false)
            {
                Console.WriteLine("Данные введены неверно");
            }
            return Input;
        }

        static public void DemonstrateMatrices()
        {
            int Length = FirstMatrix.GetSize();
            Console.WriteLine("Первая матрица: ");
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Console.WriteLine(FirstMatrix[RowIndex, ColumnIndex] + " ");
                }
                Console.WriteLine("\n");
            }

            Console.SetCursorPosition(Length * 2 + 3, 0);
            Console.WriteLine("Вторая матрица: ");
            Console.SetCursorPosition(Length * 2 + 3, 1);
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Console.WriteLine(SecondMatrix[RowIndex, ColumnIndex] + " ");
                }
                Console.SetCursorPosition(Length * 2 + 3, RowIndex + 1);
            }
        }
    }
}