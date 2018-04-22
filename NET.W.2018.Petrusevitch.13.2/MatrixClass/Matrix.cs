using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    using System.Collections;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// abstract matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T>
    {
        protected T[,] matrix;

        /// <summary>
        /// Matrix size
        /// </summary>
        public int Length => (int)Math.Sqrt(this.matrix.Length);

        /// <summary>
        /// Gets the compresion.
        /// </summary>
        public Comparison<T> Compresion { get; } = Comparer<T>.Default.Compare;

        /// <summary>
        /// The indexer
        /// </summary>
        /// <param name="i">
        /// The i index.
        /// </param>
        /// <param name="j">
        /// The j index.
        /// </param>
        /// <exception cref="ArgumentException">out of range checed
        /// </exception>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T this[int i, int j]
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
                this.matrix[i, j] = value;
            }
        }

        /// <summary>
        /// The equals ovveraid
        /// </summary>
        /// <param name="obj">
        /// The obj matrix
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>boolean result.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix<T> tempMatrix))
            {
                return false;
            }

            for (int i = 0; i < tempMatrix.Length; i++)
            {
                for (int j = 0; j < tempMatrix.Length; j++)
                {
                    if (this.Compresion(this[i, j], tempMatrix[i, j]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// The get hash code override.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        /// <summary>
        /// Call event methods
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnChangeValue(MatrixArgs<T> e)
        {
            EventHandler<MatrixArgs<T>> handler = ChangeValue;

            handler?.Invoke(this, e);
        }

        public event EventHandler<MatrixArgs<T>> ChangeValue;

    }
}
