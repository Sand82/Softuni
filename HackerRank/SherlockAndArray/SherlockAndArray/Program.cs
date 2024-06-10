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
    public static string BalancedSums(List<int> arr)
    {
        int length = arr.Count();
        int left = 0;
        int right = 0;
        int last = 0;

        for (int i = 0; i < length; i++)
        {
            left += arr[i];
        }

        for (int i = length - 1; i > -1; i--)
        {
            left -= arr[i];
            right += last;
            if (left == right)
            {
                return "YES";
            }
            last = arr[i];
        }
        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.BalancedSums(arr);

            Console.WriteLine(result);
        }
    }
}
