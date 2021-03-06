﻿using System;
using System.Dynamic;

namespace _05SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int num = 1; num <= number; num++)
            {
                int sumOfDigits = 0;
                int digits = num;
                while (digits>0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }
                bool isSpecial =(sumOfDigits==5) ||
                    (sumOfDigits == 7) || 
                    (sumOfDigits == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
            }
        }
    }
}
