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
using System.Collections.Concurrent;

class Result
{

    /*
     * Complete the 'countingSort' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> CountingSort(List<int> arr)
    {
        var sortedDictionary = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            sortedDictionary.Add(i, 0);
        }

        for (int i = 0; i < arr.Count; i++)
        {
            sortedDictionary[arr[i]] += 1;            
        }

        var result = new List<int>();

        var counter = 0;

        foreach (var item in sortedDictionary)
        {            
            result.Add(item.Value);

            counter += item.Value;

            if (counter == arr.Count && arr.Count > 100)
            {
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.CountingSort(arr);

        Console.WriteLine(String.Join(" ", result));       
    }
}
