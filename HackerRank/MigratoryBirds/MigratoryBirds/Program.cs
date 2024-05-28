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
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int MigratoryBirds(List<int> arr)
    {

        var birds = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            var currBird = arr[i];

            if (!birds.ContainsKey(currBird))
            {
                birds[currBird] = 0;
            }

            birds[currBird] ++;
        }

        var sorted = birds.OrderByDescending(b => b.Value).ThenBy(b => b.Key).ToDictionary();

        var result = sorted.Keys.First();

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        
        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.MigratoryBirds(arr);

        Console.WriteLine(result);
    }
}
