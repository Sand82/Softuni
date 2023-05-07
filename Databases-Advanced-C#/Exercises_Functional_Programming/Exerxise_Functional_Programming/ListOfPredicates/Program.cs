namespace ListOfPredicates
{
    public class Program
    {
        public static void Main()
        {
            var maxNum = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int, int, bool> func = (x, y) => x % y != 0;

            var result = ExtractNumbers(func, maxNum, dividers);

            Console.WriteLine(String.Join(" ", result));
        }

        private static List<int> ExtractNumbers(Func<int, int, bool> func, int maxNum, int[] dividers)
        {
            var result = new List<int>();

            for (int i = 1; i <= maxNum; i++)
            {
                var currNum = i;

                var isDevider = true;

                for (int y = 0; y < dividers.Length; y++)
                {
                    var divider = dividers[y];

                    if (func(currNum, divider))
                    {
                        isDevider = false;
                        break;
                    }
                }

                if (isDevider)
                {
                    result.Add(currNum);
                }
            }

            return result;
        }
    }
}
