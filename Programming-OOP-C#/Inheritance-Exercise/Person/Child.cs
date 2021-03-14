﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public override int Age 
        {
            get
            {
                return base.Age;
            }
            set 
            {
                if (value > 15)
                {
                    throw new ArgumentException("chile age must be less than 15 years");
                }
                base.Age = value;

            } 
        }

        public Child(string name, int age) 
            : base(name, age)
        {
        }
    }
}
