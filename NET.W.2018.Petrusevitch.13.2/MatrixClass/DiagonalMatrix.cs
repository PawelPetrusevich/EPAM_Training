// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" DiagonalMatrix.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: MatrixClass
//  Project: MatrixClass
//  Filename: DiagonalMatrix.cs
//  Created day: 19.04.2018    19:37
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace MatrixClass
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int size, T defaulValue)
        {
            this.matrix = new T[size, size];
            for (int i = 0; i < size - 1; i++)
            {
                this.matrix[i, i] = defaulValue;
            }
        }
    }
}