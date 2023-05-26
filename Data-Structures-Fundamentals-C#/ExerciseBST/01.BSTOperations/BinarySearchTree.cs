namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {            
            CopyNode(root);
        }

        private void CopyNode(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value);
                this.CopyNode(node.LeftChild);
                this.CopyNode(node.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            var isExist = Contains(Root, element);

            return isExist;
        }

        private bool Contains(Node<T> node, T element)
        {
            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            Count++;
            if (Root == null)
            {
                this.Root = new Node<T>(element);
                return;
            }

            Insert(Root, element);
        }

        private void Insert(Node<T> node, T element)
        {
            var newNode = new Node<T>(element);

            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = newNode;
                    return;
                }

                Insert(node.LeftChild, element);
            }

            if (node.Value.CompareTo(element) <= 0)
            {
                if (node.RightChild == null)
                {
                    node.RightChild = newNode;
                    return;
                }

                Insert(node.RightChild, element);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var node = Root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node == null ? null : new BinarySearchTree<T>(node);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, Root);            
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.LeftChild);
            action(node.Value);
            EachInOrder(action, node.RightChild);
        }

        public List<T> Range(T lower, T upper)
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }

            var nodes = new List<T>();

            Range(lower, upper, Root, nodes);

            return nodes;
        }
                               
        private void Range(T startBound, T endBound, Node<T> node, List<T> nodes)
        {
            if (node == null)
            {
                return;
            }
            
            var inStartRange = startBound.CompareTo(node.Value);
            var inEndRange = endBound.CompareTo(node.Value);

            if (inStartRange < 0)
            {
                Range(startBound, endBound, node.LeftChild, nodes);
            }

            if (inStartRange <= 0 && inEndRange >= 0)
            {
                nodes.Add(node.Value);
            }

            if (inEndRange > 0)
            {
                Range(startBound, endBound, node.RightChild, nodes);
            }
        }

        public void DeleteMin()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }

             DeleteMin(Root);
             Count--;
            //this.Root.LeftChild = DeleteMinRecursive(Root.LeftChild);

        }

        private Node<T> DeleteMinRecursive(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                Count--;
                return node.RightChild;
            }

            node.LeftChild = DeleteMinRecursive(node.LeftChild);
            return node;
        }

        private void DeleteMin(Node<T> node)
        {
            Node<T> parentNode = node;

            while (node != null)
            {
                if (node.LeftChild == null)
                {
                    if (node.RightChild != null)
                    {
                        parentNode = node;
                    }
                    break;
                }
                parentNode = node;
                node = node.LeftChild;
            }

            if (parentNode.RightChild != null && parentNode.LeftChild == null)
            {
                parentNode.Value = parentNode.RightChild.Value;
                parentNode.RightChild = null;
                return;               
            }
            else
            {
                parentNode.LeftChild = null;
                return;
            }
        }

        public void DeleteMax()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }

            DeleteMax(Root);
            Count--;
        }

        private void DeleteMax(Node<T> node)
        {
            Node<T> parentNode = node;

            while (node != null)
            {
                if (node.RightChild == null)
                {
                    if (node.LeftChild != null)
                    {
                        parentNode = node;
                    }
                    break;
                }
                parentNode = node;
                node = node.RightChild;
            }

            if (parentNode.LeftChild != null && parentNode.RightChild == null)
            {
                parentNode.Value = parentNode.LeftChild.Value;
                parentNode.LeftChild = null;
                return;
            }
            else
            {
                parentNode.RightChild = null;
                return;
            }
        }

        public int GetRank(T element)
        {
            int result = 0;

            var queue = new Queue<Node<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
               var currNode = queue.Dequeue();

                if (currNode.LeftChild != null)
                {
                    queue.Enqueue(currNode.LeftChild);                    
                }

                if (currNode.RightChild != null)
                {
                    queue.Enqueue(currNode.RightChild);                   
                }

                result += element.CompareTo(currNode.Value) > 0 ? 1 : 0;
            }

            return result;
        }       
    }
}
