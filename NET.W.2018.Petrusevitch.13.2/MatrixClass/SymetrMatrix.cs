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

    /// <summary>
    /// The symetric matrix class.
    /// </summary>
    /// <typeparam name="T">generic type
    /// </typeparam>
    public class SymetrMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymetrMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">
        /// The size of array
        /// </param>
        /// <param name="defaulValue">
        /// The defaul value from array.
        /// </param>
        public SymetrMatrix(int size, T defaulValue)
        {
            this.matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.matrix[i, j] = defaulValue;
                }
            }
        }

        public int Size { get; }

        /// <summary>
        /// The fill sym matrix by array.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="inputArray">
        /// The input array.
        /// </param>
        /// <exception cref="ArgumentNullException"> null checked.
        /// </exception>
        /// <exception cref="ArgumentException">checked on quadric
        /// </exception>
        public void FillSymMatrixByArray(int size, T[,] inputArray)
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

            for (int i = 1; i < this.Size - 1; i++)
            {
                for (int j = 1; j < this.Size - 1; j++)
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

        public override T this[int i, int j]
        {
            get
            {
                if (i > this.matrix.GetLength(0) - 1 || j > this.matrix.GetLength(0) - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException($"incorect index");
                }

                return this.matrix[i, j];
            }

            set
            {
                if (i > this.matrix.GetLength(0) - 1 || j > this.matrix.GetLength(0) - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException($"incorect index");
                }

                this.OnChangeValue(new MatrixArgs<T>(i, j, value));
                this.OnChangeValue(new MatrixArgs<T>(j, i, value));

                this.matrix[j, i] = value;

                this.matrix[i, j] = value;
            }
        }
    }
}