using System;
using System.Linq;
using System.Collections.Generic;

namespace PermutationsWithoutRepetition 
{
    public class Program
    {
        private static string[] inputs;
        private static string[] currentPermutations;
        private static bool[] usedElements;

        public static void Main()
        {
            inputs = Console.ReadLine().Split(' ');
            currentPermutations = new string[inputs.Length];
            usedElements = new bool[inputs.Length];            

            Permutations(0);
        }

        private static void Permutations(int index)
        {
            if (index >= currentPermutations.Length)
            {
                Console.WriteLine(string.Join(" ", currentPermutations));
                return;
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                if (!usedElements[i])
                {
                    usedElements[i] = true;
                    currentPermutations[index] = inputs[i];
                    Permutations(index + 1);
                    usedElements[i] = false;
                }                
            }
        }
    }
}
