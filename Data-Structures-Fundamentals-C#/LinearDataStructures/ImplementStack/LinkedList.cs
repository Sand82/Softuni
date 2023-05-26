using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementStack
{
    public class LinkedList<T>    {
        
        public void Add(T element)
        {
            var newNode = new Node<T>(element);
            
            Count++;
            newNode.Next = Head;
            Head = newNode;
        }

        public Node<T> Head { get; set; }

        public int Count { get; private set; }

        public Node<T> Remove()
        {
            var currNode = Head;
            Head = Head.Next;
                                  

            if (Count> 0)
            {
                Count--;
            }
            return currNode;
        }
    }
}
