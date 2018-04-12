using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinnarySearch.Test
{
    using System.Collections;

    using NUnit.Framework;

    [TestFixture]
    public class BinnarySearchTests
    {
        public static IEnumerable TestsCase
        {
            get
            {
                yield return new TestCaseData(new List<int> { 1, 2, 3, 9, 10, 18, 20 }, 3).Returns(true);
                yield return new TestCaseData(new List<int> { 1, 2, 3, 9, 10, 18, 20 }, 11).Returns(false);
                yield return new TestCaseData(new List<int> { 1, 2, 3, 9, 10, -15, 20 }, -15).Returns(true);
                yield return new TestCaseData(new List<int> { 1, 2, 3, 9, 10, -15, 20 }, 0).Returns(false);
                yield return new TestCaseData(new List<int> { 1, 2, 3, 9, Int32.MaxValue, 18, 20 }, Int32.MaxValue).Returns(true);
                yield return new TestCaseData(new List<int> { 1, 2, 3, Int32.MinValue, 10, 18, 20 }, Int32.MinValue).Returns(true);
                yield return new TestCaseData(new List<string> { "dog", "cat", "animal", "bird" }, "dog").Returns(true);
                yield return new TestCaseData(new List<string> { "dog", "cat", "animal", "bird" }, "fish").Returns(false);
            }
        }

        [Test, TestCaseSource("TestsCase")]
        public bool AlgoritmTest<T>(List<T> collection, T element)
        {
            return SearchExtension<T>.BinnarySearch(collection, element);
        }

        [Test]
        public void AlgoritmExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => SearchExtension<int>.BinnarySearch(new List<int>(), 2));
            Assert.Throws<ArgumentException>(() => SearchExtension<Book>.BinnarySearch(new List<Book> { new Book("name") }, new Book("name")));
        }
    }
}
