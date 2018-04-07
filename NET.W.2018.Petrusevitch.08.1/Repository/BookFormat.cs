// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" BookFormat.cs">
// 
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BookService
//  Project: Repository
//  Filename: BookFormat.cs
//  Created day: 07.04.2018    14:52
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace Repository
{
    using System;

    /// <summary>
    /// custom provider for book.
    /// </summary>
    public class BookFormat : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// IFormatProvider interface implementation.
        /// </summary>
        /// <param name="formatType">format type</param>
        /// <returns>return format</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ICustomFormatter interface implementation
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg">
        /// object as Book
        /// </param>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> result string.
        /// </returns>
        /// <exception cref="ArgumentException">argument cheked
        /// </exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                throw new ArgumentException(nameof(formatProvider));
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "NP";
            }

            Book book = arg as Book;

            if (book == null)
            {
                throw new ArgumentException(nameof(arg));
            }

            if (format == "NP")
            {
                return $"Book name: {book.BookName}. Book price:{book.Price:##.###}";
            }

            if (format == "IN")
            {
                return $"ISBN: {book.ISBN}. Book name:{book.BookName}";
            }

            return $"{format} is invalid format";
        }
    }
}