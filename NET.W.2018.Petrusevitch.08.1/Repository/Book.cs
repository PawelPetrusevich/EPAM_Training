namespace Repository
{
    using System;

    using Serilog;

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
            Log.Debug($"{nameof(bookName)} was created");
        }

        public int ISBN { get; set; }

        public string Autorth { get; set; }

        public string BookName { get; set; }

        public int Year { get; set; }

        public int ListCount { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// The == override
        /// </summary>
        /// <param name="lhs">
        /// The first book
        /// </param>
        /// <param name="rhs">
        /// The second book
        /// </param>
        /// <returns>
        /// boolean
        /// </returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// The != override
        /// </summary>
        /// <param name="lhs">
        /// The first book
        /// </param>
        /// <param name="rhs">
        /// The second book
        /// </param>
        /// <returns>
        /// boolean
        /// </returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }

            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// The get hash code override
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> hash code.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return new { this.ISBN, this.BookName, this.Price, this.Autorth, this.ListCount, this.Year }
                    .GetHashCode();
            }
        }

        /// <summary>
        /// The equals override.
        /// </summary>
        /// <param name="obj">
        /// The book
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                Log.Error(new ArgumentNullException(), $"This type is null");
                throw new ArgumentNullException();
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// The equals for Book.
        /// </summary>
        /// <param name="other">
        /// The book
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked
        /// </exception>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                Log.Error(new ArgumentNullException(), $"This type is null");
                throw new ArgumentNullException();
            }

            if (this.Autorth == other.Autorth && this.BookName == other.BookName && this.Year == other.Year)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The comparer book
        /// </summary>
        /// <param name="other">
        /// The book
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comperer number.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checked
        /// </exception>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                Log.Error(new ArgumentNullException(), $"This object is null");
                throw new ArgumentNullException();
            }

            return this.Price.CompareTo(other.Price);
        }

        /// <summary>
        /// The to string override
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>string.
        /// </returns>
        public override string ToString()
        {
            return this.BookName;
        }
    }
}