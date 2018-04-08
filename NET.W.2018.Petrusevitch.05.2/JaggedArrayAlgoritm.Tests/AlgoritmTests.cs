namespace JaggedArrayAlgoritm.Tests
{
    using System.Linq;

    using JaggedArrayAlgoritm.Comparer;

    using NUnit.Framework;

    [TestFixture]
    public class AlgoritmTests
    {
        [Test]
        public void SortUpSummElementTest()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3 };
            result[1] = new[] { 1, 2, 3, 4 };
            result[2] = new[] { 1, 2, 3, 4, 5, 6 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 1, 2, 3 };
            result2[1] = new[] { 1, 5, 10 };
            result2[2] = new[] { 2, 3, 8, 9 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.BySumAscending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.BySumAscending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);

        }



        [Test]
        public void SortDownSummElement()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3, 4, 5, 6 };
            result[1] = new[] { 1, 2, 3, 4 };
            result[2] = new[] { 1, 2, 3 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 2, 3, 8, 9 };
            result2[1] = new[] { 1, 5, 10 };
            result2[2] = new[] { 1, 2, 3 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.BySumDescending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.BySumDescending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }

        [Test]
        public void SortUpMaxElement()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3 };
            result[1] = new[] { 1, 2, 3, 4 };
            result[2] = new[] { 1, 2, 3, 4, 5, 6 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 1, 2, 3 };
            result2[1] = new[] { 2, 3, 8, 9 };
            result2[2] = new[] { 1, 5, 10 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.ByMaxAscending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.ByMaxAscending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }

        [Test]
        public void SortDownMaxElement()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3, 4, 5, 6 };
            result[1] = new[] { 1, 2, 3, 4 };
            result[2] = new[] { 1, 2, 3 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 1, 5, 10 };
            result2[1] = new[] { 2, 3, 8, 9 };
            result2[2] = new[] { 1, 2, 3 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.ByMaxDescending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.ByMaxDescending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }

        [Test]
        public void SortUpMinElement()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3, 4 };
            result[1] = new[] { 1, 2, 3, 4, 5, 6 };
            result[2] = new[] { 1, 2, 3 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 1, 5, 10 };
            result2[1] = new[] { 1, 2, 3 };
            result2[2] = new[] { 2, 3, 8, 9 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.ByMinAscending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.ByMinAscending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }

        [Test]
        public void SortDownMinElement()
        {
            int[][] array = new int[3][];
            array[0] = new[] { 4, 3, 2, 1 };
            array[1] = new[] { 6, 5, 4, 3, 2, 1 };
            array[2] = new[] { 3, 2, 1 };

            int[][] result = new int[3][];
            result[0] = new[] { 1, 2, 3, 4 };
            result[1] = new[] { 1, 2, 3, 4, 5, 6 };
            result[2] = new[] { 1, 2, 3 };

            int[][] array2 = new int[3][];
            array2[0] = new[] { 9, 8, 3, 2 };
            array2[1] = new[] { 10, 1, 5 };
            array2[2] = new[] { 3, 2, 1 };

            int[][] result2 = new int[3][];
            result2[0] = new[] { 2, 3, 8, 9 };
            result2[1] = new[] { 1, 5, 10 };
            result2[2] = new[] { 1, 2, 3 };

            JaggedArray.SortJaggedAlgoritm(array, JaggedArrayComparer.ByMinDescending);
            JaggedArray.SortJaggedAlgoritm(array2, JaggedArrayComparer.ByMinDescending);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }
    }
}
