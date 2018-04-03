namespace Service.Comparers
{
    using System.Collections.Generic;

    using Repository;
    public class PriceComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            //if (lhs == null && rhs == null)
            //{
            //    return -1;
            //}

            if (lhs.Price == rhs.Price)
            {
                return 0;
            }

            if (lhs.Price > rhs.Price)
            {
                return 1;
            }

            return -1;
        }
    }
}