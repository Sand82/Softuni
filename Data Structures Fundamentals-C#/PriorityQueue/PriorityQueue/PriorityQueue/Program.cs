using PriorityQueue;

var queue = new PriorityQueue<int>();

var array = new List<int>() { 5, 6, 9, 5, 25, 8, 17, 16 };

for (int i = 0; i < array.Count; i++)
{
    queue.Add(array[i]);
}

queue.Add(100);
queue.Add(7);

Console.WriteLine(queue.Print(0, 0));
while(queue.Count > 0)
{
    Console.WriteLine(queue.Decueue());
}
