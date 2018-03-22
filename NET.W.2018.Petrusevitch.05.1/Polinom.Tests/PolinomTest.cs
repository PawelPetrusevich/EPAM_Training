using System;
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
        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "4x^3+4x^2+4x^1")]
        public string Polinoms_AddOperatorOvveraid_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first + second).ToString();
        }
    }
}
