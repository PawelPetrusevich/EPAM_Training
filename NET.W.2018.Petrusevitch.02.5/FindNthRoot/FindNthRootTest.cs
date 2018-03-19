using System;
using NUnit.Framework;

namespace FindNthRoot
{
    [TestFixture]
    public class FindNthRootTest
    {
        [TestCase(1, 5, 0.00001, ExpectedResult = 1)]
        [TestCase(9, 2, 0.00001, ExpectedResult = 3)]
        [TestCase(100,2,0.00001,ExpectedResult = 10)]
        public double AlgoritmTest(double number, int n, double precesion)
        {
            return FindNthRootAlgoritm.SqrtN(number, n, precesion);
        }

        [TestCase(8, 15, -7)]
        [TestCase(8,15,0.0000000000000000000000000000000000001)]
        [TestCase(8,15,1.1)]
        [Test]
        public void AlgoritmExeptionTest(double number, int n, double precesion)
        {
            Assert.Throws<ArgumentException>(() => FindNthRootAlgoritm.SqrtN(number, n, precesion));
        }
    }
}