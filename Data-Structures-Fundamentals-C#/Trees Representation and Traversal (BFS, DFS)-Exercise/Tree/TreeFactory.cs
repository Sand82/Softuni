namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var item in input)
            {
                var tokens = item.Split(' ').Select(int.Parse).ToArray();

                int key = tokens[0];
                int value = tokens[1];
                              
                CreateNodeByKey(key);
                CreateNodeByKey(value);

                if (!this.nodesBykeys.ContainsKey(value))
                {
                    var node = CreateNodeByKey(value);
                    this.nodesBykeys.Add(value, node);
                }

                this.AddEdge(key, value);                
              
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {           

            if (!this.nodesBykeys.ContainsKey(key))
            {                
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]);
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            var node = this.nodesBykeys.FirstOrDefault().Value;

            while (node.Parent !=  null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
