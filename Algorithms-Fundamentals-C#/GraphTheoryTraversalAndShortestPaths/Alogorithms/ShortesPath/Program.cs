﻿using System;

namespace ShortesPath
{ 
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            Array.Fill(parent, -1);

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (currNode == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(String.Join(' ', path));
                    break;
                }

                foreach (var child in graph[currNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parent[child] = currNode;
                    }                    
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var result = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                result.Push(node);
                node = parent[node];
            }

            return result;
        }
    }
}