namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
       
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            
            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
                Count++;
                return;
            }

            var oldHead = head;
            head.Previus = newNode;
            head = newNode;
            head.Next = oldHead;
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
                Count++;
                return;
            }
            var oldTail = tail;
            tail.Next = newNode;
            tail = newNode;
            tail.Previus = oldTail;
            Count++;
        }

        public T GetFirst()
        {
            CheckCount();
            return head.Item;
        }

        public T GetLast()
        {
            CheckCount();

            return tail.Item;
        }

        public T RemoveFirst()
        {
            CheckCount();

            var oldNode = head;
            head = head.Next;
            //head.Previus = null;
           
            Count--;

            return oldNode.Item;
        }

        public T RemoveLast()
        {
            CheckCount();

            var oldNode = tail;
            tail = tail.Previus;
            //tail.Next = null;

            Count--;
            return oldNode.Item;
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curhead = head;

            while (curhead != null)
            {
                yield return curhead.Item;
                curhead = curhead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckCount()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}