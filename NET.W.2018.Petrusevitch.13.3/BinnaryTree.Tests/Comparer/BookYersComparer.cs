// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" BookYersComparer.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BinnaryTree
//  Project: BinnaryTree.Tests
//  Filename: BookYersComparer.cs
//  Created day: 19.04.2018    16:04
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace BinnaryTree.Tests.Comparer
{
    using System;
    using System.Collections.Generic;

    using Repository;

    public class BookYersComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, null))
            {
                return -1;
            }

            if (ReferenceEquals(y, null))
            {
                return 1;
            }

            if (x.Year < y.Year)
            {
                return 1;
            }

            if (x.Year > y.Year)
            {
                return -1;
            }

            return 0;
        }
    }
}