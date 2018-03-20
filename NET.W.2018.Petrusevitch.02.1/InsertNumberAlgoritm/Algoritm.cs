using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumberAlgoritm
{
    public class Algoritm
    {
        /// <summary>
        /// Insert number algoritm whith bitarray
        /// </summary>
        /// <param name="numberSource">first number</param>
        /// <param name="numberIn">second number</param>
        /// <param name="i">start index</param>
        /// <param name="j">end index</param>
        /// <returns></returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i<0 || i>31 || j<0 || j> 31 || i> j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} and {nameof(j)} has incorect value");
            }

            var numberSourceBitArray = new BitArray(BitConverter.GetBytes(numberSource));
            var numberInBitArray = new BitArray(BitConverter.GetBytes(numberIn));
            var tempArray = new bool[32];
            for (int k = 0; k < numberSourceBitArray.Length-1; k++)
            {
                if ((k<i)||(k>j))
                {
                    tempArray[k] = numberSourceBitArray[k];
                }

                if ((k>=i)&&(k<=j))
                {
                    tempArray[k] = numberInBitArray[k - i];
                }
                
            }
            var result = new BitArray(tempArray);
            var byteResult = new byte[4];
            result.CopyTo(byteResult,0);



            return BitConverter.ToInt32(byteResult, 0);
        }
    }
}
