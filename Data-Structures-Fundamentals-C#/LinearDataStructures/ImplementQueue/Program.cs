using System;

namespace ImplementQueue
{
   public class Program
    {
        static void Main(string[] args)
        {
            CoolQueue<int> coolQueue = new CoolQueue<int>();

            for (int i = 0; i < 5; i++)
            {
                coolQueue.Enqueue(i);
            }

            while (coolQueue.Count != null)
            {
                Console.WriteLine(coolQueue.Dequeue());
                
            }
        }
    }
}
