using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        public static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());

            var result = CalcFibo(n);

            Console.WriteLine(result);
        }

        private static long CalcFibo(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n < 2)
            {
                return n;
            }            

            var result = CalcFibo(n - 1) + CalcFibo(n - 2);

            cache[n] = result;

            return result;
        }
    }
}
