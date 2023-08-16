using System;

namespace WordDifferences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = col;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {

                var firstChar = str1[row - 1];

                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    var seconfChar = str2[col - 1];

                    if (firstChar == seconfChar)
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        var res = Math.Min(matrix[row - 1, col], matrix[row, col - 1]);
                        matrix[row, col] = res + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {matrix[str1.Length, str2.Length]}");
        }
    }
}