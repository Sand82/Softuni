using System;

namespace ConnectedComponents
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    var graphTokens = line.Split(' ').Select(int.Parse).ToList();
                    graph[i] = graphTokens;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var result = new List<int>();
                DFS(node, result);

                Console.WriteLine($"Connected component: {string.Join(' ', result)}");
            }
        }

        private static void DFS(int node, List<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, result);
            }

            result.Add(node);
        }
    }
}