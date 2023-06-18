using System;

namespace InsertionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = InsertionSopr(arr);

            Console.WriteLine(String.Join(' ', result));
        }

        private static int[] InsertionSopr(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;

                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j, j - 1);

                    j -= 1;
                }
            }

            return arr;
        }

        private static void Swap(int[] arr, int firstElement, int secondElement)
        {
            var temp = arr[firstElement];
            arr[firstElement] = arr[secondElement];
            arr[secondElement] = temp;
        }
    }
}
