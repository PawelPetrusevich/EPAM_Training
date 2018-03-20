using System;
using InsertNumberAlgoritm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertAlgoritmMSTest
{
    [TestClass]
    public class InsertAlgoritmTest
    {
        [TestMethod]
        [DataRow(15, 15, 0, 0,15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(10, 15, 1, 3, 14)]
        [DataRow(15, 8, 0, 2, 8)]
        public void Insert_Byte_From_I_To_J_Index(int numberSource, int numberIn, int i, int j,int expected)
        {
            Assert.AreEqual(Algoritm.InsertNumber(numberSource, numberIn, i, j),expected);
        }

        [TestMethod]
        [DataRow(10, 15, 1, 33)]
        [DataRow(10, 15, -2, 6)]
        [DataRow(10, 15, 4, 2)]
        [DataRow(10, 15, -9, -15)]
        public void IndexScopeTest(int numberSource, int numberIn, int i, int j)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Algoritm.InsertNumber(numberSource, numberIn, i, j));
        }
    }
}
