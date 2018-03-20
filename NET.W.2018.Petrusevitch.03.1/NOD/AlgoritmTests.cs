using System;
using NUnit.Framework;

namespace NOD
{
    [TestFixture]
    public class AlgoritmTests
    {
        [TestCase(45,30,ExpectedResult = 15)]
        [TestCase(-60,45,30,ExpectedResult = 15)]
        [TestCase(15, 5, ExpectedResult = 5)]
        [TestCase(0, 10, 0, ExpectedResult = 10)]
        [TestCase(27, 9, 54, ExpectedResult = 9)]
        [TestCase(30, 15, 45, ExpectedResult = 15)]
        [TestCase(54, 108, 27, ExpectedResult = 27)]
        [TestCase(17, 81, 112, ExpectedResult = 1)]
        [TestCase(30, 15, 90, 45, 135, ExpectedResult = 15)]
        [TestCase(1, 3, 5, 7, 9, 11, 13, 15, ExpectedResult = 1)]
        [TestCase(81, 1, 123, 89346, 2893, 39847, ExpectedResult = 1)]
        [TestCase(750, 450, 325, 1025, 25, 3250, 50, 115, ExpectedResult = 5)]
        public int EuclidAlgoritmTest(params int[] number)
        {
            var result = Euclid.Algoritm(number);
            var time = result.Item2;
            return result.Item1;
        }

        [Test]
        public void EuclidAlgoritmArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Euclid.Algoritm());
        }



        [TestCase(45, 30, ExpectedResult = 15)]
        [TestCase(-60, 45, 30, ExpectedResult = 15)]
        [TestCase(15,5,ExpectedResult = 5)]
        [TestCase(0, 10, 0, ExpectedResult = 10)]
        [TestCase(27, 9, 54, ExpectedResult = 9)]
        [TestCase(30, 15, 45, ExpectedResult = 15)]
        [TestCase(54, 108, 27, ExpectedResult = 27)]
        [TestCase(17, 81, 112, ExpectedResult = 1)]
        [TestCase(30, 15, 90, 45, 135, ExpectedResult = 15)]
        [TestCase(1, 3, 5, 7, 9, 11, 13, 15, ExpectedResult = 1)]
        [TestCase(81, 1, 123, 89346, 2893, 39847, ExpectedResult = 1)]
        [TestCase(750, 450, 325, 1025, 25, 3250, 50, 115, ExpectedResult = 5)]
        public int SteinTest(params int[] number)
        {
            var result = Stein.Algoritm(number);
            var time = result.Item2;
            return result.Item1;
        }

        [Test]
        public void SteinAlgoritmArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Stein.Algoritm());
        }


    }
}