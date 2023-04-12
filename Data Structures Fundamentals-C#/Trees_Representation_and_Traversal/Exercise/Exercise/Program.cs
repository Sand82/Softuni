// See https://aka.ms/new-console-template for more information

using Exercise;

var root = new Node<int>(7,
    new Node<int>(19,
        new Node<int>(1),
        new Node<int>(12),
        new Node<int>(31)),
    new Node<int>(21),
    new Node<int>(14, 
        new Node<int>(23), 
        new Node<int>(6))
    );

var tree = new Tree<int>();

//var result = tree.BFS(root);

//Console.WriteLine(String.Join(", ", result));

tree.DFS(root, 0);