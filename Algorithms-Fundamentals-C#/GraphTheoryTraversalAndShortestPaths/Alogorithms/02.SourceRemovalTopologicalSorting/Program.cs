using System;

namespace SourceRemovalTopologicalSorting
{
    public class Program
    {
        public static Dictionary<string, List<string>> graph;
        public static Dictionary<string, int> dependencies;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            dependencies = GetGraphDependencies(graph);

            var result = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                result.Add(nodeToRemove);
                dependencies.Remove(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child] -= 1;
                }
            }

            if (dependencies.Count == 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", result)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static Dictionary<string, int> GetGraphDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var dependency in graph)
            {
                var key = dependency.Key;
                var children = dependency.Value;

                if (!result.ContainsKey(key))
                {
                    result[key] = 0;                    
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }

            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

                var key = tokens[0];

                if (tokens.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = tokens[1].Split(", ").ToList();
                    result[key] = children;
                }
            }

            return result;
        }
    }
}
