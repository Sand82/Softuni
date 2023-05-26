namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        private Tree<T> Life;

        private int currCount = 0;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.children.Add(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.GetAsString(0).Trim();
        }

        private string GetAsString(int identation = 0)
        {
            var result = new string(' ', identation) + this.Key + "\r\n";

            foreach (var child in this.children)
            {
                result += child.GetAsString(identation + 2);
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {

            Tree<T> node = FindDeepestNode();

            return node;

        }

        private Tree<T> FindDeepestNode()
        {
            var leafNodes = this.FindLeafs();

            Tree<T> deepestNode = null;
            Tree<T> currLeaf = null;
            int count = 0;
            int curCount = 0;

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                currLeaf = leaf;

                while (node != null)
                {
                    count++;
                    node = node.Parent;

                    if (count > curCount)
                    {
                        deepestNode = currLeaf;
                        curCount = count;
                        
                    }
                }
                count = 0;
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            List<Tree<T>> leafCollection = FindLeafs();

            List<T> leafValueCollection = new List<T>();

            foreach (var leaf in leafCollection)
            {
                leafValueCollection.Add(leaf.Key);
            }

            return leafValueCollection;
        }

        private List<Tree<T>> FindLeafs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<Tree<T>> list = new List<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);

                    if (child.Children.Count == 0)
                    {
                        list.Add(child);
                    }
                }
            }

            return list;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> colection = FindMiddleNodeBFSMethod();

            return colection;
        }

        private List<T> FindMiddleNodeBFSMethod()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> list = new List<T>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);

                    if (child.Parent != null && child.Children.Count != 0)
                    {
                        list.Add(child.Key);
                    }
                }
            }

            return list;
        }

        public List<T> GetLongestPath()
        {
            List<T> longPathList = new List<T>();

            var longLeaf = FindDeepestNode();

            while (longLeaf != null)
            {
                longPathList.Add(longLeaf.Key);

                longLeaf = longLeaf.Parent;
            }

            longPathList.Reverse();

            return longPathList;
        }       

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = this.FindLeafs();
            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                Tree<T> node = leaf;
                int currSum = 0;
                var currentNode = new List<T>();

                while (node != null)
                {
                    currSum += Convert.ToInt32(node.Key); // int.Parse(node.Key.ToString());                   
                    currentNode.Add(node.Key);
                    node = node.Parent;
                }

                if (currSum == sum)
                {
                    currentNode.Reverse();
                    result.Add(currentNode);
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var currSum = Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {
                currSum += SubTreeSumDFS(child, targetSum, roots);
            }

            if (currSum == targetSum)
            {
                roots.Add(node);
            }

            return currSum;
        }
    }
}
