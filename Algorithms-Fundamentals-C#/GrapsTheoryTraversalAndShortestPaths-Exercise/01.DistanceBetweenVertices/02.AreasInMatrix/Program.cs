using System;

namespace AreasInMatrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int row = 0; row < rows; row++)
            {
                var colInput = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    graph[row, col] = colInput[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;                        
                    }

                    var nodeValue = graph[row, col];
                    BFS(row, col, nodeValue);

                    if (!areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue] = 1;
                    }
                    else
                    {
                        areas[nodeValue] += 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Sum(x => x.Value)}");

            foreach (var nodeValue in areas)
            {
                Console.WriteLine($"Letter '{nodeValue.Key}' -> {nodeValue.Value}");
            }
        }

        private static void BFS(int row, int col, char value)
        {

            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (value != graph[row, col])
            {
                return;
            }

            visited[row, col] = true;

            BFS(row + 1, col, value);
            BFS(row - 1, col, value);
            BFS(row, col + 1, value);
            BFS(row, col - 1, value);            
        }
    }
}
