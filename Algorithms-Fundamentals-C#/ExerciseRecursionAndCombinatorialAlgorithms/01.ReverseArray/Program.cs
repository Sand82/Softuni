using System;
using System.Linq;

namespace ReverseArray
{
    public class Program
    {
        private static int[] arr;

        private static int[] result;

        private static int counter = 0;

        public static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            result = new int[arr.Length];

            var index = arr.Length - 1;

            ReverseArray(index);
        }

        private static void ReverseArray(int index)
        {
            if (index == 0)
            {
                result[counter] = arr[index];                
                Console.WriteLine(String.Join(" ", result));
                return;
            }

            result[counter] = arr[index];
            counter++;
            ReverseArray(index - 1);
        }
    }
}

