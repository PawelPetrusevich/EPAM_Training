using System;
using System.IO;
using System.Linq;
using MergedSort;
using NUnit;
using NUnit.Framework;
using QuickSort;

namespace SortTest
{
    [TestFixture]
    public class SortTests
    {
        int[] arr = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        int[] result = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        [Test]
        public void MergedSortTest()
        {
            arr = MergedSorting.Sort(arr);
            Assert.That(result,Is.EqualTo(arr));
        }

        [Test]
        public void QuickSortTest()
        {
            Sorting.QuickSortMethod(arr,0,arr.Length-1);
            Assert.That(result,Is.EqualTo(arr));
        }
    }

}
