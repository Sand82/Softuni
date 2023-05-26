using MyArray;

var myArray = new MyArray<char>();

//Console.WriteLine(myArray.Contains(1));

for (int i = 56; i <= 100; i++)
{
    myArray.Add((char)i);
}

//Console.WriteLine(myArray.Print());

//myArray.Remove();

//Console.WriteLine(myArray.Print());

//Console.WriteLine(myArray.Contains(9));

//Console.WriteLine(myArray.Contains(1));

//Console.WriteLine(myArray.IndexOf(5));
//Console.WriteLine(myArray.IndexOf(100));

Console.WriteLine(myArray.RemoveAt(4));
Console.WriteLine(myArray.Print());