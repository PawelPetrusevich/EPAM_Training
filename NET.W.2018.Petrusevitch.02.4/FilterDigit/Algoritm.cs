using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FilterDigit
{
    public class Algoritm
    {
        /// <summary>
        /// search for the number containing the given digit
        /// </summary>
        /// <param name="filterNumber">Given digit</param>
        /// <param name="numberArray">number array</param>
        /// <returns>the number array containing the given digit</returns>
        public static int[] Filter(int filterNumber, params int[] numberArray)
        {
            List<int> result = new List<int>();
            if (filterNumber/10 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(filterNumber));
            }

            if (numberArray == null || numberArray.Length == 0)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (Regex.IsMatch(numberArray[i].ToString(),$"[{filterNumber.ToString()}]"))
                {
                    var flag = true;
                    foreach (var number in result)
                    {
                        if (number==numberArray[i])
                        {
                            flag = false;
                        }
                    }

                    if (flag)
                    {
                        result.Add(numberArray[i]);
                    }
                }
            }

            
            

            return result.ToArray();
        }
    }
}