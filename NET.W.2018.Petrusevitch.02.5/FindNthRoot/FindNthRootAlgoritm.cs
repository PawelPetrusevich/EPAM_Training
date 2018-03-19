using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRoot
{
    public class FindNthRootAlgoritm
    {
        public static double SqrtN(double number, int n, double precesion)
        {
            if (precesion > 1 || precesion < 1e-15)
            {
                throw new ArgumentException();
            }

            if (n<0)
            {
                throw new ArgumentException();
            }

            double x0;
            double x1;
            x1 = number;
            x0 = x1;
            x1 = x0 - (Math.Pow(x0, n) - number) / (Math.Pow(x0, n - 1) * n);
            while (Math.Abs(x1 - x0) > precesion)
            {
                x0 = x1;
                x1 = x0 - (Math.Pow(x0, n) - number) / (Math.Pow(x0, n - 1) * n);
            }

            return x1;
        }
    }
}
