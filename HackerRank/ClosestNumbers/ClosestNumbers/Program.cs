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
{    public static List<int> ClosestNumbers(List<int> arr)
    {
        var sorted = arr.OrderBy(x => x).ToList();

        var smallestDifference = int.MaxValue;

        for (int i = 0; i < sorted.Count - 1; i ++)
        {
            var firstElement = sorted[i];
            var secondElement = sorted[i + 1];

            if (smallestDifference > Math.Abs(secondElement - firstElement))
            {
                smallestDifference = Math.Abs(secondElement - firstElement);
            }
        }

        var result = new List<int>();

        for (int i = 0; i < sorted.Count - 1; i ++)
        {
            var firstElement = sorted[i];
            var secondElement = sorted[i + 1];

            if (Math.Abs(secondElement - firstElement) == smallestDifference)
            {
                result.Add(firstElement);
                result.Add(secondElement);
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

        List<int> result = Result.ClosestNumbers(arr);

        Console.WriteLine(String.Join(" ", result));
    }
}
