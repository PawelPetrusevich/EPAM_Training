using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
    public class Euclid
    {
        /// <summary>
        /// Method for the finding GCD in intenger array
        /// </summary>
        /// <param name="numbers">numbers array</param>
        /// <returns>GCD int this array</returns>
        public static Tuple<int, long> Algoritm(params int[] numbers)
        {
            var time = Stopwatch.StartNew();

            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            var result = 0;

            foreach (var number in numbers)
            {
                result = Gcd(result, number);
            }

            time.Stop();

            return new Tuple<int, long>(result, time.ElapsedMilliseconds);
        }

        /// <summary>
        /// Euclid algoritm for GCD
        /// </summary>
        /// <param name="a">firt number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD for this numbers</returns>
        private static int Gcd(int a, int b)
        {
            return b == 0 ? (a < 0 ? -a : a) : Gcd(b, a % b);
        }
    }
}
