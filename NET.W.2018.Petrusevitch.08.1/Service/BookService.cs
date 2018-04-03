namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    using Repository;

    /// <summary>
    /// The book service.
    /// </summary>
    public class BookService : IService
    {
        private readonly string filePath;
        private readonly IRepository bookListStorage;

        public BookService(string path)
        {
            this.filePath = path;
            this.bookListStorage = new BinnaryRepository(path);
        }

        /// <summary>
        /// The add book to repository.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public bool AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (File.Exists(this.filePath))
            {
                if (this.bookListStorage.GetAllBooks().Count > 0)
                {
                    if (this.bookListStorage.GetAllBooks().Contains(book))
                    {
                        return false;
                    }
                }
            }

            if (!File.Exists(this.filePath))
            {
                using (FileStream str = new FileStream(this.filePath, FileMode.Create))
                {
                }
            }

            return this.bookListStorage.AddBook(book);
        }

        /// <summary>
        /// The remove book from file.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            return this.bookListStorage.RemoveBook(book);
        }

        /// <summary>
        /// Find books in books storage.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>book list.
        /// </returns>
        /// <exception cref="ArgumentNullException"> null cheked
        /// </exception>
        public IEnumerable<Book> FindByTags(Predicate<Book> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException();
            }

            return this.bookListStorage.GetAllBooks().FindAll(filter);
        }

        /// <summary>
        /// Sort the book list
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> sorted list.
        /// </returns>
        public IEnumerable<Book> SortByTags(IComparer<Book> comparer)
        {
            var result = this.bookListStorage.GetAllBooks();
            result.Sort(comparer);
            return result;
        }
    }
}
