using System;

namespace Cinema
{
    public class Program
    {
        private static List<string> friends;

        private static List<string> nonStaticFriends;

        private static bool[] reservedPosition;

        public static void Main(string[] args)
        {
            friends = Console.ReadLine().Split(", ").ToList();         
                        
            reservedPosition = new bool[friends.Count];

            nonStaticFriends = new List<string>(friends);

            var commands = Console.ReadLine();

            while (true)
            {
                if (commands == "generate")
                {
                    break;
                }

                var commandsArray = commands.Split(" - ").ToArray();

                var name = commandsArray[0];
                var index = int.Parse(commandsArray[1]) - 1;

                friends[index] = name;
                reservedPosition[index] = true;

                nonStaticFriends.Remove(name);

                commands = Console.ReadLine();
            }

            OrderFrends(0);
        }

        private static void OrderFrends(int index)
        {
            if (index >= nonStaticFriends.Count)
            {
                PrintFriendsPosition();
                return;
            }

            OrderFrends(index + 1);

            for (int i = index + 1; i < nonStaticFriends.Count; i++)
            {
                Swap(index, i);
                OrderFrends(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = nonStaticFriends[i];
            nonStaticFriends[i] = nonStaticFriends[index];
            nonStaticFriends[index] = temp;
        }

        private static void PrintFriendsPosition()
        {            
            int nonReservedCount = 0;
            var result = new List<string>();

            for (int i = 0; i < reservedPosition.Length; i++)
            {
                if (reservedPosition[i])
                {
                    result.Add(friends[i]);                    
                }
                else
                {
                    result.Add(nonStaticFriends[nonReservedCount]);
                    nonReservedCount++;
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
