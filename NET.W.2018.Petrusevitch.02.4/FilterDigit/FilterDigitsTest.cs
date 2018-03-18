using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FilterDigit
{
    [TestFixture]
    public class FilterDigitsTest
    {
        [TestCase(7, 1, 2, 3, 7, 4, 5, 6, 7, 68, 69, 70, 15, 17, ExpectedResult = new int[] { 7, 70, 17 })]
        [TestCase(1, 20, 18, 56, 31, 98, 11, ExpectedResult = new int[] { 18, 31, 11 })]
        [TestCase(0, 0, 15, 50, 05, 18, 91, ExpectedResult = new int[] { 0, 50 })]
        [TestCase(2, 20, 15, 52, 50, 05, 62, 84, 18, 91, ExpectedResult = new int[] { 20,52,62 })]
        [TestCase(3, 20, 15, 52, 50, 05,33, 62, 84, 18, 91, ExpectedResult = new int[] { 33 })]
        public int[] AlgoritmTest(int filterNumber, params int[] numberArray)
        {
            return Algoritm.Filter(filterNumber, numberArray);
        }
    }
}
