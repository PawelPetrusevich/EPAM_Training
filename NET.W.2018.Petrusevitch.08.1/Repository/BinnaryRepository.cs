namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    public class BinnaryRepository : IRepository
    {
        private readonly string filePath;

        public BinnaryRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public bool AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (File.Exists(this.filePath))
            {
                if (this.GetAllBooks().Count > 0)
                {
                    if (this.GetAllBooks().Contains(book))
                    {
                        return false;
                    }
                }
            }

            if (!File.Exists(this.filePath))
            {
                using (FileStream str = new FileStream(this.filePath, FileMode.Create))
                {
                }
            }



            using (BinaryWriter writer = new BinaryWriter(new FileStream(this.filePath, FileMode.Append)))
            {
                writer.Write(book.ISBN);
                writer.Write(book.Autorth);
                writer.Write(book.BookName);
                writer.Write(book.Year);
                writer.Write(book.Price);
                writer.Write(book.ListCount);
                return true;
            }

        }

        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
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
            }

            return result;

        }

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
