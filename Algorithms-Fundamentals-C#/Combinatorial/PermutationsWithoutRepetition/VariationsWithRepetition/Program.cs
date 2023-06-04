using System;

namespace VariationsWithRepetition
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        private static int count= 0;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');

            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Variations(0);

            Console.WriteLine($"Count of combinations {count}");
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                count++;
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                Variations(index + 1);
            }
        }
    }
}
