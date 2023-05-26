using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        private bool RoodDelete = false;

        public Tree(T value)
        {
            Value = value;
            _children = new List<Tree<T>>();
            Parent = null;            
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
       
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var list = new List<T>();
            var queue = new Queue<Tree<T>>();

            if (this == null)
            {
                return list;
                
            }           
            
            queue.Enqueue(this);

            if (this.RoodDelete)
            {
                return list;
            }

            while (queue.Count != 0)
            {
                Tree<T> parentChild = queue.Dequeue();
                list.Add(parentChild.Value);

                foreach (var child in parentChild.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return list;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (this.RoodDelete)
            {
                return result;
            }

            this.Dfs(this, result);

            return result;
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var serchedNode = this.FindBFS(parentKey);

            CheckEmptyNode(serchedNode);

            serchedNode._children.Add(child);            
        }

        private void CheckEmptyNode(Tree<T> serchedNode)
        {
            if (serchedNode == null)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindBFS(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();           

            if (this == null)
            {
                return null;
            }            

            if (this.Value.Equals(parentKey))
            {
                return this;
            }

            queue.Enqueue(this);
                       
            while (queue.Count != 0)
            {
                var childTree = queue.Dequeue();                

                foreach (var child in childTree.Children)
                {
                    queue.Enqueue(child);

                    if (child.Value.Equals(parentKey))
                    {                       
                        return child;
                    }
                }
            }

            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            var serchedNode = FindBFS(nodeKey);
            CheckEmptyNode(serchedNode);

            var searchNodeParent = serchedNode.Parent;
                      

            if (searchNodeParent == null)
            {
                this._children.Clear();
                serchedNode = null;
                this.RoodDelete = true;
            }
            else
            {
                searchNodeParent._children.Remove(serchedNode);
            }            
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindBFS(firstKey);
            CheckEmptyNode(firstNode);
            var secondNode = FindBFS(secondKey);
            CheckEmptyNode(secondNode);
                       
            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;
            
            
            if (firstParent != null && secondParent != null)
            {
                firstNode.Parent = secondParent;
                secondNode.Parent = firstParent;

                int indexOfFirst = firstParent._children.IndexOf(firstNode);
                int indexOfSecond = secondParent._children.IndexOf(secondNode);

                firstParent._children[indexOfFirst] = secondNode;
                secondParent._children[indexOfSecond] = firstNode;
            }
            else
            {
                if (firstParent == null)
                {
                    SwapRoot(firstNode, secondNode);
                }
                if (secondParent == null)
                {
                    SwapRoot(secondNode, firstNode);
                }
            }         
                       
        }

        private void SwapRoot(Tree<T> root, Tree<T> childrenNode)
        {           

            root.RemoveNode(root.Value);

            var newNode = childrenNode.Children;
            childrenNode.Parent = null;            
            root.Value = childrenNode.Value;

            foreach (var child in childrenNode.Children)
            {
                root.AddChild(root.Value, child);
            }          
           
            RoodDelete = false;          
                     
        }
    }
}
