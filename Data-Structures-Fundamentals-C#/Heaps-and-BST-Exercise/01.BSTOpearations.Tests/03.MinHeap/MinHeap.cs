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

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            Swap(0, this.Size - 1);
            elements.RemoveAt(elements.Count - 1);
            HeapiFyDown(0);

            return element;

        }

        private void HeapiFyDown(int parentIndex)
        {
           
           var smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);

            while (smallerChildIndex != -1 && IsSmaller(smallerChildIndex, parentIndex))
            {
                Swap(smallerChildIndex, parentIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);
            }
        }

        private int FindSmallerChildIndex(int leftChildIndex, int rightChildIndex)
        {
            if (leftChildIndex >= this.Size)
            {
                return -1;
            }

            if (rightChildIndex >= this.Size)
            {
                return leftChildIndex;
            }

            return IsSmaller(leftChildIndex, rightChildIndex) ? leftChildIndex : rightChildIndex;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            HeapifyUp(this.Size - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            while (IsSmaller(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        private void Swap(int index, int parentIndex)
        {
            var temp = elements[parentIndex];
            elements[parentIndex] = elements[index];
            elements[index] = temp;
        }

        private bool IsSmaller(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }        

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            return this.elements[0];
        }
    }
}
