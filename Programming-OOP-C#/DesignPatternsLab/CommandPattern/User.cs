﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class User
    {
        public User(Calculator calculator)
        {
            Calculator = calculator;
        }
        public Calculator Calculator { get; set; }

        public void Calculate(char sign, decimal value)
        {
            switch (sign)
            {
                case '+':
                    Calculator.Execute(new AddCommand(value));
                    break;
                case '-':
                    Calculator.Execute(new MinusCommand(value));
                    break;
                case '*':
                    Calculator.Execute(new MultiplayCommand(value));
                    break;
                case '/':
                    Calculator.Execute(new DivideCommand(value));
                    break;
                default:
                    break;
            }
        }
    }
}
