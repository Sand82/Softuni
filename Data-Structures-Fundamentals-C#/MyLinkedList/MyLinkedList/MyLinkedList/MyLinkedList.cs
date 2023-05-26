namespace MyLinkedList
{
    public class MyLinkedList<T>
    {
        public Node<T>? Head { get; set; }
        public Node<T>? Last { get; set; }       

        public void Add(T value)
        {
            var head = new Node<T>(value);

            if (Head == null)
            {
                Head = head;
                Last = head;
            }
            else
            {
                head.Next = Head;
                Head = head;
            }            
        }

        public void AddLast(T value)
        {
            var last = new Node<T>(value);

            if (Last == null)
            {
                Head = last;
                Last = last;
            }
            else
            {
                Last.Next = last;
                Last = last;
            }
        }

        public Node<T>? Remove()
        {
            if (Head == null)
            {
                return null;
            }

            var removedNode = Head;

            if (Head.Next == null)
            {
                Last = null;
                Head = null;
            }
            else
            {
                Head = Head.Next;
            }

            return removedNode;
        }       
    }
}
