using TenthLaba;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TenthLaba.Tests
{
    [TestClass()]
    public class MatrixTest
    {
        SquareMatrix Matrix;

        [TestInitialize]
        public void TestInitialize()
        {
            Matrix = new SquareMatrix(5);
        }

        [DataTestMethod(), ExpectedException(typeof(InvalidMatrixException))]
        [DataRow(0)]
        [DataRow(double.NaN)]
        [DataRow(8.5)]
        public void SquareMatrixTest(int MatrixSize)
        {
            SquareMatrix Matrix = new SquareMatrix(MatrixSize);
        }

        [TestMethod()]
        public void CloneTest()
        {
            SquareMatrix NewMatrix = Matrix.Clone() as SquareMatrix;
            Assert.AreEqual(Matrix, NewMatrix);
        }

        [TestMethod()]
        public void GetSizeTest()
        {
            Assert.AreEqual(Matrix.GetSize(), 5);
        }

        [TestMethod()]
        public void MatrixInverseTest()
        {
            Assert.IsInstanceOfType(Matrix.MatrixInverse(), typeof(SquareMatrix));
        }

        [TestMethod()]
        public void DeterminantTest()
        {
            Assert.IsNotNull(Matrix.Determinant());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.IsInstanceOfType(Matrix.ToString(), typeof(SquareMatrix));
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Assert.AreEqual(Matrix.CompareTo(Matrix.Clone() as SquareMatrix), 0);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.AreEqual(Matrix.CompareTo(Matrix.Clone() as SquareMatrix), Matrix);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.IsInstanceOfType(Matrix.GetHashCode(), typeof(int));
        }
    }
}