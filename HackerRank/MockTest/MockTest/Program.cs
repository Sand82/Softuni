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
    public static int GetTotalX(List<int> a, List<int> b)
    {
        var collection = new Dictionary<int, int>();

        var countFirst = a.Count;

        for (var j = 0; j < b.Count; ++j)
        {            
            var currBNum = b[j];

            for (var k = 0; k <= currBNum; k++)
            {
                var num = k;

                if (a.Where(x => x > num || num % x != 0 ).Any())
                {
                    continue;
                }
                else
                {
                    if (!collection.ContainsKey(num))
                    {
                        collection[num] = 0;
                    }

                    collection[num]++;
                }
            }
            countFirst--;
        }

        var result = collection.Where(x => x.Value == b.Count).ToList();

        var count = 0;

        for (int i = 0; i < result.Count; i++)
        {
            var currNum = result[i].Key;

            if (b.Where(x => x % currNum != 0).Any())
            {
                continue;
            }
            else
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
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.GetTotalX(arr, brr);

        Console.WriteLine(total);
    }
}
