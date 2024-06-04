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
    public static string CaesarCipher(string s, int k)
    {
        var result = new List<char>();

        for (int i = 0; i < s.Length; i++)
        {
            var symbol = (int)s[i];
            
            var pattern = @"[^A-Za-z]";
            var regex = new Regex(pattern);
            Match match = regex.Match(s[i].ToString());

            if (k > 26)
            {
                k = k % 26;
            }

            if (match.Success || s[i] == '_')
            {
                result.Add((char)symbol);
                continue;
            }

            if (symbol > 96 && symbol + k > 122)
            {
                symbol = symbol + k - 26;
            }
            else if(symbol + k > 90 && symbol < 97)
            {
                symbol = symbol + k - 26;
            }
            else
            {
                symbol += k;
            }

            result.Add((char)symbol);
        }

        return string.Join("", result);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.CaesarCipher(s, k);

        Console.WriteLine(result);
    }
}
