using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass.Tests
{
    using static MatrixExtension;

    using NUnit.Framework;

    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public void CreateSquereMatrix()
        {
            int size = 3;
            var valueInt = 1;
            var valueChar = 'A';
            var matrixIntSquere = new SquereMatrix<int>(size, valueInt);
            var matrixCharSquere = new SquereMatrix<char>(size, valueChar);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Assert.That(valueInt, Is.EqualTo(matrixIntSquere[i, j]));
                    Assert.That(valueChar, Is.EqualTo(matrixCharSquere[i, j]));
                }
            }

            var checkInt = CheckMatrix(matrixIntSquere);
            var checkChar = CheckMatrix(matrixCharSquere);
            Assert.IsTrue(checkInt);
            Assert.IsTrue(checkChar);
        }

        [Test]
        public void CreateDiagonalMatrix()
        {
            int size = 3;
            int valueInt = 1;
            int defaultDiagonalInt = 2;
            var valueChar = 'A';
            var defaultDiagonalChar = 'B';
            var matrixIntDiagnal = new DiagonalMatrix<int>(size, valueInt, defaultDiagonalInt);
            var matrixCharDiagonal = new DiagonalMatrix<char>(size, valueChar, defaultDiagonalChar);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        Assert.That(matrixIntDiagnal[i, j], Is.EqualTo(valueInt));
                        Assert.That(matrixCharDiagonal[i, j], Is.EqualTo(valueChar));
                    }
                }
            }

            var checkInt = CheckMatrix(matrixIntDiagnal);
            var checkChar = CheckMatrix(matrixCharDiagonal);
            Assert.IsTrue(checkInt);
            Assert.IsTrue(checkChar);
        }

        [Test]
        public void CreateSymetrickMatrix()
        {
            int size = 3;
            var valueInt = 1;
            var valueChar = 'A';
            var matrixIntSquere = new SymetrMatrix<int>(size, valueInt);
            var matrixCharSquere = new SymetrMatrix<char>(size, valueChar);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Assert.That(valueInt, Is.EqualTo(matrixIntSquere[i, j]));
                    Assert.That(valueChar, Is.EqualTo(matrixCharSquere[i, j]));
                }
            }

            var checkInt = CheckMatrix(matrixIntSquere);
            var checkChar = CheckMatrix(matrixCharSquere);
            Assert.IsTrue(checkInt);
            Assert.IsTrue(checkChar);
        }

        [Test]
        public void SumMatrixTest()
        {
            int size = 3;
            var matrix1 = new SquereMatrix<int>(size, 1);
            var matrix2 = new SquereMatrix<int>(size, 2);

            var result = SumMatrix(matrix1, matrix2);

            var expected = new SquereMatrix<int>(size, 3);

            Assert.IsTrue(result.Equals(expected));
        }

        [TestCase(-1, 0)]
        [TestCase(0, 12)]
        public void IndexExeptionTest(int i, int j)
        {
            int size = 3;
            var matrix = new SquereMatrix<int>(size, 1);
            Assert.Throws<ArgumentException>(() => matrix[i, j] = 1);
            Assert.Throws<ArgumentException>(() =>
                {
                    int p = matrix[i, j];
                });
        }

        [Test]
        public void IndexExceptionDiagonalMatrixTest()
        {
            int size = 3;
            int i = 1;
            int j = 2;

            var matrix = new DiagonalMatrix<int>(size, 1, 3);

            Assert.Throws<ArgumentException>(() => matrix[i, j] = 1);
        }

        [Test]
        public void SumExeptionTest()
        {
            int size1 = 3;
            int size2 = 5;
            var matrix1 = new SquereMatrix<int>(size1, 1);
            var matrix2 = new SquereMatrix<int>(size2, 2);

            Assert.Throws<ArgumentException>(() => SumMatrix(matrix1, matrix2));
            Assert.Throws<ArgumentNullException>(() => SumMatrix(matrix1, null));
        }

        [Test]
        public void EventTest()
        {
            int size1 = 3;
            var matrix1 = new SquereMatrix<int>(size1, 1);
            matrix1.ChangeValue += MatrixEventMethods.EventMethods;
            matrix1[1, 1] = 4;
        }
    }
}
