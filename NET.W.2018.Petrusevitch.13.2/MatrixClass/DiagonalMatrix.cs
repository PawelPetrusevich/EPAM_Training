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
    using System;

    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int size, T defaulValue, T defaultDiagonalValue)
        {
            this.DefaultValue = defaulValue;
            this.matrix = new T[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        this.matrix[i, j] = defaulValue;
                    }
                }

                this.matrix[i, i] = defaultDiagonalValue;
            }
        }

        public T DefaultValue { get; }

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

                if (i != j)
                {
                    throw new ArgumentException("You can not chang value of this position");
                }

                this.OnChangeValue(new MatrixArgs<T>(i, j, value));

                this.matrix[i, j] = value;

            }
        }
    }
}