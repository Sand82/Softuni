namespace KnightsOfHonor 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var tokens = input.Split(' ');

            Action<string> action = x => Console.WriteLine($"Sir {x}");

            PrintArray<string>(action, tokens);
        }
        static void PrintArray<T>(Action<string> action, string[] arr)
        {
            foreach (var item in arr)
            {
                action(item);
            }
        }
    }
}