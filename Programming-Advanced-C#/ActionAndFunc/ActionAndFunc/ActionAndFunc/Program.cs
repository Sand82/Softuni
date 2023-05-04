namespace ActionAndFunc 
{
    public class Cat
    {
        public Cat(string name)
        {
            Name = name;
        }

        public string Name { get; set; }               

        public void SayMaw()
        {
            Console.WriteLine("May");
        }
    }

    public class Program
    {
        public static void Main()
        {
            //Action action = SomeMethod;
            //action += () => Console.WriteLine("Other test");
            //action();


            //Action<int, string, bool> action = SomeMethod;
            //action += (x, y, z) => Console.WriteLine(x);
            //action(100, "Test", true);

            Func<string, bool, int> func = SomeMethod;  
            
            Func<int, int, int> sumeFunc = (x, y) => x + y;

            Console.WriteLine(func("test", false));

            Action<Cat> catAction = cat => cat.SayMaw();

            Cat cat = new Cat("Misho");

            catAction(cat);

            Func<Cat, string> funcCat = cat => cat.Name;

            Console.WriteLine(funcCat(cat));
        }

        public static int SomeMethod(string test, bool someBool)
        {
            if (someBool)
            {
                return 10;
            }

            return 100;
        }

        public static void SomeMethod()
        {
            Console.WriteLine("Test");
        }

        public static void SomeMethod(int number, string text, bool isTrue)
        {
            Console.WriteLine(number + 10);
        }
    }
}