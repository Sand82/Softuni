using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementQueue
{
    public class CoolQueue<T>
    {
        private LinkedList<T> linkedList;

        public CoolQueue()
        {
            linkedList = new LinkedList<T>();
        }

        public int Count { get { return linkedList.Count; } }

        public void Enqueue(T element)
        {
            linkedList.AddLast(element);
        }

        public T Peek()
        {
            return linkedList.Head.Value;
        }

        public T Dequeue()
        {
            return linkedList.RemoveLast().Value;
        }

    }
}
