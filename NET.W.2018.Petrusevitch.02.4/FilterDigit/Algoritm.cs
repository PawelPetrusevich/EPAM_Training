using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FilterDigit
{
    public class Algoritm
    {
        public static int[] Filter(int filterNumber, params int[] numberArray)
        {
            List<int> result = new List<int>();
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