using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementLinkedList
{
    public class LinkedList<T>
    {
        public  Node<T> Head { get; set; }
        public  Node<T> Last { get; set; }      
        
        public void Add(T element)
        {
            Node<T> newHead = new Node<T>(element);

            if (Head == null)
            {
                Last = newHead;

            }
            newHead.Next = Head;
            Head = newHead;
        }

        public void AddLast(T element)
        {
            Node<T> newLast = new Node<T>(element);

            if (Last == null)
            {
                Last = newLast;
                Head = newLast;

            }
            Last.Next = newLast;
            Last = newLast;
        }

        public Node<T> Remove()
        {
            var oldHead = Head;

            if (Head == null)
            {
                Last = null;
            }


            Head = Head.Next;
            return oldHead;
        }
    }
}
