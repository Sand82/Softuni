using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Solution
{
    class Solution
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();

            var t = Console.ReadLine();

            var result = strings_xor(s, t);

            Console.WriteLine(result);
        }        

        public static string strings_xor(string s, string t)
        {           

            var result = string.Empty;

            for (int i = 0; i < s.Count(); i++)
            {
                var firstSymbol = s[i];
                var secondSymbol = t[i];

                if (firstSymbol == secondSymbol)
                {
                    result += '0';
                }
                else
                {
                    result += '1';
                }
            }

            return result;
        }
    }
}