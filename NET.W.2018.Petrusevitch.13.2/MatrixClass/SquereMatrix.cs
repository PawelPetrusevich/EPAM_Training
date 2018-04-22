// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" SquereMatrix.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: MatrixClass
//  Project: MatrixClass
//  Filename: SquereMatrix.cs
//  Created day: 19.04.2018    19:20
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace MatrixClass
{
    /// <summary>
    /// The squere matrix.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class SquereMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquereMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">
        /// The size of array
        /// </param>
        /// <param name="defaultValue">
        /// The default value from array
        /// </param>
        public SquereMatrix(int size, T defaultValue)
        {
            this.matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.matrix[i, j] = defaultValue;
                }
            }
        }
    }
}