using System;

namespace ThePartReservationFilterModuel
{
    public class Program
    {
        public static void Main()
        {
            var partyList = Console.ReadLine().Split(" ");

            var command = Console.ReadLine().Split(";");

            var commandsFictionary = new Dictionary<string, Func<string[], string, string[]>>();

            while (true) //Add filter;Starts with;P
            {

                if (command[0] == "Print")
                {
                    break;
                }

                var filterType = command[1];
                var filterArgument = command[2];

                if (command[0].Contains("Remove"))
                {  
                    commandsFictionary.Remove(filterArgument);
                }
                else
                {                    
                    commandsFictionary.Add(filterArgument, CommandList(filterType));
                }

                command = Console.ReadLine().Split(";");
            }

            foreach (var commandFunc in commandsFictionary)
            {
               partyList = commandFunc.Value(partyList, commandFunc.Key);
            }

            Console.WriteLine(String.Join(" ",partyList));
        }

        private static Func<string[], string, string[]> CommandList(string key)
        {
            var commandsDictionary = new Dictionary<string, Func<string[], string, string[]>>()
            {
                {"Starts with", (x, y) => x.Where(el => !el.StartsWith(y)).ToArray()},
                {"Ends with", (x, y) => x.Where(el => !el.EndsWith(y)).ToArray()},
                {"Contains", (x, y) => x.Where(el => !el.Contains(y)).ToArray()},
                {"Length", (x, y) => x.Where(el => el.Length != int.Parse(y)).ToArray()},
            };

            return commandsDictionary[key];
        }
    }
}
