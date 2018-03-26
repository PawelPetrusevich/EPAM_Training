using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayAlgoritm
{
    public class JaggedArray
    {
        /// <summary>
        /// The down min elem sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void DownMinElemAlgoritm(int[][] jaggedArray)
        {

            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Min() < jaggedArray[j + 1].Min())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// The up min elem sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void UpMinElemAlgoritm(int[][] jaggedArray)
        {

            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Min() > jaggedArray[j + 1].Min())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// The down max elem sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void DownMaxElemAlgoritm(int[][] jaggedArray)
        {

            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Max() < jaggedArray[j + 1].Max())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// The up max elem sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void UpMaxElemAlgoritm(int[][] jaggedArray)
        {

            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Max() > jaggedArray[j + 1].Max())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// The down sum sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void DownSumAlgoritm(int[][] jaggedArray)
        {
            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Sum() < jaggedArray[j + 1].Sum())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// The up sum sort algoritm.
        /// </summary>
        /// <param name="jaggedArray">
        /// The jagged array.
        /// </param>
        public static void UpSumAlgoritm(int[][] jaggedArray)
        {
            SortJaggedArray(jaggedArray);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (jaggedArray[j].Sum() > jaggedArray[j + 1].Sum())
                    {
                        var temp = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = temp;
                    }
                }
            }
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
