using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace T08._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> paranthesis = new Stack<char>();

            foreach (char element in input)
            {
                if (element == '{' || element == '[' || element == '(')
                {
                    paranthesis.Push(element);
                }
                else if (paranthesis.Count > 0)
                {
                    if (paranthesis.Peek() == '{' && element == '}')
                    {
                        paranthesis.Pop();
                    }
                    else if (paranthesis.Peek() == '[' && element == ']')
                    {
                        paranthesis.Pop();
                    }
                    else if (paranthesis.Peek() == '(' && element == ')')
                    {
                        paranthesis.Pop();
                    }
                }
                else if (paranthesis.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            if (paranthesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");

            }
        }
    }
}
