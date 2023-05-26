using System;

namespace ImplementStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CoolStack<int> linkedList = new CoolStack<int>();


            for (int i = 0; i < 10; i++)
            {
                linkedList.Push(i);
            }

           

            while (linkedList.Count != null)
            {
                Console.WriteLine(linkedList.Pop());
                
            }

            

        }
    }
}
