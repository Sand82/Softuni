using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
   public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            Root = root;
        }
        public Node<T> Root { get; set; }

        public string DFSPreOrder(Node<T> node, int ident)
        {
            string result = $"{new string(' ', ident) }{node.Value}\n";

            if (node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, ident + 3);
            }

            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, ident + 3);
            }

            return result;
        }

        public string DFSInOrder(Node<T> node, int ident)
        {
            string result = string.Empty;

            if (node.LeftChild != null)
            {
               result += DFSInOrder(node.LeftChild, ident + 3);
            }

            result += $"{new string(' ', ident) }{node.Value}\n";

            if (node.RightChild != null)
            {
                result += DFSInOrder(node.RightChild, ident + 3);
            }

            return result;
        }

        public string DFSPostOrder(Node<T> node, int ident)
        {
            string result = string.Empty;

            if (node.RightChild != null)
            {
                result += DFSPostOrder(node.LeftChild, ident + 3);
            }

            if (node.RightChild != null)
            {
                result += DFSPostOrder(node.RightChild, ident + 3);
            }

            result += $"{new string(' ', ident) }{node.Value}\n";

            return result;
        }
    }
}
