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

    public static int DiagonalDifference(List<List<int>> arr)
    {
        var sumPrimaryDiagonal = 0;
        var sumSecondaryDiagonal = 0;

        var counterSecondary = arr.Count - 1;

        for (int i = 0; i < arr.Count; i++)
        {
            var currPrimaryNum = arr[i][i];
            var currSecondaryNum = arr[i][counterSecondary];

            sumPrimaryDiagonal += currPrimaryNum;
            sumSecondaryDiagonal += currSecondaryNum;

            counterSecondary--;
        }

        var result = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.DiagonalDifference(arr);

        Console.WriteLine(result);       
    }
}
