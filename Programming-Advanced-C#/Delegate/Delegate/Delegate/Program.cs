using Delegate;

var number = 5;

var mydelegate = new MyVoidDelegate(PrintInteger);

mydelegate += PrintIntegerPlusTen;
mydelegate += PrintIntegerPlusTen;

mydelegate(100);

mydelegate -= PrintIntegerPlusTen;

mydelegate(50);

//mydelegate(number);

//PassSomeDelegate(mydelegate);



static void PassSomeDelegate(MyVoidDelegate del)
{
    del(5);
}

static void PrintInteger(int number)
{
    Console.WriteLine(number);
}

static void PrintIntegerPlusTen(int num) 
{
    Console.WriteLine(num + 10);
}
