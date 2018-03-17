using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindNextBiggerNumber
{
    public class FindNextNumber
    {
        public static int FindAlgoritm(int number)
        {
            var numberArray = new int[number.ToString().Length];
            for (int i = numberArray.Length-1;i>=0;i--)
            {
                numberArray[i] = number % 10;
                number = number / 10;
            }

            int index = -1;

            for (int i = numberArray.Length - 1; i > 0; i--)
            {
                if (index == -1)
                {
                    if (numberArray[i] > numberArray[i - 1])
                    {
                        index = i - 1;
                    }
                }
            }

            if (index == -1)
            {
                return -1;
            }


            int temp = numberArray[index + 1];
            numberArray[index + 1] = numberArray[index];
            numberArray[index] = temp;

            int[] resultArray = new int[numberArray.Length];

            for (int i = 0; i <= index ; i++)
            {
                resultArray[i] = numberArray[i];
            }

            int[] tempArray = new int[numberArray.Length-index-1];
            for (int i = index+1; i < numberArray.Length; i++)
            {
                tempArray[i - index - 1] = numberArray[i];
            }
            Array.Sort(tempArray);
            for (int i = index; i < numberArray.Length-1; i++)
            {
                resultArray[i+1] = tempArray[i - index];
            }

            string numberString = String.Concat(resultArray);
            return int.Parse(numberString);
        }
    }
}
