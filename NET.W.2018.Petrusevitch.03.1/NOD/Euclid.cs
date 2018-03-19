using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
    public class Euclid
    {
        public static int Algoritm(params int[] numbers)
        {
            var result = 0;
            foreach (var number in numbers)
            {
                result = GCD(result, number);
            }

            return result;
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? (a < 0 ? -a : a) : GCD(b, a % b);
        }
    }
}
