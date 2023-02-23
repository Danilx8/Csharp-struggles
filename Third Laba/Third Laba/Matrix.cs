using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_Laba
{
    internal class Matrix
    {
        private static int MatrixSize;
        private Matrix [,] UserMatrix = new Matrix [MatrixSize, MatrixSize];
        
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

        public Matrix()
        {
            Random Rand = new Random();
            MatrixSize = Rand.Next(1, 10);
            for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ++ColumnIndex)
                {
                    UserMatrix[RowIndex, ColumnIndex] = Rand.Next(0, 100);
                }
            }
        }

        public Matrix this[int RowIndex, int ColumnIndex]
        {
            get { return UserMatrix[RowIndex, ColumnIndex]; }
            set { UserMatrix[RowIndex, ColumnIndex] = value; }
        }

        public int GetSize() => MatrixSize;

        public Matrix GetValue(int RowIndex, int ColumnIndex) => UserMatrix[RowIndex, ColumnIndex];
    
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
        }

        public static Matrix operator +(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix NewMatrix = new Matrix(FirstMatrix.GetSize());
            
            for (int RowIndex = 0; RowIndex < NewMatrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < NewMatrix.GetSize(); ++ColumnIndex)
                {
                    NewMatrix[RowIndex, ColumnIndex] = FirstMatrix.GetValue(RowIndex, ColumnIndex) + SecondMatrix.GetValue(RowIndex, ColumnIndex);

                }
            }
            return NewMatrix;
        }
    }
}
