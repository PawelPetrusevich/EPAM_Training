using System;
using System.Diagnostics;

namespace NOD
{
    public class Stein
    {
        /// <summary>
        /// Method for the finding GCD in intenger array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD int this array</returns>
        public static Tuple<int,long> Algoritm(params int[] numbers)
        {
            var result = 0;
            var time = Stopwatch.StartNew();
            if (numbers==null || numbers.Length==0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            
            foreach (var number in numbers)
            {
                result = Gcd(result, number);
            }
            time.Stop();
            return new Tuple<int, long>(result,time.ElapsedMilliseconds);
        }


        /// <summary>
        /// Binari algoritm for GCD (Stein Algoritm)
        /// </summary>
        /// <param name="a">firt number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD for this numbers</returns>
        private static int Gcd(int a, int b)
        {
            if (a == 0)
                return b;                            
            if (b == 0)
                return a;                            
            if (a == b)
                return a;                            
            if (a == 1 || b == 1)
                return 1;                            
            if ((a & 1) == 0)                        
                return ((b & 1) == 0)
                    ? Gcd(a >> 1, b >> 1) << 1       
                    : Gcd(a >> 1, b);                
            else                                     
                return ((b & 1) == 0)
                    ? Gcd(a, b >> 1)                 
                    : Gcd(b, a > b ? a - b : b - a); 
        }
    }
}