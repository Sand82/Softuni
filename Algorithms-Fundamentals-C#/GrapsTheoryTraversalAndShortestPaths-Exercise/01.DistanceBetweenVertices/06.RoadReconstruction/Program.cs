using System;

namespace RoadReconstruction
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }               
    }

    public class Program
    {
        private static List<int>[] graph;

        private static List<Edge> edges;

        private static bool[] visited;

        public static void Main(string[] args)
        {          
            int n = int.Parse(Console.ReadLine());

            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];

            edges = new List<Edge>();

            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode =edgeParts[0];
                var secondNode =edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge { First = firstNode, Second = secondNode });
            }

            var result = new List<string>();

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];

                DFS(0);

                if (visited.Contains(false))
                {
                    result.Add($"{edge.First} {edge.Second}");
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }

            Console.WriteLine("Important streets:");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node] == true)
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
