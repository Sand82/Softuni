using System;

namespace BreakCycles
{
    public class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }
    }

    public class Program
    {
        private static Dictionary<string, List<string>> graph;

        private static List<Edge> edges;
        public static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();

            edges = new List<Edge>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var nodesAndChildren = Console.ReadLine().Split(" -> ");

                var node = nodesAndChildren[0];

                var children = nodesAndChildren[1].Split(" ").ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge() { First = node, Second = child });
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var result = new List<string>();

            foreach (var edge in edges)
            {
               var remove =  graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                if (!remove)
                {
                    continue;
                }

                if (BFS(edge.First, edge.Second))
                {
                    result.Add($" {edge.First} - {edge.Second}");
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {result.Count()}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();

            queue.Enqueue(start);

            var visited = new HashSet<string>() { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (node == destination)
                    {
                        return true;
                    }

                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return false;
        }
    }
}
