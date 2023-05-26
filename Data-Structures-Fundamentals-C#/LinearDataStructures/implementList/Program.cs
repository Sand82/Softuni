using System;

namespace implementList
{
    class Program
    {
        static void Main(string[] args)
        {
            CoolList<int> coolList = new CoolList<int>();

            for (int i = 0; i <6; i++)
            {
                coolList.add(i);             
            }
                       
            
            coolList.Remove();
            coolList.RemoveAtt(2);

            for (int i = 0; i < coolList.Count; i++)
            {
                Console.WriteLine(coolList[i]);
            }
        }    
    }
}
