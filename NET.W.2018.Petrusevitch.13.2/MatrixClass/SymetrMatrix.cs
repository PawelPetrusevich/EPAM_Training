// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" SymetrMatrix.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: MatrixClass
//  Project: MatrixClass
//  Filename: SymetrMatrix.cs
//  Created day: 19.04.2018    19:36
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace MatrixClass
{
    using System;

    public class SymetrMatrix<T> : Matrix<T>
    {
        public SymetrMatrix(int size)
        {
            this.matrix = new T[size, size];
            this.Size = size;
        }

        public int Size { get; }



        public void CreatSymMatrix(T[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"{nameof(inputArray)}");
            }

            if (inputArray.GetLength(0) != inputArray.GetLength(1))
            {
                throw new ArgumentException($"{nameof(inputArray)} not squere");
            }

            this.matrix[0, 0] = inputArray[0, 0];
            this.matrix[this.Size - 1, this.Size - 1] = inputArray[inputArray.GetLength(0) - 1, inputArray.GetLength(1) - 1];

            for (int i = 1; i < this.Size - 2; i++)
            {
                for (int j = 1; j < this.Size - 2; j++)
                {
                    if (this.Compresion(inputArray[i, j], inputArray[j, i]) != 0)
                    {
                        throw new ArgumentException($"{nameof(inputArray)} not symetric");
                    }

                    this.matrix[i, j] = inputArray[i, j];
                    this.matrix[j, i] = inputArray[i, j];
                }
            }
        }
    }
}