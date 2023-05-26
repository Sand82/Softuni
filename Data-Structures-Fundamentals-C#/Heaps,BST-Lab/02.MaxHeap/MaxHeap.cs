namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            heap = new List<T>();
        }

        public int Size { get {return heap.Count; } }

        public void Add(T element)
        {
            heap.Add(element);
            HeapiFy(heap.Count - 1);
        }

        public T Peek()
        {
            return heap[0];
        }

        private void HeapiFy(int index) 
        {
            if (index == 0)
            {
                return;
            }

            int parent = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parent]) > 0)
            {
                T temp = heap[parent];
                heap[parent] = heap[index];
                heap[index] = temp;
                HeapiFy(parent);
            }
        }
    }
}
