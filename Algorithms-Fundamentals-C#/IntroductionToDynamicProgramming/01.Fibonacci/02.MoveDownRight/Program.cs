using System;

namespace MoveDownRight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {

                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];


            for (int col = 1; col < cols; col++)
            {
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var upper = dp[row - 1, col];
                    var left = dp[row, col - 1];

                    dp[row, col ] = Math.Max(upper, left) + matrix[row, col];
                }
            }

            var path = new Stack<string>();

            var r = rows - 1;
            var c = cols - 1;

            while (r > 0 && c > 0)
            {
                path.Push($"[{r}, {c}] ");

                var upper = dp[r - 1, c];
                var left = dp[r, c - 1];

                if (upper > left)
                {
                    r -= 1;                    
                }
                else
                {
                    c -= 1;
                }
            }

            while (r > 0)
            {
                path.Push($"[{r}, {c}] ");
                r -= 1;
            }

            while (c > 0)
            {
                path.Push($"[{r}, {c}] ");
                c -= 1;
            }

            path.Push($"[0, 0] ");

            foreach (var item in path)
            {
                Console.Write(item);
            }
        }
    }
}