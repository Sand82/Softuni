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
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> GradingStudents(List<int> grades)
    {
        var result = new List<int>();        

        for (int i = 0; i < grades.Count; i++)
        {
            var currGrade = grades[i];

            if (currGrade < 38 || currGrade == 100)
            {
                result.Add(currGrade);
                continue;
            }

            var getFirstNum = currGrade.ToString().Substring(0, 1);
            var getSecondNum = currGrade.ToString().Substring(1);

            var numToAdd = 5;

            if (int.Parse(getSecondNum) > 5)
            {
                numToAdd = 10;
            }

            if ((int.Parse(getFirstNum + 0) + numToAdd) - currGrade < 3 )
            {   
                result.Add(int.Parse(getFirstNum + 0) + numToAdd);            
            }
            else
            {
                result.Add(currGrade);
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {      
        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.GradingStudents(grades);


        Console.WriteLine("----------");
        Console.WriteLine(String.Join("\n", result));        
    }
}
