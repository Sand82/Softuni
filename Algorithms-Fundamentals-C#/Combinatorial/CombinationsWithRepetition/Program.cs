using System;

namespace CombinationsWithRepetition
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        public static void Main(string[] args)
        {

            elements = Console.ReadLine().Split(' ');

            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Combinations(0, 0);
        }

        private static void Combinations(int index, int startIndex)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                Combinations(index + 1, i);
            }
        }
    }
}