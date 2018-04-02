namespace BookService.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using NUnit.Framework;

    using Repository;

    using Service;

    [TestFixture]
    public class ServicesTest
    {
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + "BookList.txt";

        [SetUp]
        public void InitialisationsTestMethod()
        {

            IService service = new BookService(this.path);
            service.AddBook(new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38));
            service.AddBook(new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96));
            service.AddBook(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30));
            service.AddBook(new Book("Степанов", "Порт Артур", 4, 1905, 480, (decimal)29.76));
        }

        [TearDown]
        public void ClearTest()
        {
            File.Delete(this.path);
        }

        [Test]
        public void AddBookServiceTest()
        {
            IService service = new BookService(this.path);
            var result = service.AddBook(new Book("Дойл", "Шерлок Холмс", 5, 1960, 80, (decimal)40.81));
            Assert.That(true, Is.EqualTo(result));
        }

    }
}
