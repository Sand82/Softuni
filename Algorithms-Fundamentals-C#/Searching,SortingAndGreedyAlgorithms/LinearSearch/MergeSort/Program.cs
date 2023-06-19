using System;

namespace MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = MergeSort(arr);

            Console.WriteLine(String.Join(' ', result));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];

            var mergeIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result[mergeIndex++] = left[leftIndex++];
                }
                else 
                {
                    result[mergeIndex++] = right[rightIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                result[mergeIndex++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                result[mergeIndex++] = right[i];
            }

            return result;
        }
    }
}
