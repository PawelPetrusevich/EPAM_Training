using System.Collections.Generic;

namespace Service
{
    using System;

    using Repository;

    public interface IService
    {
        bool AddBook(Book book);

        bool RemoveBook(Book book);

        IEnumerable<Book> FindByTags(Predicate<Book> filter);

        IEnumerable<Book> SortByTags();
    }
}
