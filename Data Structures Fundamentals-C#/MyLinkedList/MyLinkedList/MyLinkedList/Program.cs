using MyLinkedList;

var linkedList = new MyLinkedList<int>();

for (int i = 1; i <= 10; i++)
{
    linkedList.Add(i);
}

//linkedList.Remove();
//linkedList.Remove();
//linkedList.Remove();
//linkedList.Remove();

var currNode = linkedList.Head;

while (currNode != null)
{
    Console.WriteLine(currNode.Value);

    currNode = currNode.Next;
}