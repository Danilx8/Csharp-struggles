/***********************
 *                     *
 *   Луговских Данил   *
 *       ПИ-221        *
 * Перегрузка операций *
 *                     *
 **********************/

using System;

namespace Third_Laba
{
    internal class Executable
    {
        private static Matrix FirstMatrix;
        private static Matrix SecondMatrix;
        private static Matrix ResultMatrix;
        
        static void Main(string[] args)
        {
            int UserInput = 0;
            int MatricesSize = 0;
            do
            {
                while (!Console.KeyAvailable)
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
                            CalculationsMenu();
                            break;
                        case 3:
                            DemonstrateMatrices();
                            Console.ReadKey();
                            break;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Матричный калькулятор");
            Console.WriteLine();
            Console.WriteLine("1. Сгенерировать матрицу");
            Console.WriteLine("2. Приступить к расчётам");
            Console.WriteLine("3. Список матриц");
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
            FirstMatrix = new Matrix(MatrixSize);
        }


        static public void GenerateSecondMatrix(int MatrixSize)
        {
            SecondMatrix = new Matrix(MatrixSize);
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

        static public void CalculationsMenu()
        {
            Console.WriteLine("1. Операции над двумя матрицами");
            Console.WriteLine("2. Операции над первой матрицей");
            Console.WriteLine("3. Операции над второй матрицей");
            int Option = 0;
            while (Option < 1 || Option > 3)
            {
                Option = InputHandler();
            }
            string Operation = " ";
            int Component;
            switch (Option)
            {
                case 1:
                    Console.Clear();
                    DemonstrateMatrices();
                    Console.WriteLine("\n\nA   B\n\n Выберите операцию: '+', '*', '?'");
                    Operation = Console.ReadLine();
                    Console.Clear();
                    if (Operation == "+")
                    {
                        Console.WriteLine("A + B");
                        ResultMatrix = (FirstMatrix + SecondMatrix).Clone() as Matrix;
                        DemonstrateResult();
                    }
                    else if (Operation == "*")
                    {
                        Console.WriteLine("A * B");
                        ResultMatrix = (FirstMatrix * SecondMatrix).Clone() as Matrix;
                        DemonstrateResult();
                    }
                    else if (Operation == "?")
                    {
                        if (FirstMatrix > SecondMatrix)
                        {
                            Console.WriteLine("A > B");
                        }
                        else if (FirstMatrix < SecondMatrix)
                        {
                            Console.WriteLine("A < B");
                        }
                        else
                        {
                            Console.WriteLine("A = B");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильная операция");
                    }
                    break;
                case 2:
                    Console.Clear();
                    for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
                    {
                        for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                        {
                            Console.WriteLine(FirstMatrix[RowIndex, ColumnIndex]);
                        }
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("\n\nВыберите операцию: '+', '*'");
                    Operation = Console.ReadLine();
                    Console.Clear();
                    if (Operation == "+")
                    {
                        Console.WriteLine("Введите слагаемое: ");
                        Component = InputHandler();
                        Matrix ResultMatrix = (FirstMatrix + Component).Clone() as Matrix;
                    }
                    else if (Operation == "*")
                    {
                        Console.WriteLine("Введите множитель: ");
                        Component = InputHandler();
                        ResultMatrix = (FirstMatrix + Component).Clone() as Matrix;
                    }
                    else
                    {
                        Console.WriteLine("Неправильная операция");
                    }
                    break;
                case 3:
                    Console.Clear();
                    for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
                    {
                        for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                        {
                            Console.WriteLine(FirstMatrix[RowIndex, ColumnIndex]);
                        }
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("\n\nВыберите операцию: '+', '*'");
                    Operation = Console.ReadLine();
                    Console.Clear();
                    if (Operation == "+")
                    {
                        Console.WriteLine("Введите слагаемое: ");
                        Component = InputHandler();
                        Matrix ResultMatrix = (SecondMatrix + Component).Clone() as Matrix;
                    }
                    else if (Operation == "*")
                    {
                        Console.WriteLine("Введите множитель: ");
                        Component = InputHandler();
                        ResultMatrix = (SecondMatrix + Component).Clone() as Matrix;
                    }
                    else
                    {
                        Console.WriteLine("Неправильная операция");
                    }
                    break;
            }
        }

        static public void DemonstrateMatrices()
        {
            int Length = FirstMatrix.GetSize();
            Console.WriteLine("Матрица А: ");
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Console.WriteLine(FirstMatrix[RowIndex, ColumnIndex] + " ");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n\nМатрица B: ");
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Console.WriteLine(SecondMatrix[RowIndex, ColumnIndex] + " ");
                }
                Console.WriteLine("\n");
            }
        }

        static public void DemonstrateResult()
        {
            int Length = ResultMatrix.GetSize();
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Console.WriteLine(ResultMatrix[RowIndex, ColumnIndex] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}