
using _01._BrowserHistory.Interfaces;

namespace _01._BrowserHistory
{
    public class Node
    {
        public Node(ILink value)
        {
            Value = value;
        }

        public ILink Value { get; set; }

        public Node Next { get; set; }

        public Node Previus { get; set; }
    }
}
