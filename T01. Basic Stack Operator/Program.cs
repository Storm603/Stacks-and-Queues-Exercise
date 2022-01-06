using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Basic_Stack_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] elsToPush = Console.ReadLine().Split().Select(int.Parse).ToArray(); 

            int elsToPop = input[1];
            int lookedForElement = input[2];

            Stack<int> stack = new Stack<int>();

            foreach (int element in elsToPush)
            {
                stack.Push(element);
            }

            if (elsToPop >= stack.Count)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = 0; i < elsToPop; i++)
            {
                stack.Pop();
            }

            int smallestNumber = Int32.MaxValue;

            if (stack.Contains(lookedForElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (int element in stack)
                {
                    if (element < smallestNumber)
                    {
                        smallestNumber = element;
                    }
                }

                Console.WriteLine(smallestNumber);
            }

            
        }
    }
}
