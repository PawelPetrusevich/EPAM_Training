﻿using NUnit.Framework;

namespace DoubleToBitArray
{
    [TestFixture]
    public class DoubleToBitArrayTests
    {
        [TestCase(-255.255, ExpectedResult =
            "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult =
            "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult =
            "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult =
            "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult =
            "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult =
            "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult =
            "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(5.0 / 0 - 8.0 / 0, ExpectedResult =
            "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(-0, ExpectedResult = 
            "0000000000000000000000000000000000000000000000000000000000000000")]
        public string AlgoritmTest(double number)
        {
            return DoubleToBitArrayAlgoritm.Algoritm(number);
        }
        
    }
}