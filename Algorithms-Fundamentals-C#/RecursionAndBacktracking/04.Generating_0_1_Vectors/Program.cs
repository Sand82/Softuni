using System;

namespace GeneratingVectors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            var index = 0;

            GeneratingVectors(arr, index);
        }

        private static void GeneratingVectors(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GeneratingVectors(arr, index + 1);
            }
        }
    }
}
