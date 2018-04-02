namespace Repository
{
    using System;

    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public Book()
        {
        }

        public Book(string autorth, string bookName, int isbn, int year, int listCount, decimal price)
        {
            this.Autorth = autorth;
            this.BookName = bookName;
            this.ISBN = isbn;
            this.ListCount = listCount;
            this.Year = year;
            this.Price = price;
        }

        public int ISBN { get; set; }

        public string Autorth { get; set; }

        public string BookName { get; set; }

        public int Year { get; set; }

        public int ListCount { get; set; }

        public decimal Price { get; set; }



        public static bool operator ==(Book lhs, Book rhs)
        {
            if (object.ReferenceEquals(rhs, null))
            {
                return object.ReferenceEquals(lhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            if (object.ReferenceEquals(rhs, null))
            {
                return object.ReferenceEquals(lhs, null);
            }

            return !lhs.Equals(rhs);
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

            if (this.Autorth == other.Autorth && this.BookName == other.BookName && this.Year == other.Year)
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

        public override string ToString()
        {
            return this.BookName;
        }
    }
}