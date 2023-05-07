using System;

namespace ActionPrint
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var tokens = input.Split(' ');

            Action<string> action = x => Console.WriteLine(x);

            PrintInput<string>(action, tokens);
        }
        static void PrintInput<T>(Action<string> action, string[] arr)
        {
            foreach (var item in arr)
            {
                action(item);
            }
        }
    }
}