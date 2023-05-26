namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            CountCheck();

            var currTail = tail;
            bool isExist = false;

            while (currTail != null)
            {               
                if (currTail.Item.Equals(item))
                {
                    isExist = true;
                    break;
                }
                currTail = currTail.Next;
            }

            return isExist;
        }

        public T Dequeue()
        {
            CountCheck();
            var oldNode = tail;
            tail = tail.Next;
            Count--;
            return oldNode.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);            
            
            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
                Count++;
                return;
            }
            Count++;
            head.Next = newNode;
            head = newNode;           

        }

        public T Peek()
        {
            CountCheck();
            return tail.Item;
        }

        private void CountCheck()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = tail;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}