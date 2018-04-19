// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" PintXComparer.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BinnaryTree
//  Project: BinnaryTree.Tests
//  Filename: PintXComparer.cs
//  Created day: 19.04.2018    16:14
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace BinnaryTree.Tests.Comparer
{
    using System;
    using System.Collections.Generic;

    using BinnaryTree.Tests.Models;
    public class PintXComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X > y.X)
            {
                return 1;
            }

            if (x.X < y.X)
            {
                return -1;
            }

            return 0;
        }
    }
}