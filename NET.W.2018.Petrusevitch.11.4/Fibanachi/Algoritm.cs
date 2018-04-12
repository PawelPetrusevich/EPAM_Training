namespace Fibanachi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class for fibanachi search algoritm methods
    /// </summary>
    public class Algoritm
    {
        /// <summary>
        /// The fibanachi search algoritm.
        /// </summary>
        /// <param name="number">
        /// The number to wich to look
        /// </param>
        /// <returns>
        /// The <see cref="List"/>fibanachi number list.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// number less zero
        /// number more max value
        /// </exception>
        public static List<int> FibanachiSearchAlgoritm(int number)
        {
            const int MaxIntegerFibonachi = 512559680;

            if (number < 0 || number > MaxIntegerFibonachi)
            {
                throw new ArgumentException($"{nameof(number)}");
            }

            if (number == 0)
            {
                return new List<int> { 0 };
            }

            int firstNumber = 1;
            int secondNumber = 1;
            int sum = 0;
            var result = new List<int> { sum, firstNumber, secondNumber };

            while (number >= sum)
            {
                sum = firstNumber + secondNumber;

                if (sum > number)
                {
                    return result;
                }

                result.Add(sum);
                firstNumber = secondNumber;
                secondNumber = sum;
            }

            return result;
        }
    }
}
