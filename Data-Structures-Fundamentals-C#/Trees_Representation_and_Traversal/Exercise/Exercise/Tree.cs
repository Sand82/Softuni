namespace Exercise
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public void DFS(Node<T> root, int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(root);

            foreach (var node in root.Children)
            {
                DFS(node, level + 3);
            }
        }

        public List<Node<T>> BFS(Node<T> root)
        {
            var result = new List<Node<T>>();

            var queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node);

                foreach (var children in node.Children)
                {
                    queue.Enqueue(children);
                }
            }

            return result;
        }
    }
}
