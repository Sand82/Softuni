<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoolTree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public void DFS(Node<T> node, int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(node);

            foreach (var child in node.Children)
            {
                DFS(child, level + 3);
            }
        }
        public List<Node<T>> BFS(Node<T> root) 
        {

            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);

                foreach (var item in node.Children)
                {
                    queue.Enqueue(item);                    
                }             
            }
            return list;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoolTree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public void DFS(Node<T> node, int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(node);

            foreach (var child in node.Children)
            {
                DFS(child, level + 3);
            }
        }
        public List<Node<T>> BFS(Node<T> root) 
        {

            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);

                foreach (var item in node.Children)
                {
                    queue.Enqueue(item);                    
                }             
            }
            return list;
        }
    }
}
>>>>>>> 3f829fb024736210877646961e8db90630043581
