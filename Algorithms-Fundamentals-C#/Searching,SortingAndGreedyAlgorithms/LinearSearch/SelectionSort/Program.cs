using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            SelectionSort(arr);

            Console.WriteLine(String.Join(" ", arr));
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var index = i;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        index = j;
                    }
                }

                Swap(arr, i, index);
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
