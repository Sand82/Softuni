using System;

namespace PredicateParty
{
    public class Program
    {
        public static void Main()
        {
            var allGuests = Console.ReadLine().Split(" ");

            var command = Console.ReadLine().Split(" ").ToArray();

            Func<string[], string, string[]> funcStringArgument = null;
            Func<string[], int, string[]> funcNumArgument = null;

            while (true)
            {
                if (command[0] == "Party!")
                {                    
                    break;
                }

                var commandParts = $"{command[0]} {command[1]}";               

                switch (commandParts)
                {                   
                    case "Double StartsWith":
                        funcStringArgument = (x, y) => DoubleArrayElement(x, y, (x, y) => x.StartsWith(y));
                        allGuests = funcStringArgument(allGuests, command[2]);
                        break;
                    case "Double EndsWith":
                        funcStringArgument = (x, y) => DoubleArrayElement(x, y, (x, y) => x.EndsWith(y));
                        allGuests = funcStringArgument(allGuests, command[2]);
                        break;
                    case "Double Length":
                        funcNumArgument = (x, y) => DoubleArrayElement(x, y, (x, y) => x.Length == y);
                        allGuests = funcNumArgument(allGuests, int.Parse(command[2]));
                        break;
                    case "Remove StartsWith":
                        funcStringArgument = (x, y) => RemoveArrayElement(x, y, (x, y) => x.StartsWith(y));
                        allGuests = funcStringArgument(allGuests, command[2]);
                        break;
                    case "Remove EndsWith":
                        funcStringArgument = (x, y) => RemoveArrayElement(x, y, (x, y) => x.EndsWith(y));
                        allGuests = funcStringArgument(allGuests, command[2]);
                        break;
                    case "Remove Length":
                        funcNumArgument = (x, y) => RemoveArrayElement(x, y, (x, y) => x.Length == y);
                        allGuests = funcNumArgument(allGuests, int.Parse(command[2]));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split(" ").ToArray();
            }

            if (allGuests.Length > 0)
            {
                Console.WriteLine($"{String.Join(", ", allGuests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }

        private static string[] DoubleArrayElement(string[] arr, string argument, Func<string, string, bool> predicate)
        {
            var result = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                var element = arr[i];

                if (predicate(element, argument))
                {
                    result.Add(element);
                }

                result.Add(element);
            }

            return result.ToArray();
        }

        private static string[] DoubleArrayElement(string[] arr, int argument, Func<string, int, bool> predicate)
        {
            var result = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                var element = arr[i];

                if (predicate(element, argument))
                {
                    result.Add(element);                    
                }

                result.Add(element);
            }

            return result.ToArray();
        }

        private static string[] RemoveArrayElement(string[] arr, string argument, Func<string, string, bool> predicate)
        {
            var result = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                var element = arr[i];

                if (!predicate(element, argument))
                {
                    result.Add(element);                    
                }
            }

            return result.ToArray();
        }

        private static string[] RemoveArrayElement(string[] arr, int argument, Func<string, int, bool> predicate)
        {
            var result = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                var element = arr[i];

                if (!predicate(element, argument))
                {
                    result.Add(element);                   
                }
            }

            return result.ToArray();
        }
    }
}
