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
    public class SquereMatrix<T> : Matrix<T>
    {
        public SquereMatrix(int size)
        {
            this.matrix = new T[size, size];
        }
    }
}