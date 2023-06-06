using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectedAreasInMatrix
{
    public class Area
    {
        public Area(int row, int col, int count)
        {
            Row = row;
            Col = col;
            Count = count;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Count { get; set; }
    }

    public class Program
    {
        private static char[,] matrix;

        private static int count;

        private static List<Area> areas = new List<Area>();

        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                string inputCol = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputCol[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    count = 0;

                    CheckCordinates(row, col);

                    if (count > 0)
                    {
                        var area = new Area(row, col, count);

                        areas.Add(area);
                    }
                }
            }

            var sorted = areas.OrderByDescending(x => x.Count).ThenBy(x => x.Row).ThenBy(x => x.Col).ToList();

            Console.WriteLine($"Total areas found: {sorted.Count}");

            var inpitCounter = 1;
            foreach (var item in sorted)
            {
                Console.WriteLine($"Area #{inpitCounter} at ({item.Row}, {item.Col}), size: {item.Count}");
                inpitCounter++;
            }
        }

        private static void CheckCordinates(int row, int col)
        {
            if (CheckBounderies(row, col))
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            count++;
            matrix[row, col] = 'v';

            CheckCordinates(row + 1, col); //Down
            CheckCordinates(row - 1, col); //Up
            CheckCordinates(row, col - 1); // Left
            CheckCordinates(row, col + 1); // Right

        }

        private static bool CheckBounderies(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
