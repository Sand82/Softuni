using Heap;

var heap = new Heap<int>();

var array = new List<int>() { 15, 6, 9, 5, 25, 8, 17, 16 };

for (int i = 0; i < array.Count; i++)
{
    heap.Add(array[i]);
}

heap.Add(100);
heap.Add(7);

Console.WriteLine(heap.PringHeap(0, 0));
