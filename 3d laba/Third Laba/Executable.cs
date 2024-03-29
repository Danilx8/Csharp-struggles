﻿/***********************
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
        static SquareMatrix FirstMatrix;
        static SquareMatrix SecondMatrix;
        static SquareMatrix ResultMatrix;

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
                            while (MatricesSize <= 0)
                            {
                                MatricesSize = InputHandler();
                            }
                            GenerateFirstMatrix(MatricesSize);
                            GenerateSecondMatrix(MatricesSize);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            CalculationsMenu();
                            break;
                        case 3:
                            DemonstrateMatrices();
                            Console.Clear();
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
            FirstMatrix = new SquareMatrix(MatrixSize);
        }


        static public void GenerateSecondMatrix(int MatrixSize)
        {
            SecondMatrix = new SquareMatrix(MatrixSize);
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
                    if (DemonstrateMatrices())
                    {
                        Console.WriteLine("\n\nA   B\n\nВыберите операцию: '+', '*', '?'");
                        Operation = Console.ReadLine();
                        Console.Clear();
                        if (Operation == "+")
                        {
                            Console.WriteLine("A + B");
                            ResultMatrix = (FirstMatrix + SecondMatrix).Clone() as SquareMatrix;
                            DemonstrateResult();
                        }
                        else if (Operation == "*")
                        {
                            Console.WriteLine("A * B");
                            ResultMatrix = (FirstMatrix * SecondMatrix).Clone() as SquareMatrix;
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
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Неправильная операция");
                        }
                    }
                    break;
                case 2:
                    Console.Clear();
                    try
                    {
                        for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
                        {
                            for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                            {
                                Console.Write(FirstMatrix[RowIndex, ColumnIndex] + " ");
                            }
                            Console.Write("\n");
                        }
                        Console.WriteLine("\n\nВыберите операцию: '+', '*'");
                        Operation = Console.ReadLine();
                        Console.Clear();
                        if (Operation == "+")
                        {
                            Console.Write("Введите слагаемое: ");
                            Component = InputHandler();
                            ResultMatrix = (FirstMatrix + Component).Clone() as SquareMatrix;
                            DemonstrateResult();
                        }
                        else if (Operation == "*")
                        {
                            Console.Write("Введите множитель: ");
                            Component = InputHandler();
                            ResultMatrix = (FirstMatrix * Component).Clone() as SquareMatrix;
                            DemonstrateResult();
                        }
                        else
                        {
                            Console.Write("Неправильная операция");
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Нет готовых матриц");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    Console.Clear();
                    try
                    {
                        for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
                        {
                            for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                            {
                                Console.Write(FirstMatrix[RowIndex, ColumnIndex] + " ");
                            }
                            Console.Write("\n");
                        }
                        Console.WriteLine("\n\nВыберите операцию: '+', '*'");
                        Operation = Console.ReadLine();
                        Console.Clear();
                        if (Operation == "+")
                        {
                            Console.WriteLine("Введите слагаемое: ");
                            Component = InputHandler();
                            ResultMatrix = (SecondMatrix + Component).Clone() as SquareMatrix;
                            DemonstrateResult();
                        }
                        else if (Operation == "*")
                        {
                            Console.WriteLine("Введите множитель: ");
                            Component = InputHandler();
                            ResultMatrix = (SecondMatrix * Component).Clone() as SquareMatrix;
                            DemonstrateResult();
                        }
                        else
                        {
                            Console.WriteLine("Неправильная операция");
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Нет готовых матриц");
                        Console.ReadKey();
                    }
                    break;
            }
        }

        static public bool DemonstrateMatrices()
        {
            try
            {
                int Length = FirstMatrix.GetSize();
                Console.WriteLine("Матрица А: ");
                for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
                {
                    for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                    {
                        Console.Write(FirstMatrix[RowIndex, ColumnIndex] + " ");
                    }
                    Console.Write("\n");
                }

                Console.WriteLine("\n\nМатрица B: ");
                for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
                {
                    for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                    {
                        Console.Write(SecondMatrix[RowIndex, ColumnIndex] + " ");
                    }
                    Console.Write("\n");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Нет готовых матриц");
                Console.ReadKey();
                return false;
            }
            Console.ReadKey();
            return true;
        }

        static public void DemonstrateResult()
        {
            try
            {
                int Length = ResultMatrix.GetSize();
                for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
                {
                    for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                    {
                        Console.Write(ResultMatrix[RowIndex, ColumnIndex] + " ");
                    }
                    Console.Write("\n");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Нет матрицы результата");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}