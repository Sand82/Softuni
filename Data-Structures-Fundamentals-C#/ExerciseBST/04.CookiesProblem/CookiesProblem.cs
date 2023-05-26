using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);

            var smalestElement = bag.GetFirst();
            int stepsCount = 0;

            while (smalestElement < k && bag.Count > 1)
            {
                var smallestCookie = bag.RemoveFirst();
                var secondSmallestCookie = bag.RemoveFirst();

                var newCookie = (smallestCookie * 2) + secondSmallestCookie;

                bag.Add(newCookie);
                stepsCount++;

                smalestElement = bag.GetFirst();
            }

            return smalestElement >= k ? stepsCount : -1;
        }
    }
}
