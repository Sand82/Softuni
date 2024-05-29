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

    /*
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */

    public static int PageCount(int n, int p)
    {

        if (p == 1 || p == n) 
        { 
            return 0; 
        }
        if (n - p == 1) 
        { 
            return n % 2 == 0 ? 1 : 0; 
        }
        return (n / 2 < p) ? ((n - p) / 2) : (p / 2);
    }
}

class Solution
{
    public static void Main(string[] args)
    { 
        int n = Convert.ToInt32(Console.ReadLine()!.Trim());

        int p = Convert.ToInt32(Console.ReadLine()!.Trim());

        int result = Result.PageCount(n, p);

        Console.WriteLine(result);
    }
}
