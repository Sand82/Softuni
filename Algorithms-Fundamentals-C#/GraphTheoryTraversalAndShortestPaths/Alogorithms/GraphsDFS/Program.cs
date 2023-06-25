using System;

namespace GraphsDFS
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
                GraphsDFS(node);
            }

        }

        private static void GraphsDFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                GraphsDFS(child);
            }
            
            Console.WriteLine(node);
        }
    }
}