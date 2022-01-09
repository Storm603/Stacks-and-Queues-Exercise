using System;
using System.Collections.Generic;
using System.Linq;

namespace T09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfOperations = int.Parse(Console.ReadLine());

            Queue<char> queue = new Queue<char>();
            Stack<string> prevStates = new Stack<string>();

            string command = string.Empty;
            string argument = String.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                command = input[0];

                if (command == "1")
                {
                    argument = input[1];
                    foreach (char letter in argument)
                    {
                        queue.Enqueue(letter);
                    }

                    prevStates.Push(queue.ToString());
                }
                else if (command == "2")
                {
                    if (queue.Count - int.Parse(input[1]) >= 0)
                    {
                        int index = queue.Count - int.Parse(input[1]);

                        for (int j = index; j > 0; j--)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }

                        for (int j = int.Parse(input[1]); j > 0; j--)
                        {
                            queue.Dequeue();
                        }
                    }

                    prevStates.Push(string.Join("", queue));

                }
                else if (command == "3")
                {
                    if (int.Parse(input[1]) > 0 && int.Parse(input[1]) <= queue.Count) // possible exception at 0, count might start from 1
                    {
                        Console.WriteLine(queue.ElementAt(int.Parse(input[1]) - 1));
                    }
                }
                else if (command == "4")
                {
                    if (prevStates.Count == 0)
                    {
                        queue = new Queue<char>();
                        continue;
                    }

                    if (prevStates.Count == 1)
                    {
                        prevStates.Pop();
                        queue = new Queue<char>();
                        continue;
                    }

                    prevStates.Pop();
                    string stateToChangeInto = prevStates.Peek();


                    queue.Clear();

                    foreach (char element in stateToChangeInto)
                    {
                        queue.Enqueue(element);
                    }
                }
            }

        }
    }
}
