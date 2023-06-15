using System;
using System.Linq;
using System.Collections.Generic;

namespace BubbleSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {               
                for (int j = 1; j < arr.Length - i; j++)
                {                   
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(arr, j - 1, j);
                    }
                }
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
