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
    public static int MinimumAbsoluteDifference(List<int> arr)
    {
        var minDifference = int.MaxValue;

        arr = arr.OrderBy(x => x).ToList();

        for (int i = 0; i < arr.Count - 1; i++)
        {
            var firstNum = arr[i];
            var secondNum = arr[i + 1];

            if (Math.Abs(firstNum - secondNum) < minDifference)
            {
                minDifference = Math.Abs(firstNum - secondNum);
            }
        }

        return minDifference;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.MinimumAbsoluteDifference(arr);

        Console.WriteLine(result);
    }
}
