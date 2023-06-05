using System;

namespace NestedLoops
{ 
    public class Program
    {
        private static int[] result;
        
        private static int n;        

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());           

            result = new int[n];

            NestedLoops(0);
        }

        private static void NestedLoops(int index)
        {
            if (index >= result.Length)
            {                
                Console.WriteLine(String.Join(" ", result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[index] = i;
                NestedLoops(index + 1);
            }
        }
    }
}