using System;

namespace DistanceBetweenVertices
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;

        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var parent = int.Parse(tokens[0]);

                if (tokens.Count == 1)
                {
                    graph[parent] = new List<int>();
                }
                else
                {
                    var childrens = tokens[1].Split(" ").Select(int.Parse).ToList();

                    graph[parent] = childrens;
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var tokens = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var start = int.Parse(tokens[0]);
                var destination = int.Parse(tokens[1]);

                var steps = BFS(start, destination);

                Console.WriteLine($"{{{start},{destination}}} -> {steps}");
            }
        }

        private static int BFS(int start, int destination)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int>{ start};
            var parent = new Dictionary<int, int>{ { start, -1} };

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetSteps(parent, destination);
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var node = destination;
            var steps = 0;

            while (node != -1)
            {
                node = parent[node];
                steps += 1;
            }

            return steps;
        }
    }
}
