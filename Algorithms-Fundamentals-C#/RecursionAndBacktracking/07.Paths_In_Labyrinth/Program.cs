using System;
using System.Collections.Generic;
namespace PathsInLabyrinth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());

            var col = int.Parse(Console.ReadLine());

            char[,] martix = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    martix[i, j] = input[j];
                }
            }

            int startRow = 0;
            int startCol = 0;
            string direction = "";
            var directionResult = new List<string>();

            FindPats(martix, startRow, startCol, direction, directionResult);
        }

        private static void FindPats(char[,] matrix, int row, int col, string direction, List<string> directionResult)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == '*'|| matrix[row, col] == 'v')
            {
                return;
            }

            directionResult.Add(direction);

            if (matrix[row, col] == 'e')
            {
               
                Console.WriteLine(string.Join("", directionResult));
                directionResult.RemoveAt(directionResult.Count - 1);
                return;
            }

            matrix[row, col] = 'v';           

            FindPats(matrix, row - 1, col, "U", directionResult);  //Up
            FindPats(matrix, row + 1, col, "D", directionResult);  //Down
            FindPats(matrix, row, col - 1, "L", directionResult);  //Left
            FindPats(matrix, row, col + 1, "R", directionResult);  //Up

            matrix[row, col] = '-';
            directionResult.RemoveAt(directionResult.Count - 1);
        }
    }
}
