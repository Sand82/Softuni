namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => elements.Count;

        public T Dequeue()
        {
            var top = elements[0];
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);
            return top;
        }

        private void HeapifyDown(int index)
        {
            var leftChildElementIndex = (2 * index) + 1;
            var rightChildElementIndex = (2 * index) + 2;

            if (leftChildElementIndex >= elements.Count)
            {
                return;
            }

            var minElementIndex = leftChildElementIndex;

            if (rightChildElementIndex < elements.Count && elements[rightChildElementIndex].CompareTo(elements[leftChildElementIndex]) < 0)
            {
                minElementIndex = rightChildElementIndex;
            }

            if (elements[index].CompareTo(elements[minElementIndex]) > 0)
            {
                var temp = elements[index];
                elements[index] = elements[minElementIndex];
                elements[minElementIndex] = temp;
                HeapifyDown(minElementIndex);
            }

        }

        public void Add(T element)
        {
            elements.Add(element);
            var index = elements.Count - 1;

            Heapify(index);
        }

        private void Heapify(int index)
        {
            var rootIndex = (index - 1) / 2;

            if (rootIndex < 0)
            {
                return;
            }

            var rootElement = elements[rootIndex];

            if (rootElement.CompareTo(elements[index]) > 0)
            {
                var temp = elements[index];
                elements[index] = elements[rootIndex];
                elements[rootIndex] = temp;

                Heapify(rootIndex);
            }
            else
            {
                return;
            }
        }

        public T Peek()
        {
            return elements[0];
        }
    }
}
