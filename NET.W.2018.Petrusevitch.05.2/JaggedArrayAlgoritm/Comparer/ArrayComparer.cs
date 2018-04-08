// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" ArrayComparer.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: JaggedArrayAlgoritm
//  Project: JaggedArrayAlgoritm
//  Filename: ArrayComparer.cs
//  Created day: 08.04.2018    21:02
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace JaggedArrayAlgoritm.Comparer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// jagged array sorting comparer
    /// </summary>
    public class ArrayComparer : IComparer<int[]>
    {
        public delegate int ComparerDelegate(int[] x, int[] y);

        public ComparerDelegate componatorFunc;

        public ArrayComparer(ComparerDelegate componatorFunc)
        {
            this.componatorFunc = componatorFunc;
        }

        public int Compare(int[] x, int[] y)
        {
            return this.componatorFunc(x, y);
        }
    }
}