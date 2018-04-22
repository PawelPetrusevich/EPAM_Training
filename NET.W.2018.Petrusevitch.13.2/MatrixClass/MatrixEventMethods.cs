// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" MatrixEventMethods.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: MatrixClass
//  Project: MatrixClass
//  Filename: MatrixEventMethods.cs
//  Created day: 22.04.2018    16:38
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace MatrixClass
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    /// <summary>
    /// class with methods
    /// </summary>
    public class MatrixEventMethods
    {
        /// <summary>
        /// methods for test event
        /// </summary>
        /// <typeparam name="T">generic param</typeparam>
        /// <param name="sender">sender objecr</param>
        /// <param name="e">params for event</param>
        public static void EventMethods<T>(object sender, MatrixArgs<T> e)
        {
            MessageBox.Show($"Value on position [{e.PositionI}, {e.PositionJ}] change value on {e.Value}");
            Console.WriteLine($"Value on position [{e.PositionI}, {e.PositionJ}] change value on {e.Value}");
        }
    }
}