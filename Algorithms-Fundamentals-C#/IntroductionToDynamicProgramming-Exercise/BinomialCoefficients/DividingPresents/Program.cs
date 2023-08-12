using System;

namespace DividingPresents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var presonts = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();            

            var allSums = FindAllSums(presonts);

            var totallSum = presonts.Sum();

            var half = totallSum / 2;

            var admaPresents = half;

            while(true)
            {
                if (allSums.ContainsKey(admaPresents))
                {
                    break;
                }

                admaPresents--;
            }

            var bobPresunts = totallSum - admaPresents;

            Console.WriteLine($"Difference: {bobPresunts - admaPresents}");
            Console.WriteLine($"Alan:{admaPresents} Bob:{totallSum-admaPresents}");

            var adamsPresentsColection = GetAddamPresonts(allSums, admaPresents);
            Console.WriteLine(String.Join(' ', adamsPresentsColection));
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetAddamPresonts(Dictionary<int, int> allSums, int admaPresents)
        {
            var result = new List<int>();

            while (admaPresents > 0)
            {
                var currPresont = allSums[admaPresents];

                result.Add(currPresont);

                admaPresents -= currPresont;
            }

            return result;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int>{ { 0, 0} };

            foreach (var element in elements)
            {
                var curSums = sums.Keys.ToArray();

                foreach (var curSum in curSums)
                {
                    var newSum = curSum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}