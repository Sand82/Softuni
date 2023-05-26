namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            queue = new List<T>();
        }

        public int Size { get { return queue.Count; } }

        public T Dequeue()
        {
            T top = queue[0];
            queue[0] = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            HeapiFyDown(0);

            return top;
        }

        private void HeapiFyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;

            if (leftChildIndex >= queue.Count)
            {
                return;
            }

            int maxChildIndex = leftChildIndex;

            if (rightChildIndex < queue.Count && queue[rightChildIndex].CompareTo(queue[leftChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (queue[index].CompareTo(queue[maxChildIndex]) < 0)
            {
                T temp = queue[maxChildIndex];
                queue[maxChildIndex] = queue[index];
                queue[index] = temp;
                HeapiFyDown(maxChildIndex);
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

        public T Peek()
        {
            return queue[0];
        }
    }
}
