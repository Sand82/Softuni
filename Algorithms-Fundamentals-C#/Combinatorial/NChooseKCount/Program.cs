using System;

namespace NChooseKCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());

            int k =int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k));
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 0 || col == 0 || row == col)
            {
                return 1;
            }

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
