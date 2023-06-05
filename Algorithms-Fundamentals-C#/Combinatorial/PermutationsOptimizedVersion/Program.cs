using System;

namespace PermutationsOptimizedVersion
{
    public class Program
    {
        private static string[] inputs;
        public static void Main(string[] args)
        {
            inputs = Console.ReadLine().Split(' ');

            Permutation(0);
        }

        private static void Permutation(int index)
        {
            if (index >= inputs.Length)
            {
                Console.WriteLine(string.Join(" ", inputs));
                return;
            }

            Permutation(index + 1);

            for (int i = index + 1; i < inputs.Length; i++)
            {
                SwapElements(index, i);
                Permutation(index + 1);
                SwapElements(index, i);
            }
        }

        private static void SwapElements(int index, int i)
        {
            var temp = inputs[index];
            inputs[index] = inputs[i];
            inputs[i] = temp;
        }
    }
}

