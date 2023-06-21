using System;

namespace GreedyAlgoritms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var coints = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x));

            var targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> countOfCoints = new Dictionary<int, int>();

            var usedCointsCount = 0;

            while (targetSum > 0 && coints.Count > 0)
            {
               var coint = coints.Dequeue();

                var count = targetSum / coint;

                targetSum %= coint;

                if (count == 0)
                {
                    continue;
                }

                usedCointsCount += count;

                countOfCoints.Add(coint, count);
            }

            if (targetSum > 0)
            {
                Console.WriteLine("Error ");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {usedCointsCount}");

                foreach (var coint in countOfCoints)
                {
                    Console.WriteLine($"{coint.Key} coin(s) with value {coint.Value}");
                }
            }
        }
    }
}
