using System;
using System.Linq;

namespace GeneratingCombinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            int index = 0;
            int border = 0;

            var resultArr = new int[n];

            GeneratingCombinations(arr, resultArr, index, border);
        }

        private static void GeneratingCombinations(int[] set, int[] vector, int index, int border)
        {
            if (vector.Length == index)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];

                GeneratingCombinations(set, vector, index + 1, i + 1);
            }
        }
    }
}
