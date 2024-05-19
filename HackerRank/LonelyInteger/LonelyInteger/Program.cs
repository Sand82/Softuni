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

public class Result
{
   
    public static int Lonelyinteger(List<int> a)
    {
        var result = 0;

        for (int i = 0; i < a.Count; i++)
        {
            var currEl = a[i];

            var isExist = false;

            for (int j = 0; j < a.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var compare = a[j];

                if (compare == currEl)
                {
                    isExist = true;
                }
            }

            if (!isExist)
            {
                result = currEl;
                break;
            }
        }

        return result; 
    }
}

class Solution
{
    public static void Main(string[] args)
    {        

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.Lonelyinteger(a);

        Console.WriteLine(result);
    }
}
