namespace Heap
{
    public class Heap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public Heap()
        {
          heap = new List<T>();
        }
        public int Size { get { return heap.Count; } }

        public T GetMax()
        {
            return heap[0];
        }

        public string PringHeap(int index, int indent)
        {
            var result = "";

            var leftChild = (index * 2) + 1;
            var rightChild = (index * 2) + 2;

            if (leftChild < heap.Count)
            {
                result += PringHeap(leftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{heap[index]}\r\n";

            if (rightChild < heap.Count)
            {
                result += PringHeap(rightChild, indent + 3);
            }

            return result;
        }

        public void Add(T element)
        {
            heap.Add(element);
            int index = heap.Count - 1;
            Heapify(index);
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = (index - 1) / 2;            

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                var temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                Heapify(parentIndex);
            }
        }
    }
}
