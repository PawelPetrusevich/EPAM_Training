using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayAlgoritm
{
    using JaggedArrayAlgoritm.Comparer;

    public class JaggedArray
    {
        /// <summary>
        /// The down min elem sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        /// <param name="comparer">Comparer for jaged</param>
        public static void SortJaggedAlgoritm(int[][] jaggedArray, JaggedArrayComparer.ComparerDelegate comparer)
        {
            SortJaggedArray(jaggedArray);

            Array.Sort(jaggedArray, comparer.Invoke);
        }

        /// <summary>
        /// The bubble sort to array
        /// </summary>
        /// <param name="initArray">
        /// The init array.
        /// </param>
        private static void BubbleSort(int[] initArray)
        {
            for (int i = 0; i < initArray.Length; i++)
            {
                for (int j = 0; j < initArray.Length - 1 - i; j++)
                {
                    if (initArray[j] > initArray[j + 1])
                    {
                        Swap(ref initArray[j], ref initArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swap the array element
        /// </summary>
        /// <param name="first">
        /// The first element
        /// </param>
        /// <param name="second">
        /// The second element
        /// </param>
        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// The sort jagged array.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        private static void SortJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                BubbleSort(jaggedArray[i]);
            }
        }

    }
}
