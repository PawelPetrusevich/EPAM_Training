using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Sorting
    {
        /// <summary>
        /// Quick sort method
        /// </summary>
        /// <param name="arr">number array</param>
        /// <param name="start">start position</param>
        /// <param name="end">end position</param>
        public static void QuickSortMethod(int[] arr, int start, int end)
        {
            int pivot = arr[(end - start) / 2 + start];
            int i = start, j = end;
            while (i <= j)
            {
                while (arr[i] < pivot ) ++i;
                while (arr[j] > pivot ) --j;
                if (i <= j)
                {
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > start) QuickSortMethod(arr, start, j);
            if (i < end) QuickSortMethod(arr, i, end);
        }
    }
}
