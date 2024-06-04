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
    public static int TowerBreakers(int n, int m)
    {
        if (m == 1)
            return 2;

        if (n % 2 == 0)
            return 2;
        else
            return 1;       
    }

}

class Solution
{
    public static void Main(string[] args)
    { 
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.TowerBreakers(n, m);

            Console.WriteLine(result);
        }      
    }
}
