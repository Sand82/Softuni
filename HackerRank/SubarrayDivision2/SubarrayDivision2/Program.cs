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
     * Complete the 'birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     */

    public static int Birthday(List<int> s, int d, int m)
    {

        var count = 0;

        for (int i = 0; i < s.Count; i++)
        {
            var sum = 0;

            if (i + m > s.Count)
            {
                break;
            }

            for (var j = i; j < i + m; j++)
            {
                sum += s[j];
            }

            if (sum == d)
            {
                count++;
            }
        }

        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {        
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.Birthday(s, d, m);

        Console.WriteLine(result);        
    }
}
