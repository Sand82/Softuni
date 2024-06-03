using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    public static void separateNumbers(string s)
    {
        for (var i = 1; i <= s.Length / 2; i++)
        {
            var numStr = s.Substring(0, i); // "9"
            var num = long.Parse(numStr); // 9
            var j = 0;
            while (j + numStr.Length <= s.Length && s.Substring(j, numStr.Length) == numStr) // 0 + 2 <= s.Length && s.Substring
            {
                j += numStr.Length;
                num++;
                numStr = num.ToString();
            }

            if (j == s.Length)
            {
                Console.WriteLine($"YES {s.Substring(0, i)}");
                return;
            }
        }

        Console.WriteLine("NO");
    } 
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            Result.separateNumbers(s);
        }
    }
}
