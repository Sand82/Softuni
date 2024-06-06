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
    public static void countSort(List<List<string>> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (i < arr.Count / 2)
            {
                arr[i][1] = "-"; 
                arr[i].Add(i.ToString());
            }                
        }

        Console.WriteLine(string.Join(" ", arr.OrderBy(el => int.Parse(el[0]))
            .ThenBy(el => int.Parse(el[2]))
            .Select(el => el[1])));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
