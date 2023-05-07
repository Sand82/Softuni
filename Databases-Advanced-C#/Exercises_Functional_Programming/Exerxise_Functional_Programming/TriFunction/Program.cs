using System;

namespace TriFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var maxNumber = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(" ");

            Func<string, int, bool> nameValidator = (x, y) => ValidateName(x, y);

            Func< string[], Func<string, int, bool>, string[]> mainFunc = (x, y) => x.Where(el => y(el, maxNumber)).ToArray();

            var result = mainFunc(names, nameValidator);

            Console.WriteLine(String.Join(" ",result));
        }

        private static bool ValidateName(string name, int maxNumber)
        {
            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char symbol = name[i];

                sum += symbol;
            }

            return sum >= maxNumber;
        }
    }
}
