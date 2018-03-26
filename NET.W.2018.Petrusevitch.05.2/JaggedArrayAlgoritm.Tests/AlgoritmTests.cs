namespace JaggedArrayAlgoritm.Tests
{
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

            JaggedArray.UpSumAlgoritm(array);
            JaggedArray.UpSumAlgoritm(array2);

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

            JaggedArray.DownSumAlgoritm(array);
            JaggedArray.DownSumAlgoritm(array2);

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

            JaggedArray.UpMaxElemAlgoritm(array);
            JaggedArray.UpMaxElemAlgoritm(array2);

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

            JaggedArray.DownMaxElemAlgoritm(array);
            JaggedArray.DownMaxElemAlgoritm(array2);

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

            JaggedArray.UpMinElemAlgoritm(array);
            JaggedArray.UpMinElemAlgoritm(array2);

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

            JaggedArray.DownMinElemAlgoritm(array);
            JaggedArray.DownMinElemAlgoritm(array2);

            Assert.AreEqual(result, array);
            Assert.AreEqual(result2, array2);
        }
    }
}
