namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
            LeftChild = root.LeftChild;
            RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {            
            if (this.Root == null)
            {
                return false;
            }

            if (this.Root.Value.CompareTo(element) == 0)
            {
                return true;
            }

            if (element.CompareTo(this.Root.Value) > 0)
            {
                return Contains(this.Root.LeftChild.Value);
            }
            else
            {
                return Contains(this.Root.RightChild.Value);
            }
        }
            
        public void Insert(T element)
        {            

            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
            }

            if (element.CompareTo(this.Root.Value) > 0)
            {
                if (this.Root.LeftChild == null)
                {
                    this.Root.LeftChild = new Node<T>(element, null, null);
                }

                Insert(this.Root.LeftChild.Value);
                return;
            }
            else
            {
                if (this.Root.RightChild == null)
                {
                    this.Root.RightChild = new Node<T>(element, null, null);
                }

                Insert(this.Root.RightChild.Value);
                return;
            }
        }        

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if (this.Root == null)
            {
                return null;
            }

            if (this.Root.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(this.Root);
            }

            if (element.CompareTo(this.Root.Value) > 0)
            {
                return Search(this.Root.LeftChild.Value);
            }
            else
            {
                return Search(this.Root.RightChild.Value);
            }
        }        
    }
}
