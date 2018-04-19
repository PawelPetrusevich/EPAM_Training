using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    using System.Collections;

    public abstract class Matrix<T>
    {
        protected T[,] matrix;

        private readonly Comparison<T> compresion = Comparer<T>.Default.Compare;

        public int Count
        {
            get
            {
                return this.matrix.Length;
            }
        }

        protected Comparison<T> Compresion => this.compresion;

        public T this[int i, int j]
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

                this.matrix[i, j] = value;
            }
        }
    }
}
