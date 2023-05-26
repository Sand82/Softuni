namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            bool isEqual = true;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(' || parentheses[i] == '{' || parentheses[i] == '[')
                {
                    stack.Push(parentheses[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isEqual = false;
                        break;
                    }

                    char parenthes = stack.Pop();

                    if (parentheses[i] == ')')
                    {
                        if (parenthes != '(')
                        {
                            isEqual = false;
                            break;
                        }
                    }

                    if (parentheses[i] == '}')
                    {
                        if (parenthes != '{')
                        {
                            isEqual = false;
                            break;
                        }
                    }

                    if (parentheses[i] == ']')
                    {
                        if (parenthes != '[')
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }                
            }

            return isEqual;
        }
    }
}
