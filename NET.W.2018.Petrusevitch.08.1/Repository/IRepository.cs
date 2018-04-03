namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// The add book.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation
        /// </returns>
        bool AddBook(Book book);

        /// <summary>
        /// The remove book.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation
        /// </returns>
        bool RemoveBook(Book book);

        /// <summary>
        /// Get book list
        /// </summary>
        /// <returns>
        /// The <see cref="List"/> book list.
        /// </returns>
        List<Book> GetAllBooks();

    }
}