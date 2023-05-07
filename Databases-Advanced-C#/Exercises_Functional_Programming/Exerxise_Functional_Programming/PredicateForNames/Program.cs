using System;

namespace PredicateForNames 
{
    public class Program
    {
        public static void Main()
        {
            var nameLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(" ");

            Func<string[], int, string[]> func = (x, y) => x.Where(el => el.Length <= y).ToArray();

            var result = ExtractStringLength(func, nameLength, names);

            Console.WriteLine(String.Join(" ", result));
        }

        private static string[] ExtractStringLength(Func<string[], int, string[]> func, int number, string[] arr)
        {
            return func(arr, number);
        }
    }
}
