using System;

namespace App
{
    public class Program
    {
        public static void Main()
        {
            var inputRange = Console.ReadLine();
            var tokens = inputRange.Split(' ').Select(x => int.Parse(x)).ToList();

            var command = Console.ReadLine();

            switch (command)
            {
                case "odd":
                    Func<int, bool> predicateOdd = x => x % 2 != 0;
                    ProntNumbers(predicateOdd, tokens[0], tokens[1]);
                    break;
                case "even":
                    Func<int, bool> predicateEven = x => x % 2 == 0;
                    ProntNumbers(predicateEven, tokens[0], tokens[1]);
                    break;
                default:
                    break;
            }
        }

        static void ProntNumbers( Func<int, bool> predicate, int minRange, int maxRange)
        {
            var result = new List<int>();

            for (int i = minRange; i <= maxRange; i ++)
            {
                result.Add(i);
            }

            result = result.Where(predicate).ToList();

            Console.WriteLine(String.Join(" ",result));
        }
    }
}
