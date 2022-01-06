using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] queuedEls = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elsToDeque = input[1];
            int lookedNumber = input[2];

            Queue<int> queue = new Queue<int>();

            foreach (int element in queuedEls)
            {
                queue.Enqueue(element);
            }

            if (elsToDeque >= queue.Count)
            {
                Console.WriteLine("0");
                return;
            }

            for(int i = 0; i < elsToDeque; i++)
            {
                queue.Dequeue();
            }


            int minNum = Int32.MaxValue;

            if (queue.Contains(lookedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (int element in queue)
                {
                    if (element < minNum)
                    {
                        minNum = element;
                    }
                }

                Console.WriteLine(minNum);
            }

        }
    }
}
