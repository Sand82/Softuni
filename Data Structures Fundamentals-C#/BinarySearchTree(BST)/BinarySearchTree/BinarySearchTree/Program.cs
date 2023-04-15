using BinarySearchTree;

var list = new List<int>();

for (int i = 0; i < 50; i += 2)
{
    list.Add(i);
}

BST<int> tree = new BST<int>();

Insert(tree, 0, list.Count, list);

Console.WriteLine(tree.DFSInOrder(tree.Root, 0));
Console.WriteLine(tree.Contains(40, tree.Root));
Console.WriteLine(tree.Contains(100, tree.Root));



void Insert(BST<int> tree, int start, int end, List<int> list)
{
    if (start >= end)
    {
        return;
    }

    var middle = (start + end) / 2;
    tree.Insert(list[middle], tree.Root);
    Insert(tree, start, middle - 1, list);
    Insert(tree, middle + 1, end, list);
}