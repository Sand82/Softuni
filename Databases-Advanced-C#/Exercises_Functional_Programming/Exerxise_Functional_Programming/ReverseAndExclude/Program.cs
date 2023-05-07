namespace ReverseAndExclude
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var number = int.Parse(Console.ReadLine());

            Func<int[], int, int[]> function = (x, y) => x.Where(e => e % y != 0).Reverse().ToArray();

            var result = DivideArray(function, number, array);            

            Console.WriteLine(String.Join(" ", result));
        }

        private static int[] DivideArray(Func<int[], int, int[]> func, int number, int[] arr)
        {
            return func(arr, number);
        }
    }
}
