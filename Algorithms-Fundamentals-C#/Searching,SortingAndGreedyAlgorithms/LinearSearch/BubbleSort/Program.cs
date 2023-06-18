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
            var isSorted = false;
            var sortCount = 0;

            while(!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < arr.Length - sortCount; j++)
                {                   
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(arr, j - 1, j);
                        isSorted = false;
                    }
                } 
                sortCount++;
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
