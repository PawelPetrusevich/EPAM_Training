using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsertNumberAlgoritm;
using NUnit.Framework;

namespace InsertNumberAlgoritmTests
{
    [TestFixture]
    public class InsertAlgoritmTest
    {
        [TestCase(15,15,0,0, ExpectedResult = 15)]
        [TestCase(8,15,0,0,ExpectedResult = 9)]
        [TestCase(8,15,3,8,ExpectedResult = 120)]
        [TestCase(10,15,1,3,ExpectedResult = 14)]
        [TestCase(15,8,0,2,ExpectedResult = 8)]
        public int Insert_Byte_From_I_To_J_Index(int numberSource,int numberIn,int i,int j)
        {
           return Algoritm.InsertNumber(numberSource, numberIn, i, j);
            
        }

        [TestCase(10, 15, 1, 33)]
        [TestCase(10, 15, -2, 6)]
        [TestCase(10, 15, 4, 2)]
        [TestCase(10, 15, -9, -15)]
        public void IndexScopeTest(int numberSource,int numberIn,int i,int j)
        {
           Assert.That(()=> Algoritm.InsertNumber(numberSource, numberIn, i, j),Throws.TypeOf<ArgumentException>());
            
        }
    }
}
