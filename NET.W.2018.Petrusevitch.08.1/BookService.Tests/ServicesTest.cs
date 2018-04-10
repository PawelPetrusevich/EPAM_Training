namespace BookService.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    using Repository;

    using Serilog;
    using Serilog.Events;

    using Service;
    using Service.Comparers;

    [TestFixture]
    public class ServicesTest
    {
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + "BookList.txt";


        [SetUp]
        public void InitialisationsTestMethod()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(LogEventLevel.Information)
                .WriteTo.RollingFile(baseDir + "\\log-{Date}.txt", LogEventLevel.Debug)
                .CreateLogger();

            IService service = new BookService(this.path);
            service.AddBook(new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38));
            service.AddBook(new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96));
            service.AddBook(new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30));
            service.AddBook(new Book("Степанов", "Порт Артур", 4, 1905, 480, (decimal)29.76));
            Log.Debug("Test Run");
        }

        [TearDown]
        public void ClearTest()
        {
            Log.Information("Test comleted");
            File.Delete(this.path);
            Log.CloseAndFlush();
        }

        [Test]
        public void AddBookTest()
        {
            Log.Debug($"{nameof(this.AddBookTest)} run");
            IService service = new BookService(this.path);
            var result = service.AddBook(new Book("Дойл", "Шерлок Холмс", 5, 1960, 80, (decimal)40.81));
            Assert.That(result, Is.True);
        }

        [Test]
        public void AddExistsBookTest()
        {
            Log.Debug($"{nameof(this.AddExistsBookTest)} run");
            IService service = new BookService(this.path);
            var result = service.AddBook(new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96));
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddBookExceptionTest()
        {
            Log.Debug($"{nameof(this.AddBookExceptionTest)} run");
            IService service = new BookService(this.path);
            Assert.Throws<ArgumentNullException>(() => service.AddBook(null));
        }

        [Test]
        public void RemoveBookTest()
        {
            Log.Debug($"{nameof(this.RemoveBookTest)} run");
            IService service = new BookService(this.path);
            var result = service.RemoveBook(new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96));
            Assert.True(result);
        }

        [Test]
        public void RemoveNoExistsBookTest()
        {
            Log.Debug($"{nameof(this.RemoveNoExistsBookTest)} run");
            IService service = new BookService(this.path);
            var result = service.RemoveBook(new Book("Дойл", "Шерлок Холмс", 5, 1960, 80, (decimal)40.81));
            Assert.False(result);
        }

        [Test]
        public void RemoveExceptionTest()
        {
            Log.Debug($"{nameof(this.RemoveExceptionTest)} run");
            IService service = new BookService(this.path);
            Assert.Throws<ArgumentNullException>(() => service.RemoveBook(null));
        }

        [Test]
        public void FindByTagsTest()
        {
            Log.Debug($"{nameof(this.FindByTagsTest)} run");
            IService service = new BookService(this.path);
            var result = service.FindByTags(x => x.Price == 30);
            int expected = 1;
            Assert.That(result.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void SortBookByPriceTest()
        {
            Log.Debug($"{nameof(this.SortBookByPriceTest)} run");

            IService service = new BookService(this.path);

            List<Book> books = new List<Book>
                                   {
                                       new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96),
                                       new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38),
                                       new Book("Степанов", "Порт Артур", 4, 1905, 480, (decimal)29.76),
                                       new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30)
                                   };

            var result = service.SortByTags(new PriceComparer());

            Assert.That(result, Is.EqualTo(books));
        }

        [Test]
        public void SortBookByNameTest()
        {
            Log.Debug($"{nameof(this.SortBookByNameTest)} run");

            IService service = new BookService(this.path);

            List<Book> books = new List<Book>
                                   {
                                       new Book("Толстой", "Война и мир", 1, 1824, 750, (decimal)19.38),
                                       new Book("Кинг", "Оно", 3, 2012, 750, (decimal)30),
                                       new Book("Степанов", "Порт Артур", 4, 1905, 480, (decimal)29.76),
                                       new Book("Кук", "Черный отряд", 2, 2004, 350, (decimal)10.96)
                                   };

            var result = service.SortByTags(new NameComparer());

            Assert.That(result, Is.EqualTo(books));
        }
    }
}
