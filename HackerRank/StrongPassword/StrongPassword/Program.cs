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
    public static int minimumNumber(int n, string password)
    {
        var resultDictionary = new Dictionary<string, bool>
        {
            {"numbers", false },
            {"lower_case", false },
            {"upper_case", false },
            {"special_characters", false },
        };

        for (int i = 0; i < password.Length; i++)
        {
            if (!resultDictionary["numbers"])
            {
                resultDictionary["numbers"] = IsMatch(@"[0-9]", password[i]);
            }

            if (!resultDictionary["lower_case"])
            {
                resultDictionary["lower_case"] = IsMatch(@"[a-z]", password[i]);
            }

            if (!resultDictionary["upper_case"])
            {
                resultDictionary["upper_case"] = IsMatch(@"[A-Z]", password[i]);
            }

            if (!resultDictionary["special_characters"])
            {
                resultDictionary["special_characters"] = IsMatch(@"[!@#$%^&*()-+- ]", password[i]);
            }
        }

        var countFalsies = resultDictionary.Values.Where(x => !x).Count();

        var passwordLength = password.Length;        

        var result = 0;        
        
        if (passwordLength + countFalsies < 6)
        {
            result = 6 - passwordLength;
        }
        else
        {
            result = countFalsies;
        }

        return result;
    }

    private static bool IsMatch(string pattern, char currChar)
    {
        var regex = new Regex(pattern);

        if (regex.IsMatch(currChar.ToString()))
        {
            return true;
        }

        return false;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.minimumNumber(n, password);

        Console.WriteLine(answer);
    }
}
