// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" Book.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: BinnarySearch
//  Project: BinnarySearch.Test
//  Filename: Book.cs
//  Created day: 12.04.2018    14:03
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace BinnarySearch.Test
{
    /// <summary>
    /// Test class. Not implement IComparable.
    /// </summary>
    public class Book
    {
        public Book(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}