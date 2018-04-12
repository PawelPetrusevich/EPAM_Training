using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinnarySearch
{
    using System.Collections;

    /// <summary>
    /// Class with Binnary search methods
    /// </summary>
    /// <typeparam name="T"> T must implement IComparable
    /// </typeparam>
    public static class SearchExtension<T>
    {
        /// <summary>
        /// The binnary search methods
        /// </summary>
        /// <param name="collection">
        /// List
        /// </param>
        /// <param name="element">
        /// Search element
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentException">IComparable implement
        /// </exception>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        public static bool BinnarySearch(List<T> collection, T element)
        {
            Comparer<T> comparer;
            if (element is IComparable)
            {
                comparer = Comparer<T>.Default;
            }
            else
            {
                throw new ArgumentException($"{nameof(collection)} not implementing IComparable");
            }

            if (collection.Count == 0)
            {
                throw new ArgumentNullException($"{nameof(collection)}");
            }

            collection.Sort();

            return SearchAlgoritm(collection, element, 0, collection.Count() - 1, comparer);
        }

        /// <summary>
        /// The search algoritm methods
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="elemenet">
        /// The search elemenet.
        /// </param>
        /// <param name="left">
        /// The left index
        /// </param>
        /// <param name="right">
        /// The right index
        /// </param>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null cheked
        /// </exception>
        private static bool SearchAlgoritm(List<T> collection, T elemenet, int left, int right, IComparer comparer)
        {
            if (collection.Count == 0)
            {
                throw new ArgumentNullException($"{nameof(collection)}");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)}");
            }

            if (comparer.Compare(elemenet, collection[left]) < 0 || comparer.Compare(elemenet, collection[right]) > 0)
            {
                return false;
            }

            var mid = left + (right - left) / 2;

            if (left > right)
            {
                return false;
            }

            if (comparer.Compare(collection[mid], elemenet) == 0)
            {
                return true;
            }
            else
            {
                if (comparer.Compare(collection[mid], elemenet) > 0)
                {
                    return SearchAlgoritm(collection, elemenet, left, mid, comparer);
                }
                else
                {
                    return SearchAlgoritm(collection, elemenet, mid + 1, right, comparer);
                }
            }
        }
    }
}
