
namespace _01._BrowserHistory
{
    public class LinkedList
    {
        public Node Head { get; private set; }

        public Node Last { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Last = node;
            }
            else
            {
                var oldHead = Head;
                Head.Previus = node;
                Head = node;
                Head.Next = oldHead;
            }

            Count++;
        }

        public void AddLast(Node node)
        {
            if (Last == null)
            {
                Head = node;
                Last = node;
            }
            else
            {
                var oldLast = Last;
                Last.Next = node;
                Last = node;
                Last.Previus = oldLast;
            }

            Count++;
        }

        public Node RemoveFirst()
        {
            Node result = null;

            if (Count == 0)
            {
                return result;
            }
            else
            {
                var oldHead = Head;
                Head = oldHead.Next;
                Head.Previus = null;
                oldHead.Next = null;

                result = oldHead;
            }

            Count--;

            return result;
        }

        public Node RemoveLast()
        {
            Node result = null;

            if (Count == 0)
            {
                return result;
            }
            else
            {
                var oldLast = Last;
                Last = oldLast.Previus;
                Last.Next = null;
                oldLast.Previus = null;

                result = oldLast;
            }
            Count--;

            return result;
        }

        public Node RemoveNode(Node node)
        {
            var priveusNode = node.Previus;
            var nextNode = node.Next;
            priveusNode.Next = nextNode;
            nextNode.Previus = priveusNode;
            Count--;

            return node;
        }
    }
}
