﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Polinom.Tests
{
    [TestFixture]
    public class PolinomTest
    {
        [TestCase(1, 2, 3, ExpectedResult = "1x^3+2x^2+3x^1")]
        [TestCase(15, -12, 19, 48, ExpectedResult = "15x^4+(-12)x^3+19x^2+48x^1")]
        public string Polinom_ToString_Test(params double[] coeffArray)
        {
            Polynomial polinom = new Polynomial(coeffArray);
            return polinom.ToString();
        }

        //только полиномы одной степени!!!!
        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "1x^4+5x^3+5x^2+11x^1")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "5x^4+(-6)x^3+5x^2+21x^1")]
        public string Polinoms_AddOperatorOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first + second).ToString();
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "(-1)x^4+1x^3+(-1)x^2+(-9)x^1")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "(-5)x^4+18x^3+(-1)x^2+1x^1")]
        public string Polinoms_SubstractionOperatorOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first - second).ToString();
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "3x^7+8x^6+14x^5+38x^4+23x^3+10x^2+0x^1")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "30x^7+(-62)x^6+49x^5+(-66)x^4+53x^3+110x^2+0x^1")]
        public string Polinoms_MultiOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first * second).ToString();
        }
    }
}
