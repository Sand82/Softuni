using System;

namespace GraphsBFS
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;

        private static HashSet<int> visited = new HashSet<int>();
        public static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>
            {
              {1, new List<int> { 19, 21, 14 } },
              {19, new List<int> { 7, 12, 31, 21 } },
              {21, new List<int> { 14 } },
              {14, new List<int> { 6, 23 } },
              {7, new List<int> { 1} },
              {12, new List<int> () },
              {31, new List<int> { 21 } },
              {23, new List<int> { 21 } },
              {6, new List<int> () },
            };

            foreach (var node in graph.Keys)
            {
                GraphsBFS(node);
            }
        }

        private static void GraphsBFS(int startNode)
        {
            if (visited.Contains(startNode))
            {
                return;
            }

            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }

                Console.WriteLine(node);
            }
        }
    }
}
