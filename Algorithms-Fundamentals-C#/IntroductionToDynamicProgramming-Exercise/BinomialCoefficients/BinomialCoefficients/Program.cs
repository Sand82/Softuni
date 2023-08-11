using System;

namespace BinomialCoefficients
{
    public class Program
    {
        private static Dictionary<string, long> memo;
        public static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            memo = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {
            if (col == 0 || row == col)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);

            memo[key] = result;

            return result;
        }
    }
}