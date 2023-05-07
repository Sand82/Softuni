using System;

namespace CustomMinFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var tokens = input.Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            Func<int[], int> func = x => SmallestInteger(x);

            Console.WriteLine(func(tokens));
        }

        static int SmallestInteger(int [] arr)
        {
            var result = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (result > arr[i])
                {
                    result = arr[i];
                }
            }

            return result;
        }
    }
}
