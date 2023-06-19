using System;

namespace QuickSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine(String.Join(' ', arr));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = 0;
            var left = pivot + 1;
            var right = end;

            while (left <= right)
            {
                if (arr[left] > arr[right] && arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left += 1;
                }

                if (arr[right] >= arr[pivot])
                {
                    right -= 1;
                }
            }

            Swap(arr, pivot, right);

            if (right - 1 - start < end - (right + 1))
            {
                QuickSort(arr, start, right - 1);
                QuickSort(arr, right + 1, end);
            }
            else
            {
                QuickSort(arr, right + 1, end);
                QuickSort(arr, start, right - 1);
            }
        }

        private static void Swap(int[] arr, int firstElement, int secondElement)
        {
            var temp = arr[firstElement];
            arr[firstElement] = arr[secondElement];
            arr[secondElement] = temp;
        }
    }
}
