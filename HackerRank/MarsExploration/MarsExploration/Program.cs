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
    public static int MarsExploration(string s)
    {
        var count = 0;

        for (int i = 0; i < s.Length; i+=3)
        {
            var firstS = s[i];
            var firstO = s[i+1];
            var secondS = s[i+2];

            if (firstS != 'S')
            {
                count++;
            }

            if (firstO != 'O')
            {
                count++;
            }

            if (secondS != 'S')
            {
                count++;
            }
        }

        return count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {      
        string s = Console.ReadLine();

        int result = Result.MarsExploration(s);

        Console.WriteLine(result);        
    }
}
