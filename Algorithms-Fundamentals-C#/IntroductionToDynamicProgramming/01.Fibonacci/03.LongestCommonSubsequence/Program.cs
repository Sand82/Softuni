using System;

namespace LongestCommonSubsequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var matrix = new int[firstStr.Length + 1, secondStr.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {

                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row, col - 1], matrix[row - 1, col]);
                    }
                }
            }

            Console.WriteLine(matrix[firstStr.Length, secondStr.Length]);
        }
    }
}