using System;
using System.Text;

namespace ImplementStack
{
    public class CoolStack<T>
    {
        private LinkedList<T> linkedList;

        public CoolStack()
        {
            linkedList = new LinkedList<T>();
        }

        public int Count { get { return linkedList.Count; } }

        public void Push(T element)
        {
            linkedList.Add(element);            
        }

        public Node<T> Peek()
        {
            return linkedList.Head;
        }

        public T Pop()
        {
            var element = linkedList.Remove().Value;           
            return element;
        }
    }
}
