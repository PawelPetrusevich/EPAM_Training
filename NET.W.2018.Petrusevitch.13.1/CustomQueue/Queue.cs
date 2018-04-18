using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    using System.Collections;

    public class Queue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 2;

        private const int DefaultBeggin = -1;

        private const int DefaultEnd = -1;

        private T[] array;

        private int size;

        private int capacity;

        private int beggin;

        private int end;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Queue()
        {
            this.array = new T[DefaultCapacity];
            this.size = 0;
            this.capacity = DefaultCapacity;
            this.beggin = DefaultBeggin;
            this.end = DefaultEnd;
        }

        /// <summary>
        /// Constructor with inducation capacity.
        /// </summary>
        /// <param name="_capacity">queue capacity</param>
        public Queue(int _capacity)
        {
            this.array = new T[_capacity];
            this.size = 0;
            this.capacity = _capacity;
            this.beggin = DefaultBeggin;
            this.end = DefaultEnd;
        }

        /// <summary>
        /// Constructor inizialisation queue with collection
        /// </summary>
        /// <param name="collection">object collection</param>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            this.capacity = collection.Count();
            this.array = new T[collection.Count()];
            int temp = 0;
            foreach (var item in collection)
            {
                this.array[temp++] = item;
            }

            this.beggin = 0;
            this.end = collection.Count() - 1;
        }

        public int Count => this.size;

        public bool IsEmpty => this.size == 0;

        /// <summary>
        /// Queue contains the element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>result.
        /// </returns>
        public bool Contains(T element)
        {
            return this.array.Contains(element);
        }

        /// <summary>
        /// Go first element withat deleting
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>first element.
        /// </returns>
        public T Peek()
        {
            return this.array[this.beggin + 1];
        }

        /// <summary>
        /// Add element to queue
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        public void Enqueue(T element)
        {
            if (this.size == this.capacity)
            {
                T[] queue = new T[2 + this.capacity];
                Array.Copy(this.array, 0, queue, 0, this.array.Length);
                this.array = queue;
                this.capacity += 2;
            }

            this.size++;
            this.array[++this.end] = element;
        }

        /// <summary>
        /// Extract element from queue
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>element.
        /// </returns>
        /// <exception cref="InvalidOperationException"> null checked
        /// </exception>
        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException($"Queue is empty");
            }

            var temp = this.array[++this.beggin];
            if (this.beggin == this.end)
            {
                this.beggin = DefaultBeggin;
                this.end = DefaultEnd;
            }

            return temp;
        }

        /// <summary>
        /// Delete all element
        /// </summary>
        public void Clear()
        {
            this.array = new T[0];
            this.beggin = DefaultBeggin;
            this.end = DefaultEnd;
            this.size = 0;
        }

        /// <summary>
        /// Queueto array
        /// </summary>
        /// <returns>
        /// The <see cref="T[]"/> element from queue.
        /// </returns>
        public T[] ToArray()
        {
            T[] temp = new T[this.Count];
            Array.Copy(this.array, temp, this.Count);
            return temp;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator<T>(this.array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
