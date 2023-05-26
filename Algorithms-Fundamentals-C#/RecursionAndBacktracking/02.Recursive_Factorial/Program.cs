using System;

namespace RecursiveFactorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var result = FactorielRecursive(n);

            Console.WriteLine(result);
        }

        private static int FactorielRecursive(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * FactorielRecursive(n - 1);
        }
    }
}
