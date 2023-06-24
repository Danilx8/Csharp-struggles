namespace Sixth_Laba
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
                if (Matrix[ElementIndex, ElementIndex] != Matrix[Matrix.GetSize() - ElementIndex - 1,
                    Matrix.GetSize() - ElementIndex - 1])
                {
                    Result += Matrix[ElementIndex, ElementIndex] + Matrix[Matrix.GetSize() - ElementIndex - 1,
                        Matrix.GetSize() - ElementIndex - 1];
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
