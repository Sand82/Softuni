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

public class DivisibleSumPairs
{

    /*
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY ar
     */

    public static int DivisibleSumPairsSolution(int n, int k, List<int> arr)
    {
        var result = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            var currElI = arr[i];

            for (int j = i + 1; j < arr.Count; j++)
            {
                var currElJ = arr[j];

                if ((currElI + currElJ) % k == 0)
                {
                    result++;                    
                }
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {      

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = DivisibleSumPairs.DivisibleSumPairsSolution(n, k, ar);

        Console.WriteLine(result);
    }
}
