namespace Service
{
    using System;
    using System.Collections.Generic;

    using Repository;

    /// <summary>
    /// The Service interface.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// The add book.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool AddBook(Book book);

        /// <summary>
        /// The remove book.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation.
        /// </returns>
        bool RemoveBook(Book book);

        /// <summary>
        /// Find in book list
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>book list.
        /// </returns>
        IEnumerable<Book> FindByTags(Predicate<Book> filter);

        /// <summary>
        /// Sort book list.
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>Sorted list.
        /// </returns>
        IEnumerable<Book> SortByTags(IComparer<Book> comparer);
    }
}
