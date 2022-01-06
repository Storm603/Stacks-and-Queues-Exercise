using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodSupplies = int.Parse(Console.ReadLine());
            int[] orderIncoming = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(orderIncoming);

            Console.WriteLine(orders.Max());

            int index = 0;

            while(orders.Count > 0)
            {
                foodSupplies -= orderIncoming[index];
                index++;

                if (foodSupplies < 0)
                {
                    Console.WriteLine($"Orders left: " + string.Join(" ", orders));
                    return;
                }
                orders.Dequeue();

            }
            Console.WriteLine("Orders complete");
        }
    }
}
