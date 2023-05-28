using System;
using System.Collections.Generic;

namespace QueensPuzzle
{
    public class Program
    {
        private static HashSet<int> attackRows = new HashSet<int>();
        private static HashSet<int> attackCows = new HashSet<int>();
        private static HashSet<int> attackLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackRightDiagonals = new HashSet<int>();

        public static void Main(string[] args)
        {
            var bord = new bool[8, 8];

            PutQueens(bord, 0);
        }

        private static void PutQueens(bool[,] bord, int row)
        {
            if (row >= bord.GetLength(0))
            {
                PrintBoat(bord);
            }

            for (int col = 0; col < bord.GetLength(1); col++)
            {
                if (CanPalceQueen(row, col))
                {
                    attackRows.Add(row);
                    attackCows.Add(col);
                    attackLeftDiagonals.Add(row - col);
                    attackRightDiagonals.Add(row + col);
                    bord[row, col] = true;

                    PutQueens(bord, row + 1);

                    attackRows.Remove(row);
                    attackCows.Remove(col);
                    attackLeftDiagonals.Remove(row - col);
                    attackRightDiagonals.Remove(row + col);
                    bord[row, col] = false;
                }
            }
        }

        private static void PrintBoat(bool[,] bord)
        {
            for (int row = 0; row < bord.GetLength(0); row++)
            {
                for (int col = 0; col < bord.GetLength(1); col++)
                {
                    if (bord[row,col] == true)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool CanPalceQueen(int row, int col)
        {
            return !attackRows.Contains(row) &&
                !attackCows.Contains(col) &&
                !attackLeftDiagonals.Contains(row - col) &&
                !attackRightDiagonals.Contains(row + col);
        }
    }
}
