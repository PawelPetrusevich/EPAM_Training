using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergedSort
{
    public class MergedSorting
    {
        /// <summary>
        /// Merged sorting method
        /// </summary>
        /// <param name="arr">number array</param>
        /// <returns>sort array</returns>
        public static int[] Sort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            int mid = arr.Length / 2;
            return Merge(Sort(arr.Take(mid).ToArray()), Sort(arr.Skip(mid).ToArray()));
        }

        /// <summary>
        /// sorting array
        /// </summary>
        /// <param name="arr1">first half array</param>
        /// <param name="arr2">second half array</param>
        /// <returns>merged array</returns>
        static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0;
            int b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < merged.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                {
                    if (arr1[a] > arr2[b])
                    {
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        merged[i] = arr1[a++];
                    }
                }
                else
                {
                    if (b < arr2.Length)
                    {
                        merged[i] = arr2[b++];
                    }
                    else
                    {
                        merged[i] = arr1[a++];
                    }
                }
            }

            return merged;
        }
    }
}
