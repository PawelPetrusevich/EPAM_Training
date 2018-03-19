﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToBitArray
{
    public class DoubleToBitArrayAlgoritm
    {
        public static string Algoritm(double number)
        {
            var sb = new StringBuilder();
            var bitArray = new BitArray(BitConverter.GetBytes(number));
            foreach (bool bit in bitArray)
            {
                sb.Insert(0, (bit ? 1 : 0));
            }

            return sb.ToString();
        }
    }
}
