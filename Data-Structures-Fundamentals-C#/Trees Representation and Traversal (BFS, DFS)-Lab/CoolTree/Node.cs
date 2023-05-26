using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolTree
{
    public class Node<T>
    {
        public Node(T value, params Node<T>[] childrens)
        {
            Value = value;
            Children = childrens.ToList();
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }


        public override string ToString()
        {
            return Value.ToString();

        }
    }
}
