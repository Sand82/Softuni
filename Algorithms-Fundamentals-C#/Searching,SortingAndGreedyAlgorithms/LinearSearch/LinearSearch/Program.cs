using System;

namespace LinerSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new List<int>() { 4, 5, 3, 2, 1 };

            var element = 22;

            int result = LenearSearch(arr, element);

            Console.WriteLine(result);
        }

        private static int LenearSearch(List<int> arr, int element)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
