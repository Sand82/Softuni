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
     * Complete the 'kangaroo' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER v1
     *  3. INTEGER x2
     *  4. INTEGER v2
     */

    public static string Kangaroo(int x1, int v1, int x2, int v2)
    {
        var isTheSamePlace = false;

        for (int i = 0; i < 10000; i++)
        {
            if (v1 >= i)
            {
                x1 += v1; 
            }

            if (v2 >= i)
            {
                x2 += v2;
            }

            if (x1 == x2)
            {
                isTheSamePlace = true;
                break;
            }

        }

        if (isTheSamePlace)
        {
            return "YES";
        }

        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {       

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int x1 = Convert.ToInt32(firstMultipleInput[0]);

        int v1 = Convert.ToInt32(firstMultipleInput[1]);

        int x2 = Convert.ToInt32(firstMultipleInput[2]);

        int v2 = Convert.ToInt32(firstMultipleInput[3]);

        string result = Result.Kangaroo(x1, v1, x2, v2);

        Console.WriteLine(result);

     }
}
