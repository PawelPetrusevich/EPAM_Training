// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" BookTests.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BookService
//  Project: BookService.Tests
//  Filename: BookTests.cs
//  Created day: 05.04.2018    23:18
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace BookService.Tests
{
    using System;

    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using Repository;

    [TestFixture]
    public class BookTests
    {
        [TestCase("N", ExpectedResult = "C# 4.0")]
        [TestCase("NA", ExpectedResult = "C# 4.0, Шилд")]
        [TestCase("NAY", ExpectedResult = "C# 4.0, Шилд, 2010")]
        [TestCase("NAYL", ExpectedResult = "C# 4.0, Шилд, 2010, 468")]
        [TestCase("NAYLI", ExpectedResult = "C# 4.0, Шилд, 2010, 468, 1")]
        [TestCase("NAYLIP", ExpectedResult = "C# 4.0, Шилд, 2010, 468, 1, 280,00 ₽")]
        public string BookToStringTest(string format)
        {
            Book book = new Book("Шилд", "C# 4.0", 1, 2010, 468, 280);
            return book.ToString(format);
        }

        [Test]
        public void BookToStringExceptionString()
        {
            Book book = new Book("Шилд", "C# 4.0", 1, 2010, 468, 280);
            Assert.Throws<ArgumentException>(() => book.ToString("PD"));
        }

        [Test]
        public void BookFormatterNPTest()
        {
            Book book = new Book("Шилд", "C# 4.0", 1, 2010, 468, (decimal)280.8954);
            var result = string.Format(new BookFormat(), "{0:NP}", book);
            var expected = "Book name: C# 4.0. Book price:280,895";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BookFormatterINTest()
        {
            Book book = new Book("Шилд", "C# 4.0", 123456, 2010, 468, (decimal)280.8954);
            var result = string.Format(new BookFormat(), "{0:IN}", book);
            var expected = "ISBN: 123456. Book name:C# 4.0";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void BookFormatterNoBookTest()
        {
            Book book = new Book("Шилд", "C# 4.0", 123456, 2010, 468, (decimal)280.8954);
            Assert.Throws<ArgumentException>(() => string.Format(new BookFormat(), "{0:IN}", new int()));
        }

        [Test]
        public void BookFormatterInvalidFormatTest()
        {
            Book book = new Book("Шилд", "C# 4.0", 123456, 2010, 468, (decimal)280.8954);
            var result = string.Format(new BookFormat(), "{0:NG}", book);
            var expected = "NG is invalid format";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}