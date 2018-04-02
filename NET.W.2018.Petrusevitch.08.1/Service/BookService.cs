namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Repository;

    public class BookService : IService
    {
        private readonly IRepository bookListStorage;

        public BookService(string path)
        {
            this.bookListStorage = new BinnaryRepository(path);
        }

        public bool AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            return this.bookListStorage.AddBook(book);
        }

        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            return this.bookListStorage.RemoveBook(book);
        }

        public IEnumerable<Book> FindByTags(Predicate<Book> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException();
            }

            return this.bookListStorage.GetAllBooks().FindAll(filter);
        }

        public IEnumerable<Book> SortByTags()
        {
            var result = this.bookListStorage.GetAllBooks();
            result.Sort();
            return result;
        }
    }
}
