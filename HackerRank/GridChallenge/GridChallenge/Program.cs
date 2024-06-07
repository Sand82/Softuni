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
    public static string GridChallenge(List<string> grid)
    {        
        var matrix = new char[grid.Count][];

        var r = grid.Count;
        var c = 0;

        for (int row = 0; row < grid.Count; row++)
        {
            var tokensArr = grid[row].Trim().ToCharArray().OrderBy(x => x);
            var tokens = string.Join("", tokensArr);
            matrix[row] = new char [tokens!.Length];
            c = tokens.Length;

            for (var col = 0; col < tokens.Length; col++)
            {
                var el = tokens[col];

                matrix[row][col] = el;
            }
        }
        
        var result = new List<string>();       

        for (int col = 0; col < c; col++)
        {
            for (var row = 0; row < r - 1; row++)
            {
                var firstEl = matrix[row][col];
                var secondEl = matrix[row + 1][col];

                if (secondEl >= firstEl)
                {
                    result.Add("YES");
                }
                else
                {
                    result.Add("NO");
                }
            }
        }
        
        return result.Any(x => x == "NO") ? "NO" : "YES";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.GridChallenge(grid);

            Console.WriteLine(result);
        }
    }
}
