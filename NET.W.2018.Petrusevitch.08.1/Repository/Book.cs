namespace Repository
{
    using System;

    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public int ISBN { get; set; }

        public string Autorth { get; set; }

        public string BookName { get; set; }

        public int Year { get; set; }

        public int ListCount { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return this.BookName;
        }

        public static bool operator ==(Book lhs, Book rhs)
        {
            return lhs.Autorth == rhs.Autorth && lhs.BookName == rhs.BookName && lhs.Year == rhs.Year;
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs.Autorth == rhs.Autorth && lhs.BookName == rhs.BookName && lhs.Year == rhs.Year);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return new { this.ISBN, this.BookName, this.Price, this.Autorth, this.ListCount, this.Year }
                    .GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (this.ISBN == other.ISBN)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            return this.Price.CompareTo(other.Price);

        }
    }
}