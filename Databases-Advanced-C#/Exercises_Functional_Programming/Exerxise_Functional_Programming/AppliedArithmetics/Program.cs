using System;

namespace AppliedArithmetics
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        ManipulateArray(x => AddInArray(x), array);
                        break;
                    case "multiply":
                        ManipulateArray(x => MultiplayInArray(x), array);
                        break;
                    case "subtract":
                        ManipulateArray(x => SubstractInArray(x), array);
                        break;
                    case "print":
                        ManipulateArray(x => PrintArray(x), array);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void AddInArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 1;
            }
        }

        private static void MultiplayInArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= 2;
            }
        }

        private static void SubstractInArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] -= 1;
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(String.Join(" ", arr));
        }

        public static void ManipulateArray(Action<int[]> action, int[] arr)
        {
            action(arr);
        }
    }
}