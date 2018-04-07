// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" RefactorAlgoritm.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: NOD
//  Project: NOD
//  Filename: RefactorAlgoritm.cs
//  Created day: 07.04.2018    16:41
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace NOD
{
    using System;
    using System.Diagnostics;

    public class RefactorAlgoritm
    {
        /// <summary>
        /// Delegate for gcd find algoritm
        /// </summary>
        /// <param name="a">first number with array</param>
        /// <param name="b">second number with array</param>
        /// <returns>Gcd</returns>
        public delegate int Gcd(int a, int b);

        /// <summary>
        /// Method for the finding GCD in intenger array
        /// </summary>
        /// <param name="numbers">numbers array</param>
        /// <param name="gcd">gcd delegate</param>
        /// <returns>GCD int this array</returns>
        public static Tuple<int, long> Algoritm(Gcd gcd, params int[] numbers)
        {
            var time = Stopwatch.StartNew();

            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            var result = 0;

            foreach (var number in numbers)
            {
                result = gcd(result, number);
            }

            time.Stop();

            return new Tuple<int, long>(result, time.ElapsedMilliseconds);
        }

        /// <summary>
        /// Binari algoritm for GCD (Stein Algoritm)
        /// </summary>
        /// <param name="a">firt number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD for this numbers</returns>
        public static int GcdStein(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == b)
            {
                return a;
            }

            if (a == 1 || b == 1)
            {
                return 1;
            }

            if ((a & 1) == 0)
            {
                return ((b & 1) == 0) ? GcdStein(a >> 1, b >> 1) << 1 : GcdStein(a >> 1, b);
            }
            else
            {
                return ((b & 1) == 0) ? GcdStein(a, b >> 1) : GcdStein(b, a > b ? a - b : b - a);
            }
        }


        /// <summary>
        /// Euclid algoritm for GCD
        /// </summary>
        /// <param name="a">firt number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD for this numbers</returns>
        public static int GcdEuclid(int a, int b)
        {
            return b == 0 ? (a < 0 ? -a : a) : GcdEuclid(b, a % b);
        }
    }
}