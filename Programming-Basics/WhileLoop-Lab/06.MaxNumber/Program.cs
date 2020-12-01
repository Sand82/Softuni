﻿using System;
using System.ComponentModel.DataAnnotations;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;

            while (input != "Stop")
            {
                int number = int.Parse(input);
                input = Console.ReadLine();
                if (number > maxNumber)
                {
                    
                    maxNumber = number;
                }
                
            }
            Console.WriteLine(maxNumber);
        }
    }
}
