using System;

namespace BinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new List<int>() { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };

            var number = 150;

            var (index, isExist) = BinarySearch(arr, number);

            Console.Write(index.ToString() + ' ');
            Console.Write(isExist);
        }

        private static (int index, bool isExist) BinarySearch(List<int> arr, int number)
        {
            var left = 0;
            var right = arr.Count - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (arr[mid] == number)
                {
                    return (mid, true);
                }

                if (number > arr[mid])
                {
                    left = mid + 1;
                }

                if (number < arr[mid])
                {
                    right = mid - 1;
                }
            }

            return (-1, false);
        }
    }
}