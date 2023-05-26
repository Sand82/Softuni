using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementPriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            queue = new List<T>();
        }

        public int Count { get { return queue.Count; } }

        public T Peek() 
        {
            return queue[0];
        }

        public T Dequeue() 
        {
            T top = queue[0];
            queue[0] = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;

            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= queue.Count)
            {
                return;
            }

            if ((rightChildIndex < queue.Count) && queue[rightChildIndex].CompareTo(queue[leftChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (queue[index].CompareTo(queue[maxChildIndex]) < 0)
            {
                T temp = queue[maxChildIndex];
                queue[maxChildIndex] = queue[index];
                queue[index] = temp;
                HeapifyDown(maxChildIndex);
            }
        }
        

        public void Add(T element)
        {
            queue.Add(element);
            Heapify(queue.Count - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parent = (index - 1) / 2;

            if (queue[index].CompareTo(queue[parent]) > 0)
            {
                T temp = queue[parent];
                queue[parent] = queue[index];
                queue[index] = temp;
                Heapify(parent);
            }
        }
    }
}
