namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.CopyNode(root);
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
            var node = this.Root;

            while (node != null)
            {
                if (IsGreater(element, node.Value))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(element, node.Value))
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
            InsertBFS(element);
            //InsertDFS(element, this.Root);
        }

        public void InsertBFS(T element)
        {
            var newNode = new Node<T>(element);

            if (this.Root == null)
            {
                this.Root = newNode;
                this.Count++;
                return;
            }

            var node = this.Root;
            Node<T> parentNode = null;

            while (node != null)
            {
                parentNode = node;

                if (IsGreater(element, node.Value))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(element, node.Value))
                {
                    node = node.RightChild;
                }
            }

            if (IsGreater(element, parentNode.Value))
            {
                parentNode.LeftChild = newNode;
            }
            else
            {
                parentNode.RightChild = newNode;
            }
            this.Count++;
        }

        private bool IsGreater(T element, T nodeValue)
        {
            return element.CompareTo(nodeValue) < 0;
        }

        private bool IsSmaller(T element, T nodeValue)
        {
            return element.CompareTo(nodeValue) > 0;
        }

        public void InsertDFS(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
                Root = node;
                this.Count++;
                return;
            }                       

            if (IsGreater(element, node.Value))
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element);
                    Count++;
                    return;
                }
                InsertDFS(element, node.LeftChild);
            }
            else if (IsSmaller(element, node.Value))
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element);
                    Count++;
                    return;
                }
                InsertDFS(element, node.RightChild);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var node = this.Root;

            while (node != null)
            {
                if (IsGreater(element, node.Value))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(element, node.Value))
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
            EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public List<T> Range(T lower, T upper)
        {
            var list = new List<T>();

            Range(lower, upper, this.Root, list);

            return list;
        }

        private void Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            var isStartRange = startRange.CompareTo(node.Value);
            var isEndRange = endRange.CompareTo(node.Value);

            if (isStartRange < 0)
            {
                Range(startRange, endRange, node.LeftChild, result);
            }

            if (isStartRange <= 0 && isEndRange >= 0)
            {
                result.Add(node.Value);
            }

            if (isEndRange > 0) 
            {
                Range(startRange, endRange, node.RightChild, result);
            }
        }

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.LeftChild =  DeleteMin(this.Root.LeftChild);
        }

        private Node<T> DeleteMin(Node<T> node)
        {           
            if (node.LeftChild == null)
            {
                Count--;
                return node.RightChild;
            }

            node.LeftChild = DeleteMin(node.LeftChild);
            return node;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.RightChild = DeleteMax(this.Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                Count--;
                return node.LeftChild;
            }

            node.RightChild = DeleteMin(node.RightChild);
            return node;
        }

        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }
    }
}
