namespace Polinom
{
    using System;
    using System.Text;

    /// <summary>
    /// The polynomial class.
    /// </summary>
    public sealed class Polynomial : ICloneable
    {
        private readonly double[] _coeff;

        public Polynomial(double[] coeff)
        {
            if (coeff == null)
            {
                throw new ArgumentNullException(nameof(coeff));
            }

            if (coeff.Length == 0)
            {
                throw new ArgumentException(nameof(coeff));
            }
            this._coeff = coeff;
        }

        public int Power
        {
            get
            {
                return this._coeff.Length;
            }
        }

        public double this[int n]
        {
            get => this._coeff[n];
            set => this._coeff[n] = value;
        }

        /// <summary>
        /// The ToString override
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            if (this._coeff.Length == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < this.Power; i++)
            {
                if ((i + 1 - this.Power) == 0)
                {
                    sb.Append(this._coeff[i] < 0 ? $"+({this._coeff[i]})" : $"+{this._coeff[i]}");
                }
                else
                {
                    sb.Append(this._coeff[i] < 0 ? $"+({this._coeff[i]})x^{this.Power - 1 - i}" : $"+{this._coeff[i]}x^{this.Power - 1 - i}");
                }

            }

            if (sb[0] == '+' || sb[0] == '-')
            {
                sb.Remove(0, 1);
            }

            return sb.ToString();
        }

        /// <summary>
        /// The get hash code override 
        /// </summary>
        /// <returns>
        /// Hash-code <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// The equals override whith verification
        /// </summary>
        /// <param name="obj">
        /// The object with which we compare
        /// </param>
        /// <returns>
        /// The boolean <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial poly = obj as Polynomial;

            if (poly == null)
            {
                return false;
            }

            return poly.ToString() == this.ToString();
        }

        /// <summary>
        /// The equals override
        /// </summary>
        /// <param name="poly">
        /// The Polynom
        /// </param>
        /// <returns>
        /// Boolean <see cref="bool"/>.
        /// </returns>
        public bool Equals(Polynomial poly)
        {
            if (poly == null)
            {
                return false;
            }

            return poly.ToString() == this.ToString();
        }

        /// <summary>
        /// Operator == overrload
        /// </summary>
        /// <param name="firstPoly">
        /// The first poly.
        /// </param>
        /// <param name="secondPoly">
        /// The second poly.
        /// </param>
        /// <returns>
        /// Boolean
        /// </returns>
        public static bool operator ==(Polynomial firstPoly, Polynomial secondPoly)
        {
            return Equals(firstPoly, secondPoly);
        }

        /// <summary>
        /// Operator != overload
        /// </summary>
        /// <param name="firstPoly">
        /// The first poly.
        /// </param>
        /// <param name="secondPoly">
        /// The second poly.
        /// </param>
        /// <returns>
        /// Boolean
        /// </returns>
        public static bool operator !=(Polynomial firstPoly, Polynomial secondPoly)
        {
            return !Equals(firstPoly, secondPoly);
        }

        /// <summary>
        /// Operator + overrload
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynomial.
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynomial.
        /// </param>
        /// <returns>
        /// New Polynom
        /// </returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] coeff = new double[firstPolynomial.Power > secondPolynomial.Power ? firstPolynomial.Power : secondPolynomial.Power];

            Polynomial result = new Polynomial(coeff);

            for (int i = coeff.Length; i > 0; i--)
            {
                double a = 0;
                double b = 0;

                if (i <= firstPolynomial.Power)
                {
                    a = firstPolynomial[firstPolynomial.Power - i];
                }

                if (i <= secondPolynomial.Power)
                {
                    b = secondPolynomial[secondPolynomial.Power - i];
                }

                result[coeff.Length - i] = a + b;
            }

            return result;
        }

        /// <summary>
        /// Operator - overrload
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynomial.
        /// </param>
        /// <param name="secondPolynomial">
        /// The second polynomial.
        /// </param>
        /// <returns>
        /// New polynom
        /// </returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] coeff = new double[firstPolynomial.Power > secondPolynomial.Power ? firstPolynomial.Power : secondPolynomial.Power];

            Polynomial result = new Polynomial(coeff);

            for (int i = coeff.Length; i > 0; i--)
            {
                double a = 0;
                double b = 0;

                if (i <= firstPolynomial.Power)
                {
                    a = firstPolynomial[firstPolynomial.Power - i];
                }

                if (i <= secondPolynomial.Power)
                {
                    b = secondPolynomial[secondPolynomial.Power - i];
                }

                result[coeff.Length - i] = a - b;
            }

            return result;
        }

        /// <summary>
        /// Operator * overload
        /// </summary>
        /// <param name="firstPolynomial">
        /// The first polynomial.
        /// </param>
        /// <param name="seconPolynomial">
        /// The secon polynomial.
        /// </param>
        /// <returns>
        /// New Polynom
        /// </returns>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial seconPolynomial)
        {
            double[] coeff = new double[firstPolynomial.Power + seconPolynomial.Power];
            Polynomial result = new Polynomial(coeff);

            for (int i = 0; i < firstPolynomial.Power; i++)
            {
                for (int j = 0; j < seconPolynomial.Power; j++)
                {
                    result[i + j] += firstPolynomial[i] * seconPolynomial[j];
                }
            }

            return result;
        }

        /// <summary>
        /// The IClonabale interface implimintation
        /// </summary>
        /// <returns>
        /// Clone for this Polynom <see cref="object"/>.
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
