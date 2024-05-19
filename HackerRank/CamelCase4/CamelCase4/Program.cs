using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;

public class CamelCase4
{
    public static void Main()
    {

        try
        {
            while (true)
            {

                var tokens = Console.ReadLine()!.Split(";").ToArray();

                var operation = tokens[0];
                var type = tokens[1];
                var sentence = tokens[2];

                var result = string.Empty;

                switch (operation)
                {
                    case "S":
                        result = SeparateString(sentence);
                        break;
                    case "C":
                        result = Combiner(type, sentence);
                        break;
                }

                Console.WriteLine(result);
            }
        }
        catch (Exception e) { }


    }

    private static string Combiner(string type, string sentence)
    {
        var result = string.Empty;

        if (type == "V")
        {
            result = CombineStringInPascalCase(sentence, 1);
        }
        else if (type == "C")
        {
            result = CombineStringInPascalCase(sentence, 0);
        }
        else if (type == "M")
        {
            result = CombineStringInPascalCase(sentence, 1, true);
        }

        return result;
    }

    private static string CombineStringInPascalCase(string sentence, int index)
    {

        var result = sentence.Split(" ");

        for (int i = index; i < result.Length; i++)
        {
            var token = result[i];

            var firstSymbol = token.Substring(0, 1);
            var secondPart = token.Substring(1);

            var firstToUpper = firstSymbol.ToUpper();

            result[i] = firstToUpper + secondPart;
        }

        return string.Join("", result);
    }

    private static string CombineStringInPascalCase(string sentence, int index, bool wantBrackets = false)
    {

        var result = sentence.Split(" ").ToList();

        for (int i = index; i < result.Count; i++)
        {
            var token = result[i];

            var firstSymbol = token.Substring(0, 1);
            var secondPart = token.Substring(1);

            var firstToUpper = firstSymbol.ToUpper();

            result[i] = firstToUpper + secondPart;
        }

        if (wantBrackets)
        {
            result.Add("(");
            result.Add(")");
        }

        return string.Join("", result);
    }

    private static string SeparateString(string sentence)
    {
        var result = new List<char>();

        for (int i = 0; i < sentence.Length; i++)
        {
            var symbol = sentence[i];

            if (symbol >= 65 && symbol <= 90)
            {
                if (i > 0)
                {
                    result.Add(' ');
                }

                int charNum = symbol + 32;

                result.Add((char)charNum);
            }
            else if (symbol >= 97 && symbol <= 122)
            {
                result.Add(symbol);
            }
        }

        return string.Join("", result);
    }
}
