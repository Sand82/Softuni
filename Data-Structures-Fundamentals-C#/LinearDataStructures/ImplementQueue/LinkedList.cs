using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementQueue
{
    public class LinkedList<T>
    {        

        public Node<T> Head { get; set; }

        public Node<T> Last { get; set; }

        public int Count { get; private set; }

        public void AddLast(T element)
        {
            var newNode = new Node<T>(element);
                                
            if (Last == null)
            {
                
                Head = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            
            Count++;            
        }

        public Node<T> RemoveLast()
        {
            var oldLast = Head;

            if (oldLast.Next != null)
            {
                Head = oldLast.Next;
            }            
            return oldLast;
        }
    }
}
