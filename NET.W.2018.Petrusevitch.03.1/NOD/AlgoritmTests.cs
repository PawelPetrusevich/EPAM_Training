using NUnit.Framework;

namespace NOD
{
    [TestFixture]
    public class AlgoritmTests
    {
        [TestCase(45,30,ExpectedResult = 15)]
        public int EuclidTest(params int[] number)
        {
            return Euclid.Algoritm(number);
        }
        
    }
}