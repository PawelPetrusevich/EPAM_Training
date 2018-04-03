namespace Service.Comparers
{
    using System.Collections.Generic;
    using System.Linq;

    using Repository;
    public class NameComparer : IComparer<Book>
    {
        private int i = 0;

        public int Compare(Book lhs, Book rhs)
        {
            if (lhs.BookName.ToCharArray()[this.i] == rhs.BookName.ToCharArray()[this.i])
            {
                this.i = this.i + 1;

                return this.Compare(lhs, rhs);
            }

            if (lhs.BookName.ToCharArray()[0] > rhs.BookName.ToCharArray()[0])
            {
                return 1;
            }

            return -1;
        }
    }
}