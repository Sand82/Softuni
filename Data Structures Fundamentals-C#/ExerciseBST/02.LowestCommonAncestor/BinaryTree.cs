namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNode = Search(first);
            var secondNode = Search(second);

            if (firstNode == null || secondNode == null)
            {
                throw new DllNotFoundException();
            }

            var firstNodeParent = GetParent(firstNode);
            var secondNodeParent = GetParent(secondNode);

            var result = firstNodeParent.Intersect(secondNodeParent);

            return result.ToArray()[0];
        }

        private List<T> GetParent(BinaryTree<T> node)
        {
            var result = new List<T>();

            while (node != null)
            {
                result.Add(node.Value);
                node = node.Parent;
            }

            return result;
        }

        private BinaryTree<T> Search(T value)
        {
            var node = this;

            while (node != null)
            {

                if (value.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }
    }
}
