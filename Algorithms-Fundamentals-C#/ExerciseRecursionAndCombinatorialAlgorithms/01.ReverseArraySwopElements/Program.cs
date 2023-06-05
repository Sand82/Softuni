using System;

namespace ReverseArraySwopElements
{
    public class Program
    {
        private static int[] arr;
        public static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            ReverceArr(0);
        }

        private static void ReverceArr(int index)
        {
            if (index == arr.Length / 2)
            {
                return;
            }

            var temp  = arr[index];
            arr[index] = arr[arr.Length - index - 1];
            arr[arr.Length - index - 1] = temp;
            
            ReverceArr(index + 1);
        }
    }
}