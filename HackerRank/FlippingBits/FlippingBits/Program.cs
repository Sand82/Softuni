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
     * Complete the 'flippingBits' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER n as parameter.
     */

    public static long FlippingBits(long n)
    {
        var sb = new StringBuilder();

        var toBinary = Convert.ToString(n, 2);        

        var nullValues = new string('0', 32);

        var digitSubtracted = nullValues.Substring(0, nullValues.Length - toBinary.Length);

        var digit = digitSubtracted + toBinary;

        for (int i = 0; i < digit.Length; i++)
        {
            var currSymbol = digit[i];

            if (currSymbol == '0')
            {
                sb.Append('1');
            }
            else if(currSymbol == '1')
            {
                sb.Append('0');
            }
        }

        var resultToBinary = sb.ToString();

        var result = Convert.ToInt64(resultToBinary, 2);

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {       

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = Result.FlippingBits(n);

            Console.WriteLine(result);
        }
    }
}
