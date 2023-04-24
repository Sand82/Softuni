namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        //private List<ILink> historiesList = new List<ILink>();
        //private Stack<ILink> historyStack = new Stack<ILink>();
        private LinkedList histories = new LinkedList();

        public int Size => histories.Count;

        public void Open(ILink link)
        {
            var node = new Node(link);

            histories.AddLast(node);            
        }

        public ILink GetByUrl(string url)
        {
            ILink result = null;

            var node = histories.Head;

            while (node != null)
            {
                if (node.Value.Url == url)
                {
                    result = node.Value;
                    break;
                }

                node = node.Next;
            }

            return result;
        }

        public bool Contains(ILink link)
        {
            var node = histories.Head;

            while (node != null)
            {
                if (node.Value == link)
                {
                    return true;                    
                }

                node = node.Next;
            }

            return false;
        }

        public ILink LastVisited()
        {
            CheckZeroCollection();

            var lastHistory = histories.Last.Value;

            return lastHistory;
        }

        public ILink DeleteLast()
        {
            CheckZeroCollection();

            var lastHistory = histories.RemoveLast().Value;            

            return lastHistory;
        }

        public ILink DeleteFirst()
        {
            CheckZeroCollection();

            var firstHistory = histories.RemoveFirst().Value;           

            return firstHistory;
        }

        public int RemoveLinks(string url)
        {
            var count = 0;

            var node = histories.Head;

            while (node != null)
            {
                if (node.Value.Url.ToLower().Contains(url.ToLower()))
                {
                    if (node == histories.Head)
                    {
                        histories.RemoveFirst();
                        node = histories.Head;
                    }
                    else
                    {
                        var nodeToRemove = node;
                        node = node.Next;
                        histories.RemoveNode(nodeToRemove);
                        
                    }
                    count++;
                    
                }
                else
                {
                    node = node.Next;
                }                
            }        

            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count; 
        }

        public void Clear()
        {
            histories = new LinkedList();
        }

        public ILink[] ToArray()
        {
            var result = new ILink [Size];

            var node = histories.Last;

            var counter = 0;

            while (node != null)
            {
                result[counter] = node.Value;
                counter++;

                node = node.Previus;
            }

            return result;
        }

        public List<ILink> ToList()
        {
            var result = new List<ILink>(Size);

            var node = histories.Last;           

            while (node != null)
            {
                result.Add(node.Value);

                node = node.Previus;
            }

            return result;
        }

        public string ViewHistory()
        {
            if (Size == 0)
            {
                return "Browser history is empty!";
            }

            var sb = new StringBuilder();

            var node = histories.Last;            

            while (node != null)
            {
                sb.AppendLine(node.Value.ToString());

                node = node.Previus;
            }

            return sb.ToString();
        }

        private void CheckZeroCollection()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
