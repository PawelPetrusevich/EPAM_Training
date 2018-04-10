namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Serilog;

    /// <summary>
    /// Repository for binnary file
    /// </summary>
    public class BinnaryRepository : IRepository
    {
        private readonly string filePath;

        public BinnaryRepository(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// The add book to file.
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> operation confirmation
        /// </returns>
        /// <exception cref="ArgumentNullException">check for null
        /// </exception>
        public bool AddBook(Book book)
        {
            if (book == null)
            {
                Log.Error(new ArgumentException(), $"{nameof(book)} is null");
                throw new ArgumentNullException();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(this.filePath, FileMode.Append)))
            {
                writer.Write(book.ISBN);
                writer.Write(book.Autorth);
                writer.Write(book.BookName);
                writer.Write(book.Year);
                writer.Write(book.Price);
                writer.Write(book.ListCount);
                Log.Information($"{nameof(book)} add to Binarry repository");
                return true;
            }
        }

        /// <summary>
        /// The remove book from file
        /// </summary>
        /// <param name="book">
        /// The book.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>operation confirmation
        /// </returns>
        /// <exception cref="ArgumentNullException"> chek for null
        /// </exception>
        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
                Log.Error(new ArgumentNullException(), $"{nameof(book)} is null");
                throw new ArgumentNullException();
            }

            var books = this.GetAllBooks();
            bool result = books.Remove(book);
            if (result)
            {
                foreach (var item in books)
                {
                    this.AddBook(item);
                }

                Log.Information($"{nameof(book)} was deleted");
            }
            else
            {
                Log.Information($"{nameof(book)} not found");
            }

            return result;
        }

        /// <summary>
        /// Get book list
        /// </summary>
        /// <returns>
        /// The <see cref="List"/> book list from file
        /// </returns>
        public List<Book> GetAllBooks()
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(this.filePath, FileMode.Open)))
            {
                var books = new List<Book>();
                while (reader.PeekChar() > -1)
                {
                    var isbn = reader.ReadInt32();
                    var author = reader.ReadString();
                    var bookName = reader.ReadString();
                    var year = reader.ReadInt32();
                    var price = reader.ReadDecimal();
                    var listCount = reader.ReadInt32();
                    books.Add(new Book
                    {
                        ISBN = isbn,
                        Autorth = author,
                        BookName = bookName,
                        Year = year,
                        Price = price,
                        ListCount = listCount
                    });
                }

                return books;
            }
        }
    }
}
