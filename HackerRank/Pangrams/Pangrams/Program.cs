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

    public static string Pangrams(string s)
    {

        var symbols = new Dictionary<char, int>();

        for (int i = 97; i <= 122; i++)
        {
            symbols.Add((char)i, 0);
        }

        for (int i = 0; i < s.Length; i++)
        {
            var currSymbol = (int)s[i];

            if (currSymbol >= 65 && currSymbol <= 90)
            {
                currSymbol += 32;
            }

            if (symbols.ContainsKey((char)currSymbol))
            {
                symbols[(char)currSymbol] += 1;
            }
        }

        if (symbols.Values.Any(x => x == 0))
        {
            return "not pangram";
        }

        return "pangram";
    }
}

class Solution
{
    public static void Main(string[] args)
    {       

        string s = Console.ReadLine();

        string result = Result.Pangrams(s);

        Console.WriteLine(result);        
    }
}
