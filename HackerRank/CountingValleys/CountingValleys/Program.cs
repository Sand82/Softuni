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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    public static int CountingValleys(int steps, string path)
    {
        var countDeep = 0;

        var currDeep = 0;

        var previousDeep = 0;       

        for (int i = 0; i < path.Length; i++)
        {
            var currPath = path[i];

            previousDeep = currDeep;

            if (currPath == 'D') 
            {
                currDeep--;                
            }

            if (currPath == 'U')
            {
                currDeep++;                
            }

            if (currDeep == 0 && previousDeep <= 0) 
            {                
                countDeep++;
            }            
        }

        return countDeep;

    }

}

class Solution
{
    public static void Main(string[] args)
    {        

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.CountingValleys(steps, path);

        Console.WriteLine(result);        
    }
}
