﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> numbers = new List<int>();

            string nonNumbers = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {

                if(text[i] == '0' || text[i] == '1' || text[i] == '2' || text[i] == '3' || text[i] == '4' ||
                    text[i] == '5' || text[i] == '6' || text[i] == '7' || text[i] == '8' || text[i] == '9')
                {
                    int num = int.Parse(text[i].ToString());
                    numbers.Add(num);
                }
                else
                {
                    nonNumbers += text[i].ToString();
                }
            }

            List<int> takeList = new List<int>();

            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            string finaleString = string.Empty;

            for (int i = 0; i < takeList.Count; i++)
            {
                if (takeList[i] >= nonNumbers.Length)
                {
                    finaleString += nonNumbers.Substring(0, nonNumbers.Length);
                    break;
                }
                if (skipList[i] >= nonNumbers.Length)
                {
                    break;
                }
                finaleString += nonNumbers.Substring(0, takeList[i]);
                nonNumbers = nonNumbers.Remove(0, takeList[i]);
                nonNumbers = nonNumbers.Remove(0, skipList[i]);
                
            }
           
            Console.WriteLine(finaleString);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> numbers = new List<int>();

            List<string> nonNumbers = new List<string>();



            for (int i = 0; i < text.Length; i++)
            {

                if (text[i] == '0' || text[i] == '1' || text[i] == '2' || text[i] == '3' || text[i] == '4' ||
                    text[i] == '5' || text[i] == '6' || text[i] == '7' || text[i] == '8' || text[i] == '9')
                {
                    numbers.Add(text[i] - 48);
                }
                else
                {
                    nonNumbers.Add(text[i].ToString());
                }
            }

            List<int> takeList = new List<int>();

            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            List<string> codeList = new List<string>();

            nonNumbers.
           
            Console.WriteLine(string.Join(" ", nonNumbers));
        }
    }
}
