﻿using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Calculator
    {
        private Stack<ICommand> commands;

        public Calculator()
        {
            commands = new Stack<ICommand>();
        }
        public decimal Value { get; set; }

        public void Execute(ICommand command)
        {
            Value = command.Execute(Value);
            commands.Push(command);
        }

        public void Undo(int levels) 
        {
            for (int i = 0; i < levels; i++)
            {
                Value = commands.Pop().Unexecute(Value);                
            }
        }

    }
}
