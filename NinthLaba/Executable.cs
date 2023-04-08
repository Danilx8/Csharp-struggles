using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLaba
{
    internal class Executable
    {
        const int ChoicesAmount = 9;
        static SquareMatrix FirstMatrix;
        static SquareMatrix SecondMatrix;
        static SquareMatrix ResultMatrix;
        delegate SquareMatrix DiagonalMatrix(SquareMatrix Matrix);

        enum Choices
        {
            GENERATE_MATRICES = 1,
            BEGIN_CALCULATIONS,
            SHOW_MATRICES,
            DIAGONALIZE_MATRIX,
            FIRST_DETERMINANT,
            SECOND_DETERMINANT,
            TRANSPOSE,
            FIND_TRACE,
            EXIT
        };

        static void Main(string[] args)
        {
            bool Finished = false;
            int UserInput = 0;
            int MatricesSize = 0;
            do
            {
                UserInput = DisplayMenu();
                switch (UserInput)
                {
                    case (int)Choices.GENERATE_MATRICES:
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
                    case (int)Choices.BEGIN_CALCULATIONS:
                        Console.Clear();
                        CalculationsMenu();
                        break;
                    case (int)Choices.SHOW_MATRICES:
                        DemonstrateMatrices();
                        Console.Clear();
                        break;
                    case (int)Choices.DIAGONALIZE_MATRIX:
                        Console.WriteLine("Первую или вторую?");
                        int MatricesDiagonalizationChoice = 0;
                        while ((MatricesDiagonalizationChoice < 1) || (MatricesDiagonalizationChoice > 2))
                        {
                            MatricesDiagonalizationChoice = InputHandler();
                        }

                        DiagonalMatrix DiagonalizeMatrix = delegate (SquareMatrix Matrix)
                        {
                            int MatrixSize = Matrix.GetSize();

                            for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ColumnIndex++)
                            {
                                double DiagonalElement = Matrix[ColumnIndex, ColumnIndex];

                                if (DiagonalElement == 0)
                                {
                                    int SwapRowIndex = ColumnIndex + 1;
                                    while (SwapRowIndex < MatrixSize && Matrix[SwapRowIndex, ColumnIndex] == 0)
                                    {
                                        SwapRowIndex++;
                                    }

                                    if (SwapRowIndex < MatrixSize)
                                    {
                                        for (int RowIndex = ColumnIndex; RowIndex < MatrixSize; RowIndex++)
                                        {
                                            double TempValue = Matrix[ColumnIndex, RowIndex];
                                            Matrix[ColumnIndex, RowIndex] = Matrix[SwapRowIndex, RowIndex];
                                            Matrix[SwapRowIndex, RowIndex] = TempValue;
                                        }
                                        DiagonalElement = Matrix[ColumnIndex, ColumnIndex];
                                    }
                                }

                                for (int RowIndex = ColumnIndex; RowIndex < MatrixSize; RowIndex++)
                                {
                                    Matrix[ColumnIndex, RowIndex] /= DiagonalElement;
                                }

                                for (int SwappedColumnIndex = 0; SwappedColumnIndex < MatrixSize; SwappedColumnIndex++)
                                {
                                    if (SwappedColumnIndex == ColumnIndex)
                                    {
                                        continue;
                                    }

                                    double Factor = Matrix[SwappedColumnIndex, ColumnIndex] / Matrix[ColumnIndex, ColumnIndex];
                                    for (int RowIndex = ColumnIndex; RowIndex < MatrixSize; RowIndex++)
                                    {
                                        Matrix[SwappedColumnIndex, RowIndex] -= Factor * Matrix[ColumnIndex, RowIndex];
                                    }
                                }
                            }
                            return Matrix;
                        };

                        try
                        {
                            switch (MatricesDiagonalizationChoice)
                            {
                                case 1:
                                    ResultMatrix = DiagonalizeMatrix.Invoke(FirstMatrix);
                                    DemonstrateResult();
                                    break;
                                case 2:
                                    ResultMatrix = DiagonalizeMatrix.Invoke(SecondMatrix);
                                    DemonstrateResult();
                                    break;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Выбранная матрица не сгенерирована");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case (int)Choices.FIRST_DETERMINANT:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Определитель первой матрицы:");
                            Console.WriteLine(FirstMatrix.Determinant().ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Первая матрица не сгенерирована");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case (int)Choices.SECOND_DETERMINANT:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Определитель второй матрицы:");
                            Console.WriteLine(SecondMatrix.Determinant().ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Вторая матрица не сгенерирована");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case (int)Choices.TRANSPOSE:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Первую или вторую?");
                            int MatricesTransposingChoice = 0;
                            while ((MatricesTransposingChoice < 1) || (MatricesTransposingChoice > 2))
                            {
                                MatricesTransposingChoice = InputHandler();
                            }
                            switch (MatricesTransposingChoice)
                            {
                                case 1:
                                    Console.WriteLine("Первая матрица в транспонированном виде:");
                                    ResultMatrix = FirstMatrix.TransposeMatrix();
                                    DemonstrateResult();
                                    break;
                                case 2:
                                    Console.WriteLine("Вторая матрица в транспонированном виде:");
                                    ResultMatrix = SecondMatrix.TransposeMatrix();
                                    DemonstrateResult();
                                    break;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Матрица не сгенерирована");
                        }
                        Console.ReadKey();
                        break;
                    case (int)Choices.FIND_TRACE:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Первую или вторую?");
                            int MatricesTracingChoice = 0;
                            while ((MatricesTracingChoice < 1) || (MatricesTracingChoice > 2))
                            {
                                MatricesTracingChoice = InputHandler();
                            }
                            switch (MatricesTracingChoice)
                            {
                                case 1:
                                    Console.WriteLine("След первой матрицы:");
                                    Console.WriteLine(FirstMatrix.MatrixTrace());
                                    break;
                                case 2:
                                    Console.WriteLine("Следы второй матрицы:");
                                    Console.WriteLine(SecondMatrix.MatrixTrace());
                                    break;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Матрица не сгенерирована");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case (int)Choices.EXIT:
                        Finished = true;
                        break;
                }
            } while (Finished == false);
            Console.WriteLine("Завершение программы. Нажмите на любую кнопку");
            Console.ReadKey();
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Матричный калькулятор");
            Console.WriteLine();
            Console.WriteLine("1. Сгенерировать матрицу");
            Console.WriteLine("2. Приступить к расчётам");
            Console.WriteLine("3. Список матриц");
            Console.WriteLine("4. Привести матрицу к диагональному виду");
            Console.WriteLine("5. Вычислить определитель первой матрицы");
            Console.WriteLine("6. Вычислить определитель второй матрицы");
            Console.WriteLine("7. Транспонировать матрицу");
            Console.WriteLine("8. Вычислить след матрицы");
            Console.WriteLine();
            Console.WriteLine("9. Выход");
            int Result = 0;
            while ((Result < 1) || (Result > ChoicesAmount))
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
