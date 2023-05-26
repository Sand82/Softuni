using System;
using System.Linq;

namespace RecursiveArraySum 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var index = 0;

            var result = SumArray(arr, index);

            Console.WriteLine(result);
        }

        private static int SumArray(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] + SumArray(arr, index + 1);
        }
    }
}
