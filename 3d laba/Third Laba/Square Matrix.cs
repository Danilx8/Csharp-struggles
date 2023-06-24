using System;

namespace Third_Laba
{
    public class SquareMatrix: ICloneable, IComparable
    {
        private int MatrixSize;
        private double[,] UserMatrix;
        
        public SquareMatrix(int InputMatrixSize) {
            try
            {
                if (InputMatrixSize <= 0)
                {
                    throw new InvalidMatrixException("Размер не может быть меньше единицы!");
                }
                MatrixSize = InputMatrixSize;
                Random Rand = new Random(Guid.NewGuid().GetHashCode());
                UserMatrix = new double[MatrixSize, MatrixSize];
                for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                {
                    for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ++ColumnIndex)
                    {
                        UserMatrix[RowIndex, ColumnIndex] = Convert.ToDouble(Rand.Next(-100, 100));
                    }
                }
            }
            catch (InvalidMatrixException err)
            {
                Console.WriteLine(err.Message);
                Console.ReadKey();
            }
        }

        public object Clone()
        {
            SquareMatrix Result = new SquareMatrix(this.MatrixSize);
            Result.MatrixSize = this.MatrixSize;
            for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ++ColumnIndex)
                {
                    Result[RowIndex, ColumnIndex] = this[RowIndex, ColumnIndex];
                }
            }
            return Result;
        }

        public double this[int RowIndex, int ColumnIndex]
        {
            get { return UserMatrix[RowIndex, ColumnIndex]; }
            set { UserMatrix[RowIndex, ColumnIndex] = value; }
        }

        public int GetSize() => MatrixSize;

        private static SquareMatrix MatrixDecompose(SquareMatrix CurrentMatrix, out int[] PermutationArray,
            out int Toggle)
        {
            // L - ?; U - ?; Permutation array - ?
            int Length = CurrentMatrix.GetSize();
            SquareMatrix Result = CurrentMatrix.Clone() as SquareMatrix;
            PermutationArray = new int[Length];
            for (int Element = 0; Element < Length; ++Element)
            {
                PermutationArray[Element] = Element;
            }
            Toggle = 1;

            for (int MainElementCoordinates = 0; MainElementCoordinates < Length - 1; 
                ++MainElementCoordinates) 
            {
                double ColumnMax = Math.Abs(
                    Result[MainElementCoordinates, MainElementCoordinates]);
                int PermRow = MainElementCoordinates;
                for (int RowIndex = MainElementCoordinates + 1; 
                    RowIndex < Length; ++RowIndex)
                {
                    if (Result[RowIndex, MainElementCoordinates] > ColumnMax)
                    {
                        ColumnMax = Result[RowIndex, MainElementCoordinates];
                        PermRow = RowIndex;
                    }
                }
                
                if (PermRow != MainElementCoordinates)
                {
                    for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                    {
                        (Result[PermRow, ColumnIndex], Result[MainElementCoordinates, ColumnIndex]) =
                            (Result[MainElementCoordinates, ColumnIndex], Result[PermRow, ColumnIndex]); //кортеж
                    }
                    (PermutationArray[MainElementCoordinates], PermutationArray[PermRow]) = 
                        (PermutationArray[PermRow], PermutationArray[MainElementCoordinates]); //тож кортеж
                    Toggle = -Toggle;
                }

                if (Math.Abs(Result[MainElementCoordinates, MainElementCoordinates]) < 1.0E-20)
                    return null;
                for (int RowIndex = MainElementCoordinates + 1; RowIndex < Length; ++ RowIndex)
                {
                    Result[RowIndex, MainElementCoordinates] /=
                        Result[MainElementCoordinates, MainElementCoordinates];
                    for (int ColumnIndex = MainElementCoordinates + 1; ColumnIndex < Length;
                        ++ColumnIndex)
                    {
                        Result[RowIndex, ColumnIndex] -= Result[RowIndex, MainElementCoordinates] *
                            Result[MainElementCoordinates, ColumnIndex];
                    }
                }
            }
            return Result;
        }

        private static double[] ProblemSolver(SquareMatrix luMatrix, double[] ResultVector)
        {
            //LU * x = b; x - ?
            int Length = luMatrix.GetSize();
            double[] SolutionVector = new double[Length];
            ResultVector.CopyTo(SolutionVector, 0);
            for (int RowIndex = 1; RowIndex < Length; ++RowIndex)
            {
                double Summ = SolutionVector[RowIndex];
                for (int ColumnIndex = 0; ColumnIndex < RowIndex; ++ColumnIndex)
                {
                    Summ -= luMatrix[RowIndex, ColumnIndex] * SolutionVector[ColumnIndex];
                }
                SolutionVector[RowIndex] = Summ;
            }
            SolutionVector[Length - 1] /= luMatrix[Length - 1, Length - 1];
            for (int RowIndex = Length - 2; RowIndex >= 0; --RowIndex)
            {
                double Summ = SolutionVector[RowIndex];
                for (int ColumnIndex = RowIndex + 1; ColumnIndex < Length;
                    ++ColumnIndex)
                {
                    Summ -= luMatrix[RowIndex, ColumnIndex] * SolutionVector[ColumnIndex];
                }
                SolutionVector[RowIndex] = Summ / luMatrix[RowIndex, RowIndex];
            }
            return SolutionVector;
        }

        public SquareMatrix MatrixInverse()
        {
            int Length = this.GetSize();
            SquareMatrix Result = this.Clone() as SquareMatrix;
            SquareMatrix luMatrix = MatrixDecompose(this, out int[] Perm, out int Toggle);
            if (luMatrix == null)
            {
                throw new Exception("Нельзя найти обратную матрицу");
            }
            double[] b = new double[Length];
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    if (RowIndex == Perm[ColumnIndex])
                    {
                        b[ColumnIndex] = 1.0;
                    } 
                    else 
                    {
                        b[ColumnIndex] = 0.0;
                    }
                }
                double[] x = ProblemSolver(luMatrix, b);
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Result[ColumnIndex, RowIndex] = x[ColumnIndex];
                }
            }
            return Result;
        }

        public double Determinant()
        {
            SquareMatrix luMatrix = MatrixDecompose(this, out int[] Perm, out int Toggle);
            if (luMatrix == null)
            {
                throw new Exception("Нельзя посчитать определитель матрицы");
            }
            double Result = Toggle;
            for (int MainElementCoordinates = 0; MainElementCoordinates < luMatrix.GetSize();
                ++MainElementCoordinates)
            {
                Result *= luMatrix[MainElementCoordinates, MainElementCoordinates];
            }
            return Result;
        }

        public override string ToString()
        {
            int Length = this.GetSize();
            string Result = "";
            for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                {
                    Result += this[RowIndex, ColumnIndex] + " ";
                }
            }
            return Result;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            SquareMatrix AnotherMatrix = ((SquareMatrix)obj).Clone() as SquareMatrix;
            if (AnotherMatrix != null)
            {
                return this.Determinant().CompareTo(AnotherMatrix.Determinant());
            }
            else
            {
                throw new ArgumentException("Один из элементов не матрица!");
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            } 
            else
            {
                SquareMatrix AnotherMatrix = ((SquareMatrix) obj).Clone() as SquareMatrix;
                if (this.GetSize() == AnotherMatrix.GetSize())
                {
                    int Length = this.GetSize();
                    for (int RowIndex = 0; RowIndex < Length; ++RowIndex)
                    {
                        for (int ColumnIndex = 0; ColumnIndex < Length; ++ColumnIndex)
                        {
                            if (this[RowIndex, ColumnIndex] != AnotherMatrix[RowIndex, ColumnIndex])
                                return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
        }

        public static explicit operator double(SquareMatrix Matrix)
        {
            return Matrix.Determinant();
        }

        public static implicit operator SquareMatrix(int InputMatrixSize)
        {
            return new SquareMatrix(InputMatrixSize);
        }

        public override int GetHashCode() => Convert.ToInt32(this.ToString());
   
        public static SquareMatrix operator +(SquareMatrix CurrentMatrix) => CurrentMatrix;

        public static SquareMatrix operator +(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
        {
            SquareMatrix NewMatrix = SecondMatrix.Clone() as SquareMatrix;
            
            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] + 
                        SecondMatrix[RowIndex, ColumnIndex];
                }
            }
            return NewMatrix;
        }

        public static SquareMatrix operator +(SquareMatrix FirstMatrix, int Number)
        {
            SquareMatrix NewMatrix = FirstMatrix.Clone() as SquareMatrix;
 
            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] + Number;
                }
            }
            return NewMatrix;
        }

        public static SquareMatrix operator +(int Number, SquareMatrix SecondMatrix)
        {
            SquareMatrix NewMatrix = SecondMatrix.Clone() as SquareMatrix;

            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = Number + SecondMatrix[RowIndex, ColumnIndex];
                }
            }
            return NewMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix FirstMatrix, int Number)
        {
            SquareMatrix NewMatrix = FirstMatrix.Clone() as SquareMatrix;
            for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] * Number;
                }
            }
            return NewMatrix;
        }

        public static SquareMatrix operator *(int Number, SquareMatrix FirstMatrix)
        {
            SquareMatrix NewMatrix = FirstMatrix.Clone() as SquareMatrix;
            for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] * Number;
                }
            }
            return NewMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
        {
            SquareMatrix NewMatrix = FirstMatrix.Clone() as SquareMatrix;
            double CurrentElement = 0.0;
            for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize();
                    ++ColumnIndex)
                {
                    for (int MatrixElement = 0; MatrixElement < FirstMatrix.GetSize(); 
                        ++MatrixElement)
                    {
                        CurrentElement += FirstMatrix[RowIndex, MatrixElement] * 
                            SecondMatrix[MatrixElement, ColumnIndex];
                    }
                    NewMatrix[RowIndex, ColumnIndex] = CurrentElement;
                    CurrentElement = 0;
                }
            }
            return NewMatrix;
        }

        public static bool operator <=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => FirstMatrix.Determinant() <= SecondMatrix.Determinant();
        
        public static bool operator >=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => FirstMatrix.Determinant() >= SecondMatrix.Determinant();
        
        public static bool operator <(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => FirstMatrix.Determinant() < SecondMatrix.Determinant();
    
        public static bool operator >(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => FirstMatrix.Determinant() > SecondMatrix.Determinant();

        public static bool operator ==(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => FirstMatrix.Equals(SecondMatrix);
        
        public static bool operator !=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) => !(FirstMatrix.Equals(SecondMatrix));

        public static bool operator true(SquareMatrix CurrentMatrix) => CurrentMatrix.GetSize() != 0;

        public static bool operator false(SquareMatrix CurrentMatrix) => CurrentMatrix.GetSize() == 0;
    }
}