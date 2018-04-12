using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibanachi.Test
{
    using System.Collections;

    using NUnit.Framework;

    [TestFixture]
    public class AlgorimTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(60).Returns(new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 });
                yield return new TestCaseData(34).Returns(new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 });
                yield return new TestCaseData(1).Returns(new List<int> { 0, 1, 1 });
                yield return new TestCaseData(9).Returns(new List<int> { 0, 1, 1, 2, 3, 5, 8 });
                yield return new TestCaseData(20).Returns(new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 });
                yield return new TestCaseData(0).Returns(new List<int> { 0 });
            }
        }

        [Test, TestCaseSource("TestCases")]
        public List<int> FibanachAlgoritmTest(int number)
        {
            return Algoritm.FibanachiSearchAlgoritm(number);
        }

        [TestCase(-12)]
        [TestCase(512559681)]
        public void FibanachiAlgoritmExceptionsTets(int number)
        {
            Assert.Throws<ArgumentException>(() => Algoritm.FibanachiSearchAlgoritm(number));
        }
    }
}
