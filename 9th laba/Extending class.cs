using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLaba
{
    public static class Extending
    {
        public static SquareMatrix TransposeMatrix(this SquareMatrix Matrix)
        {
            SquareMatrix TransposedMatrix = Matrix.Clone() as SquareMatrix;
            for (int RowIndex = 0; RowIndex < Matrix.GetSize(); ++RowIndex)
            {
                for (int ColumnIndex = 0; ColumnIndex < Matrix.GetSize(); ++ColumnIndex)
                {
                    TransposedMatrix[ColumnIndex, RowIndex] = Matrix[RowIndex, ColumnIndex];
                }
            }
            return TransposedMatrix;
        }

        public static double MatrixTrace(this SquareMatrix Matrix)
        {
            double Result = 0.0;
            for (int ElementIndex = 0; ElementIndex < Matrix.GetSize(); ++ElementIndex)
            {
                if (Matrix[ElementIndex, ElementIndex] != Matrix[Matrix.GetSize() - 1 - ElementIndex,
                    Matrix.GetSize() - 1 - ElementIndex])
                {
                    Result += Matrix[ElementIndex, ElementIndex] + Matrix[Matrix.GetSize() - 1 - ElementIndex,
                        Matrix.GetSize() - 1 - ElementIndex];
                }
                else
                {
                    Result += Matrix[ElementIndex, ElementIndex];
                }
            }
            return Result;
        }
    }
}
