// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" BySumAscending.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: JaggedArrayAlgoritm
//  Project: JaggedArrayAlgoritm
//  Filename: BySumAscending.cs
//  Created day: 07.04.2018    20:16
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace JaggedArrayAlgoritm.Comparer
{
    using System.Collections.Generic;
    using System.Linq;

    public class JaggedArrayComparer : IJaggedArrayComparer
    {
        public delegate int ComparerDelegate(int[] x, int[] y);

        public int Compare(int[] x, int[] y)
        {
            return this.BySumAscending(x, y);
        }

        public int BySumDescending(int[] lhs, int[] rhs)
        {
            if (lhs.Sum() > rhs.Sum())
            {
                return -1;
            }

            if (lhs.Sum() < rhs.Sum())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ByMinDescending(int[] lhs, int[] rhs)
        {
            if (lhs.Min() > rhs.Min())
            {
                return -1;
            }

            if (lhs.Min() < rhs.Min())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ByMaxDescending(int[] lhs, int[] rhs)
        {
            if (lhs.Max() > rhs.Max())
            {
                return -1;
            }

            if (lhs.Max() < rhs.Max())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int BySumAscending(int[] lhs, int[] rhs)
        {
            if (lhs.Sum() < rhs.Sum())
            {
                return -1;
            }

            if (lhs.Sum() > rhs.Sum())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ByMinAscending(int[] lhs, int[] rhs)
        {
            if (lhs.Min() < rhs.Min())
            {
                return -1;
            }

            if (lhs.Min() > rhs.Min())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int ByMaxAscending(int[] lhs, int[] rhs)
        {
            if (lhs.Max() < rhs.Max())
            {
                return -1;
            }

            if (lhs.Max() > rhs.Max())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}