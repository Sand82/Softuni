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

    public static List<int> DynamicArray(int n, List<List<int>> queries)
    {
        var lastAnswer = 0;
        var answers = Enumerable.Range(0, n).Select(_ => new List<int>()).ToList();
        return queries.Aggregate(new List<int>(), (agg, q) =>
        {
            var idx = (q[1] ^ lastAnswer) % n;
            if (q[0] == 1)
            {
                answers[idx].Add(q[2]);
            }
            else if (q[0] == 2)
            {
                lastAnswer = answers[idx][q[2] % answers[idx].Count];
                agg.Add(lastAnswer);
            }
            return agg;
        });
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.DynamicArray(n, queries);

        Console.WriteLine(String.Join("\n", result));
    }
}
