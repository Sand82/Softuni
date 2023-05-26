using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);
            var smallesElement = bag.GetFirst();
            var steps = 0;

            while (smallesElement < k && bag.Count >= 2)
            {
                var firstSmallestCookie = bag.RemoveFirst();
                var secondSmallestCookie = bag.RemoveFirst();

                steps++;
                bag.Add(firstSmallestCookie + (2 * secondSmallestCookie));
                smallesElement = bag.GetFirst();
            }

            return smallesElement >= k ? steps : -1;
        }
    }
}
