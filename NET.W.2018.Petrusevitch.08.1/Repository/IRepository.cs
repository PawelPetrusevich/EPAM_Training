namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository
    {
        bool AddBook(Book book);

        bool RemoveBook(Book book);

        List<Book> GetAllBooks();

    }
}