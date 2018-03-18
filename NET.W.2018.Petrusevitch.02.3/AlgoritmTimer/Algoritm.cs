using System;
using System.Diagnostics;

namespace AlgoritmTimer
{
    public class Algoritm
    {

        public static Tuple<int,double> FindAlgoritm(int number)
        {
            var watch = Stopwatch.StartNew();
            var numberArray = new int[number.ToString().Length];
            for (int i = numberArray.Length - 1; i >= 0; i--)
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
                return Tuple.Create(-1,watch.Elapsed.TotalMilliseconds);
            }


            int temp = numberArray[index + 1];
            numberArray[index + 1] = numberArray[index];
            numberArray[index] = temp;

            int[] resultArray = new int[numberArray.Length];

            for (int i = 0; i <= index; i++)
            {
                resultArray[i] = numberArray[i];
            }

            int[] tempArray = new int[numberArray.Length - index - 1];
            for (int i = index + 1; i < numberArray.Length; i++)
            {
                tempArray[i - index - 1] = numberArray[i];
            }
            Array.Sort(tempArray);
            for (int i = index; i < numberArray.Length - 1; i++)
            {
                resultArray[i + 1] = tempArray[i - index];
            }

            string numberString = String.Concat(resultArray);
            return Tuple.Create(Int32.Parse(numberString), watch.Elapsed.TotalMilliseconds);
        }

    }
}