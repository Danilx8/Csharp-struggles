using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Third_Laba
{
    internal class Matrix: Prototype
    {
        private static int MatrixSize;
        private readonly double[,] UserMatrix = new double[MatrixSize, MatrixSize];
        
        public Matrix(int MatrixSize) {
            Random Rand = new Random();
            for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ++ColumnIndex)
                {
                    UserMatrix[RowIndex, ColumnIndex] = Rand.Next(0, 100);
                }
            }
        }

        public override Prototype Clone()
        {
            return new Matrix(MatrixSize);
        }

        public double this[int RowIndex, int ColumnIndex]
        {
            get { return UserMatrix[RowIndex, ColumnIndex]; }
            set { UserMatrix[RowIndex, ColumnIndex] = value; }
        }

        public int GetSize() => MatrixSize;

        private static Matrix MatrixDecompose(Matrix CurrentMatrix, out int[] Perm,
            out int Toggle)
        {
            int Length = CurrentMatrix.GetSize();
            Matrix Result = CurrentMatrix.Clone() as Matrix;
            Perm = new int[Length];
            for (int Element = 0; Element < Length; ++Element)
            {
                Perm[Element] = Element;
            }
            Toggle = 1;

            for (int MainElementCoordinates = 0; MainElementCoordinates < Length - 1; 
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
                    (Perm[MainElementCoordinates], Perm[PermRow]) = 
                        (Perm[PermRow], Perm[MainElementCoordinates]); //тож кортеж
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

        public int Determinant(Matrix CurrentMatrix)
        {
            
        }

        public static Matrix operator +(Matrix CurrentMatrix) => CurrentMatrix;

        public static Matrix operator -(Matrix CurrentMatrix)
        {
            for (int RowIndex = 0; RowIndex < CurrentMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < CurrentMatrix.GetSize(); ++ColumnIndex)
                {
                    CurrentMatrix[RowIndex, ColumnIndex] *= -1;
                }
            }
            return CurrentMatrix;
        }

        public static Matrix operator +(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix NewMatrix = SecondMatrix.Clone() as Matrix;
            
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

        public static Matrix operator +(Matrix FirstMatrix, int Number)
        {
            Matrix NewMatrix = FirstMatrix.Clone() as Matrix;
 
            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] + Number;
                }
            }
            return NewMatrix;
        }

        public static Matrix operator +(int Number, Matrix SecondMatrix)
        {
            Matrix NewMatrix = SecondMatrix.Clone() as Matrix;

            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = Number + SecondMatrix[RowIndex, ColumnIndex];
                }
            }
            return NewMatrix;
        }

        public static Matrix operator *(Matrix FirstMatrix, int Number)
        {
            Matrix NewMatrix = FirstMatrix.Clone() as Matrix;
            for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] * Number;
                }
            }
            return NewMatrix;
        }

        public static Matrix operator *(int Number, Matrix FirstMatrix)
        {
            Matrix NewMatrix = FirstMatrix.Clone() as Matrix;
            for (int RowIndex = 0; RowIndex < FirstMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix[RowIndex, ColumnIndex] * Number;
                }
            }
            return NewMatrix;
        }

        public static Matrix operator *(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix NewMatrix = FirstMatrix.Clone() as Matrix;
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

        public static bool operator <(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            bool Difference;
            return Difference;
        }

        public static bool operator >(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            bool Difference;
            return Difference;
        }
    }
}