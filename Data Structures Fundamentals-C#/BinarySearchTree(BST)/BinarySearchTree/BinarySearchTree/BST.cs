namespace BinarySearchTree
{
    public class BST<T> where T : IComparable<T>
    {
        public BST(Node<T> root = null)
        {
            this.Root = root;
        }

        public Node<T> Root { get; set; }

        public void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                Root = new Node<T>(value);
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }

                Insert(value, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }

                Insert(value, node.RightChild);
            }
        }

        public bool Contains(T value, Node<T> node)
        {
            if (node == null)
            {                
                return false;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return Contains(value, node.LeftChild);
            }
            else
            {
                return Contains(value, node.RightChild);
            }
        }

        public string DFSInOrder(Node<T> root, int indent)
        {
            string result = "";

            if (root.LeftChild != null)
            {
                result += DFSInOrder(root.LeftChild, indent + 3);
            }

            result += $"{ new string(' ', indent)}{root.Value}\n";

            if (root.RightChild != null)
            {
                result += DFSInOrder(root.RightChild, indent + 3);
            }

            return result;
        }
    }

}
