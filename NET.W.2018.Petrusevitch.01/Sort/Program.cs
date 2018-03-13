using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MergedSort;
using QuickSort;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int START_POSITION = 0;

            while (true)
            {
                int[] arr = new[] { 50, 80, 35, 1382, 0, -20, 0, 98,98 };
                Console.WriteLine("Unsorted Array");
                foreach (var i in arr)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Select sort:");
                Console.WriteLine("1-QuickSort");
                Console.WriteLine("2-MergedSort");
                int x = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                switch (x)
                {
                    case 1:
                        Sorting.QuickSortMethod(arr, START_POSITION, arr.Length - 1);
                        break;
                    case 2:
                        arr = MergedSorting.Sort(arr);
                        break;
                }

                Console.WriteLine("Sorted Array");
                foreach (var i in arr)
                {
                    Console.WriteLine(i);
                }


                Console.WriteLine("++++++++++++++++++");

            }
        }
    }
}
