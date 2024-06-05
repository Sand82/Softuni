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
    public static int MaxMin(int k, List<int> arr)
    {
        var result = int.MaxValue;

        var sorted = arr.OrderBy(x => x).ToList();

        for (int i = 0; i < sorted.Count - k + 1; i ++)
        {         

            var first = sorted[i];            
            var last = sorted[i + k - 1];            

            if (last - first < result)
            {
                result = last - first;
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

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int result = Result.MaxMin(k, arr);

        Console.WriteLine(result);
    }
}
