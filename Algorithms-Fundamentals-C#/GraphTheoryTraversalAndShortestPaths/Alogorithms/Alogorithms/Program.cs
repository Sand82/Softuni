﻿using System;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var graph = new List<int>[]
            {
                new List<int> { 3, 6 },
                new List<int> { 2, 3, 4, 5, 6 },
                new List<int> { 1, 4, 5 },
                new List<int> { 0, 1, 5 },
                new List<int> { 1, 2, 6 },
                new List<int> { 1, 2, 3 },
                new List<int> { 0, 1, 4 },
            };

            Console.WriteLine(String.Join( " ", graph[1]));
        }
    }
}
