using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinnaryTree.Tests
{
    using BinnaryTree.Tests.Comparer;
    using BinnaryTree.Tests.Models;

    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using Repository;

    [TestFixture]
    public class BinnaryTreeTest
    {

        Node<int> tree = new Node<int>(null);
        Node<string> treeString = new Node<string>(null);
        Node<Book> treeBooks = new Node<Book>(null);
        Node<Point> treePoints = new Node<Point>(new PintXComparer());

        [SetUp]
        public void Initialization()
        {
            this.tree.Insert(5);
            this.tree.Insert(1);
            this.tree.Insert(0);
            this.tree.Insert(7);
            this.tree.Insert(10);
            this.tree.Insert(9);
            this.tree.Insert(6);

            this.treeBooks.Insert(new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38));
            this.treeBooks.Insert(new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96));
            this.treeBooks.Insert(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30));
            this.treeBooks.Insert(new Book("Степанов", "Порт Артур", 4, 1905, 480, (decimal)29.76));
            this.treeBooks.Insert(new Book("Степанов", "Порт Артур2", 5, 1906, 520, (decimal)29.85));

            this.treeString.Insert("Hello");
            this.treeString.Insert("Pavel");
            this.treeString.Insert("World");
            this.treeString.Insert("End");
            this.treeString.Insert("Exist");
            this.treeString.Insert("C#");

            this.treePoints.Insert(new Point { X = 1, Y = 1 });
            this.treePoints.Insert(new Point { X = 2, Y = 2 });
            this.treePoints.Insert(new Point { X = 3, Y = 3 });
            this.treePoints.Insert(new Point { X = 4, Y = 4 });
            this.treePoints.Insert(new Point { X = 5, Y = 5 });
            this.treePoints.Insert(new Point { X = 6, Y = 6 });
            this.treePoints.Insert(new Point { X = 7, Y = 7 });
        }

        [Test]
        public void BinnaryTreeFindIntTest()
        {
            var result = this.tree.Finde(9);
            var result2 = this.tree.Finde(1);
            var result3 = this.tree.Finde(5);
            var resultNull = this.tree.Finde(90);

            Assert.That(result.Element, Is.EqualTo(9));
            Assert.That(result2.Element, Is.EqualTo(1));
            Assert.That(result3.Element, Is.EqualTo(5));
            Assert.IsNull(resultNull);
        }

        [Test]
        public void BinnaryTreeIntRemoveTest()
        {
            var result = this.tree.Remove(9);

            Assert.IsTrue(result);
            Assert.IsNull(this.tree.Finde(9));
        }

        [Test]
        public void BinnaryTreeIntInOrderTest()
        {
            var result = new List<int>();

            var expected = new List<int> { 0, 1, 5, 6, 7, 9, 10 };

            foreach (var n in this.tree.InOrder())
            {
                result.Add(n);
            }

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BinnaryTreeIntPostOrderTest()
        {
            var result = new List<int>();

            var expected = new List<int> { 0, 1, 6, 9, 10, 7, 5 };

            foreach (var n in this.tree.PostOrder())
            {
                result.Add(n);
            }

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BinnaryTreeIntPreOrderTest()
        {
            var result = new List<int>();

            var expected = new List<int> { 5, 1, 0, 7, 6, 10, 9 };

            foreach (var n in this.tree.PreOrder())
            {
                result.Add(n);
            }

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BinnaryTreeFindString()
        {
            var result = this.treeString.Finde("Pavel");
            var result2 = this.treeString.Finde("Hello");
            var resultNull = this.treeString.Finde("AAAAA");

            var expected = "Pavel";
            var expected2 = "Hello";



            Assert.That(result.Element, Is.EqualTo(expected));
            Assert.That(result2.Element, Is.EqualTo(expected2));
            Assert.IsNull(resultNull);
        }

        [Test]
        public void BinnaryTreeRemoveStringTest()
        {
            var result = this.treeString.Remove("End");

            Assert.IsTrue(result);
            Assert.IsNull(this.treeString.Finde("End"));
        }

        [Test]
        public void BinnaryTreeFindBookTest()
        {
            var result = this.treeBooks.Finde(new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38));
            var result2 = this.treeBooks.Finde(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30));
            var resultNull = this.treeBooks.Finde(new Book("Makfarland", "Big Book CSS", 10, 2017, 290, (decimal)17.28));

            var expected = "Толстой";
            var expected2 = "Кинг";

            Assert.That(result.Element.Autorth, Is.EqualTo(expected));
            Assert.That(result2.Element.Autorth, Is.EqualTo(expected2));
            Assert.IsNull(resultNull);
        }

        [Test]
        public void BinnaryTreeRemoveBookTest()
        {
            var result = this.treeBooks.Remove(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30));

            Assert.IsTrue(result);
            Assert.IsNull(this.treeBooks.Finde(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30)));
        }

        [Test]
        public void BinnaryTreePointFind()
        {
            var result = this.treePoints.Finde(new Point { X = 1, Y = 1 });
            var result2 = this.treePoints.Finde(new Point { X = 2, Y = 2 });
            var resultNull = this.treePoints.Finde(new Point { X = 10, Y = 10 });

            var expected = 1;
            var expected2 = 2;

            Assert.That(result.Element.X, Is.EqualTo(expected));
            Assert.That(result2.Element.X, Is.EqualTo(expected2));
            Assert.IsNull(resultNull);
        }

        [Test]
        public void BinnaryTreePointRemoveTest()
        {
            var result = this.treePoints.Remove(new Point { X = 2, Y = 2 });

            Assert.IsTrue(result);
            Assert.IsNull(this.treePoints.Finde(new Point { X = 2, Y = 2 }));
        }
    }
}
