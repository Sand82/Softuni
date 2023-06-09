using System;

namespace SchoolTeams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ").ToList();
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();

            CreateTeams(0, 0, girls, girlsComb, girlsCombs);

            var boys = Console.ReadLine().Split(", ").ToList();
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();

            CreateTeams(0, 0, boys, boysComb, boysCombs);

            PrintTeams(girlsCombs, boysCombs);
        }

        private static void PrintTeams(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girls in girlsCombs)
            {
                foreach (var boys in boysCombs)
                {
                    Console.WriteLine(String.Join(", ",girls) + ", " + String.Join(", ", boys));
                }
            }
        }

        private static void CreateTeams(int index, int start, List<string> girls, string[] comb, List<string[]> combs)
        {
            if (index >= comb.Length)
            {
                combs.Add(comb.ToArray());
                return;
            }

            for (int i = start; i < girls.Count; i++)
            {
                comb[index] = girls[i];
                CreateTeams(index + 1, i + 1, girls, comb, combs);
            }
        }
    }
}
