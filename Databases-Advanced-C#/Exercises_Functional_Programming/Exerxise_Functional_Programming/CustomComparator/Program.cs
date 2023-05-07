namespace CustomComparator
{
    public class Program
    {
        public static void Main()
        {
           var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[],int[]> evenPredicate = x => x.Where(el => el % 2 == 0).ToArray();
            Func<int[],int[]> oddPredicate = x => x.Where(el => el % 2 != 0).ToArray();

            var result = SortArray(evenPredicate, oddPredicate, array);

            Console.WriteLine(String.Join(" ", result));
        }

        private static int[] SortArray(Func<int[], int[]> evenPredicate, Func<int[], int[]> oddPredicate, int[] arr)
        {
            var evenArray = evenPredicate(arr);
            var oddArray = oddPredicate(arr);

            return evenArray.Concat(oddArray).ToArray();
        }
    }
}
