﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int compare = 1;
            

            if (other != null)
            {
                compare = other.Name.CompareTo(this.Name);

                if (compare == 0)
                {
                    compare = other.Age.CompareTo(this.Age);
                }

                if (compare == 0)
                {
                    compare = other.Town.CompareTo(this.Town);
                }
                
            }
            return compare;


        }
    }
}
