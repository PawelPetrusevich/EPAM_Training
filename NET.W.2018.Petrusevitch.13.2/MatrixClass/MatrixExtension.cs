// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" MatrixExtension.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: MatrixClass
//  Project: MatrixClass
//  Filename: MatrixExtension.cs
//  Created day: 22.04.2018    14:03
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace MatrixClass
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public class MatrixExtension
    {
        /// <summary>
        /// The check matrix.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/> boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checed
        /// </exception>
        public static bool CheckMatrix<T>(DiagonalMatrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            bool flag = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i != j)
                    {
                        if (matrix.Compresion(matrix[i, j], matrix.DefaultValue) != 0)
                        {
                            flag = false;
                        }
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// The check matrix.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/> boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checed
        /// </exception>
        public static bool CheckMatrix<T>(SquereMatrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            bool flag = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i == j)
                    {
                        flag = true;
                    }

                    if (i != j)
                    {
                        flag = false;
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// The check matrix.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/> boolean result.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checed
        /// </exception>
        public static bool CheckMatrix<T>(SymetrMatrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix.Compresion(matrix[i, j], matrix[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// The sum matrix.
        /// </summary>
        /// <param name="firstMatrix">
        /// The first matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second matrix.
        /// </param>
        /// <typeparam name="T">generic type
        /// </typeparam>
        /// <returns>
        /// The <see cref="SquereMatrix"/> result squere matrix.
        /// </returns>
        /// <exception cref="ArgumentNullException">null checed.
        /// </exception>
        /// <exception cref="ArgumentException">size checed
        /// </exception>
        public static SquereMatrix<T> SumMatrix<T>(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix == null)
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }

            if (secondMatrix == null)
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }

            if (firstMatrix.Length != secondMatrix.Length)
            {
                throw new ArgumentException("Matrix size not equals");
            }

            ParameterExpression firstParametr = Expression.Parameter(typeof(T), nameof(firstMatrix));
            ParameterExpression secondParametr = Expression.Parameter(typeof(T), nameof(secondMatrix));
            var lambda = Expression.Lambda(Expression.Add(firstParametr, secondParametr), firstParametr, secondParametr);
            var sum = lambda.Compile() as Func<T, T, T>;

            var matrix = new SquereMatrix<T>(firstMatrix.Length, default(T));
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[i, j] = sum(firstMatrix[i, j], secondMatrix[i, j]);
                }
            }

            return matrix;
        }
    }
}