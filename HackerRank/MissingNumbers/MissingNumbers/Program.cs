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
    public static List<int> MissingNumbers(List<int> arr, List<int> brr)
    {
        var resultAArr = new Dictionary<int, int>();
        var resultBArr = new Dictionary<int, int>();

        var count = arr.Count;

        if (brr.Count > arr.Count)
        {
            count = brr.Count;
        }

        for (int i = 0; i < count; i++)
        {

            if (i < arr.Count)
            {
                var currAElement = arr[i];

                if (!resultAArr.ContainsKey(currAElement))
                {
                    resultAArr[currAElement] = 0;
                }

                resultAArr[currAElement] ++;
            }

            if (i < brr.Count)
            {
                var currBElement = brr[i];

                if (!resultBArr.ContainsKey(currBElement))
                {
                    resultBArr[currBElement] = 0;
                }

                resultBArr[currBElement]++;
            }            
        }

        foreach (var item in resultBArr)
        {
            var key = item.Key;

            if (resultAArr.ContainsKey(key) && resultBArr.ContainsKey(key))
            {
                resultBArr[key] = resultBArr[key] - resultAArr[key];
            }

            if (!resultAArr.ContainsKey(key))
            {
                resultBArr[key] = 1;
            }
        }

        var result = resultBArr
            .Where(x => x.Value > 0)
            .OrderBy(x => x.Key)
            .Select(x => x.Key)
            .ToList();

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        List<int> result = Result.MissingNumbers(arr, brr);

        Console.WriteLine(String.Join(" ", result));        
    }
}
