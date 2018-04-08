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
        /// <summary>
        /// default compare.
        /// </summary>
        /// <param name="x">
        /// Tfirst array
        /// </param>
        /// <param name="y">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            return this.BySumAscending(x, y);
        }

        /// <summary>
        /// by summ element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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

        /// <summary>
        /// by min element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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

        /// <summary>
        /// by max element descending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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

        /// <summary>
        /// by summ element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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

        /// <summary>
        /// by min element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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

        /// <summary>
        /// by max element ascending array sort
        /// </summary>
        /// <param name="lhs">
        /// first array
        /// </param>
        /// <param name="rhs">
        /// second array
        /// </param>
        /// <returns>
        /// The <see cref="int"/>comparer value.
        /// </returns>
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