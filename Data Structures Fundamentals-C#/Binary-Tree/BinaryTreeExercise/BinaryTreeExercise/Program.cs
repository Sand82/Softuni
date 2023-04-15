using BinaryTreeExercise;

var root = new Node<int>(1,
    new Node<int>(5, new Node<int>(2), new Node<int>(3)),
    new Node<int>(7, new Node<int>(9), new Node<int>(11))
    );

var binaryTree = new BinaryTree<int>(root);

Console.WriteLine(binaryTree.DFSInOrder(root, 0));

