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
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */

    public static List<int> MaximumPerimeterTriangle(List<int> sticks)
    {
        sticks = sticks.OrderBy(x => x).ToList();       

        var result = new List<int>();

        for (int i = 0; i < sticks.Count - 2; i++)
        {
            var first = sticks[i];
            var second = sticks[i+1];
            var third = sticks[i+2];

            var sum = first + second + third;

            if (first + second > third)
            {
                result = new List<int> { first, second, third };              
            }
        }

        if (result.Count == 0)
        {
            result.Add(-1);
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {        

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

        List<int> result = Result.MaximumPerimeterTriangle(sticks);

        Console.WriteLine(String.Join(" ", result));
    }
}
