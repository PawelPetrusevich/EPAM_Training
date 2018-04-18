namespace CustomQueue.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class QueueMethodsTest
    {
        [Test]
        public void QueueEnqueueTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            var result = new List<int> { 1, 2, 3, 4 };
            int i = 0;
            foreach (var item in queue)
            {
                Assert.That(result[i], Is.EqualTo(item));
                i++;
            }
        }

        [Test]
        public void QueueDequeueTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            var dequeue1 = queue.Dequeue();
            var dequeue2 = queue.Dequeue();

            var result1 = 1;
            var result2 = 2;

            Assert.That(result1, Is.EqualTo(dequeue1));
            Assert.That(result2, Is.EqualTo(dequeue2));
        }

        [Test]
        public void QueuePeekTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            var peek1 = queue.Peek();

            var result = 1;
            
            Assert.That(result, Is.EqualTo(peek1));
        }

        [Test]
        public void QueueClearTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Clear();

            Assert.That(queue, Is.Empty);
        }

        [Test]
        public void QueueCountTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            var result = 4;

            Assert.That(result, Is.EqualTo(queue.Count));
        }

        [Test]
        public void QueueIsEmptyTest()
        {
            CustomQueue.Queue<int> queue = new CustomQueue.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.IsFalse(queue.IsEmpty);
        }
    }
}
