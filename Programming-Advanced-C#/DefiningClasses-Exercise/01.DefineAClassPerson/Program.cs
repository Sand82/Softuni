﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Person person = new Person();
            person.Name = "Pesho";
            person.Age = 20;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
                        
        }
    }
}
