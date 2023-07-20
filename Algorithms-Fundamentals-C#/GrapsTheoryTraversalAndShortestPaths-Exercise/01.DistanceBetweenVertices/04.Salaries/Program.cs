using System;

namespace Salaries
{
    public class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visitet;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            visitet = new Dictionary<int, int>();

            graph = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();

                var nodeChildren = Console.ReadLine();

                for (int child = 0; child < nodeChildren.Length; child++)
                {
                    if (nodeChildren[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            var salary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
               salary += DFS(node);
            }

            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {
            if (visitet.ContainsKey(node))
            {
                return visitet[node];
            }

            var salary = 0;

            if (graph[node].Count == 0)
            {
                salary = 1;
            }
            else 
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visitet[node] = salary;
            return salary;
        }
    }
}
