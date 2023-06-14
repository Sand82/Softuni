using System;

namespace BinarySearchRecursive
{
    public class Program
    {
        private static int left;
        private static int right;
        private static int mid;

        public static void Main(string[] args)
        {
            var arr = new List<int>() { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };

            var number = 10;

            left = 0;
            right = arr.Count - 1;

            mid = (left + right) / 2;

            BinarySearch(arr, number);          
        }

        private static void BinarySearch(List<int> arr, int number)
        {           

            if (left > right)
            {                
                Console.WriteLine(-1);
                return;
            }

            if (arr[left] == number)
            {
                Console.WriteLine(left);
                return;
            }

            if (number > arr[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }

            mid = (left + right) / 2;

            BinarySearch(arr, number);
        }
    }
}