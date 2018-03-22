using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public sealed class Polynomial : ICloneable
    {
        private readonly double[] _coeff;

        public Polynomial(double[] coeff)
        {
            this._coeff = coeff;
        }

        public double this[int n]
        {
            get => _coeff[n];
            set => _coeff[n] = value;
        }

        public int Power => _coeff.Length;

        public override string ToString()
        {
            if (_coeff.Length == 0)
            {
                return "0";
            }
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < Power; i++)
            {
                sb.Append(_coeff[i] < 0 ? $"+({_coeff[i]})x^{Power - i}" : $"+{_coeff[i]}x^{Power - i}");
            }

            if (sb[0] == '+' || sb[0] == '-')
            {
                sb.Remove(0, 1);
            }

            return sb.ToString();
        }

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] coeff = new double[firstPolynomial.Power>secondPolynomial.Power? firstPolynomial.Power : secondPolynomial.Power];
            Polynomial result = new Polynomial(coeff);
            for (int i = coeff.Length-1; i >0; i--)
            {
                double a = 0;
                double b = 0;
                if (i<firstPolynomial.Power)
                {
                    a = firstPolynomial[i];
                }

                if (i<secondPolynomial.Power)
                {
                    b = secondPolynomial[i];
                }
                result[coeff.Length-i] = a+b;
            }

            return result;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
