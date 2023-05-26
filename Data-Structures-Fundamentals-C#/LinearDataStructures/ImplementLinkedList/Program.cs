using System;

namespace ImplementLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node<int> head = new Node<int>(1);
            //Node<int> node1 = new Node<int>(2);
            //Node<int> node2 = new Node<int>(3);
            //Node<int> node3 = new Node<int>(4);

            //head.Next = node1;
            //node1.Next = node2;
            //node2.Next = node3;

            //Node<int> currNode = head;

            //while (currNode != null)
            //{
            //    Console.WriteLine(currNode.Value);
            //    currNode = currNode.Next;
            //}

            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.Add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }           

            //linkedList.Remove();
            //linkedList.Remove();
            //linkedList.Remove();            

            var currNode = linkedList.Head;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Next;
            }

        }
    }
}
