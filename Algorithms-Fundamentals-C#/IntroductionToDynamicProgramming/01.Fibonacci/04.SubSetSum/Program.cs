using System;

namespace SubsetSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var nums = new int [] { 3, 5, 1, 4, 2 };

            var target = 10;

            var possibleSums = PosibleSum(nums);

            var result = FindNumbersInTarget(possibleSums, target);

            Console.WriteLine(String.Join(' ',result));

        }

        private static List<int> FindNumbersInTarget(Dictionary<int, int> possibleSums, int target)
        {
            var result = new List<int>();

            while (target > 0)
            {
                var taregtNumber = possibleSums[target];

                result.Add(taregtNumber);

                target -= taregtNumber;
            }

            return result;
        }

        private static Dictionary<int, int> PosibleSum(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0}, };

            foreach (var num in nums)
            {
                var currentSum = sums.Keys.ToArray();

                foreach (var sum in currentSum)
                {
                    var newsum = sum + num;

                    if (!sums.ContainsKey(newsum))
                    {
                        sums[newsum] = num;
                    }                    
                }                
            }

            return sums;
        }
    }
}