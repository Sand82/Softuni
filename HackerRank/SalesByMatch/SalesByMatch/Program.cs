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
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */

    public static int SockMerchant(int n, List<int> ar)
    {
        var colors = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            var currSock = ar[i];

            if (!colors.ContainsKey(currSock))
            {
                colors[currSock] = 0;
            }

            colors[currSock]++;
        }

        var pearsCount = 0;

        foreach (var sock in colors)
        {
            pearsCount += sock.Value / 2;
        }

        return pearsCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {        
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.SockMerchant(n, ar);

        Console.WriteLine(result);
    }
}
