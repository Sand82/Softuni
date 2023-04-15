
namespace BinaryTreeExercise
{
    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            this.Root = root;
        }
        public Node<T> Root { get; set; }

        public string DFSPreOrder(Node<T> root, int indent)
        {
            var result = $"{ new string(' ', indent)}{root.Value}\r\n";

            if (root.LeftChild != null)
            {
                result += DFSPreOrder(root.LeftChild, indent + 3);
            }

            if (root.RightChild != null)
            {
                result += DFSPreOrder(root.RightChild,indent + 3);
            }

            return result;
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

        public string DFSPostOrder(Node<T> root, int indent)
        {
            string result = "";

            if (root.LeftChild != null)
            {
                result += DFSPostOrder(root.LeftChild, indent + 3);
            }

            if (root.RightChild != null)
            {
                result += DFSPostOrder(root.RightChild, indent + 3);
            }

            result += $"{ new string(' ', indent)}{root.Value}\n";

            return result;
        }
    }
}
