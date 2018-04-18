// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" Iterator.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: CustomQueue
//  Project: CustomQueue
//  Filename: Iterator.cs
//  Created day: 17.04.2018    17:13
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace CustomQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Iterator<T> : IEnumerator<T>
    {
        public T[] array;

        private int position = -1;

        public Iterator(T[] _array)
        {
            this.array = _array;
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.position++;
            return (this.position < this.array.Length);
        }

        public void Reset()
        {
            this.position = -1;
        }

        public T Current
        {
            get
            {
                try
                {
                    return this.array[this.position];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => this.Current;
    }
}