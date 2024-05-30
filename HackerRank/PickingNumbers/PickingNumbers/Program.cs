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
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int PickingNumbers(List<int> a)
    {
        a = a.OrderBy(x => x).ToList();

        var result = 0;       

        for (int i = 0; i < a.Count; i++)
        {
            var count = 0;
            var startElement = a[i];

            for (var j = i; j < a.Count; j++)
            {              

                if (j > 0 && a[j] - startElement > 1)
                {                                      
                    break;
                }
                else
                {
                    count++;
                }
            }

            if (count > result)
            {
                result = count;
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {       

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.PickingNumbers(a);

        Console.WriteLine(result);        
    }
}
