namespace PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> items;

        public PriorityQueue()
        {
            this.items = new List<T>();
        }

        public int Count { get { return this.items.Count; } }

        public T Peak()
        {
            return this.items[0];
        }

        public T Decueue()
        {
            var top = items[0];
            items[0] = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            HeapifyDown(0);
            return top;
        }

        private void HeapifyDown(int index)
        {
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;
            var maxIndex = leftIndex;

            if (leftIndex >= items.Count)
            {
                return;
            }

            if (rightIndex < items.Count && items[leftIndex].CompareTo(items[rightIndex]) < 0)
            {
                maxIndex = rightIndex;
            }

            if (items[index].CompareTo(items[maxIndex]) < 0)
            {
                var temp = items[index];
                items[index] = items[maxIndex];
                items[maxIndex] = temp;
                HeapifyDown(maxIndex);
            }
        }

        public string Print(int index, int indent)
        {
            var result = string.Empty;

            var leftChild = index * 2 + 1;
            var rightChild = index * 2 + 2;

            if (leftChild < items.Count)
            {
                result += Print(leftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{items[index]}\r\n";

            if (rightChild < items.Count)
            {
                result += Print(rightChild, indent + 3);
            }

            return result;
        }

        public void Add(T item)
        {
            this.items.Add(item);
            int index = items.Count - 1;

            Heapify(index);
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (items[index].CompareTo(items[parentIndex]) > 0)
            {
                var temp = items[index];
                items[index] = items[parentIndex];
                items[parentIndex] = temp;

                Heapify(parentIndex);
            }
        }
    }
}
