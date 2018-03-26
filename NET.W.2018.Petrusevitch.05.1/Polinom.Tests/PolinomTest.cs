using NUnit.Framework;

namespace Polinom.Tests
{
    [TestFixture]
    public class PolinomTest
    {
        [TestCase(1, 2, 3, ExpectedResult = "1x^2+2x^1+3")]
        [TestCase(15, -12, 19, 48, ExpectedResult = "15x^3+(-12)x^2+19x^1+48")]
        public string Polinom_ToString_Test(params double[] coeffArray)
        {
            Polynomial polinom = new Polynomial(coeffArray);
            return polinom.ToString();
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "1x^3+5x^2+5x^1+11")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "5x^3+(-6)x^2+5x^1+21")]
        public string Polinoms_AddOperatorOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first + second).ToString();
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "(-1)x^3+1x^2+(-1)x^1+(-9)")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "(-5)x^3+18x^2+(-1)x^1+1")]
        public string Polinoms_SubstractionOperatorOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first - second).ToString();
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3, 10 }, ExpectedResult = "3x^6+8x^5+14x^4+38x^3+23x^2+10x^1+0")]
        [TestCase(new double[] { 6, 2, 11 }, new double[] { 5, -12, 3, 10 }, ExpectedResult = "30x^6+(-62)x^5+49x^4+(-66)x^3+53x^2+110x^1+0")]
        public string Polinoms_MultiOverload_Test(double[] firstArray, double[] secondArray)
        {
            Polynomial first = new Polynomial(firstArray);
            Polynomial second = new Polynomial(secondArray);
            return (first * second).ToString();
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 })]
        [TestCase(new double[] { 1, 2, 0 }, new double[] { 1, 2, 0 })]
        [TestCase(new double[] { 1, 2, 50, 80 }, new double[] { 1, 2, 50, 80 })]
        public void Polinoms_EqualsOverload_Test(double[] first, double[] second)
        {
            Polynomial firstPoly = new Polynomial(first);
            Polynomial secondPoly = new Polynomial(second);
            Assert.True(firstPoly.Equals(secondPoly));
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 })]
        [TestCase(new double[] { 1, 2, 0 }, new double[] { 1, 2, 0 })]
        [TestCase(new double[] { 1, 2, 50, 80 }, new double[] { 1, 2, 50, 80 })]
        public void Polinoms_EqualsOperatorOverload_Test(double[] first, double[] second)
        {
            Polynomial firstPoly = new Polynomial(first);
            Polynomial secondPoly = new Polynomial(second);
            Assert.True(firstPoly == secondPoly);
            Assert.False(firstPoly != secondPoly);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 90 }, new double[] { 1, 2, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 50, 80 }, new double[] { 1, 2, 50, 80 }, ExpectedResult = true)]
        public bool Polinoms_GetHashcodeOverload_Test(double[] first, double[] second)
        {
            Polynomial firstPoly = new Polynomial(first);
            Polynomial secondPoly = new Polynomial(second);
            return firstPoly.GetHashCode() == secondPoly.GetHashCode();
        }
    }
}
