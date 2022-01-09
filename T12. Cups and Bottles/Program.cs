using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace T12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacities = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesWithWatter = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacities);
            Stack<int> bottles = new Stack<int>(bottlesWithWatter);
            
            int wastedWater = 0;
            int currCup = 0;

            while (cups.Any() && bottles.Any())
            {
                if (currCup <= 0)
                {
                    currCup = cups.Peek();
                }
                int currBottle = bottles.Pop();


                if (currCup > currBottle)
                {
                    currCup -= currBottle;
                }
                else if (currBottle >= currCup)
                {
                    currCup -= currBottle;
                    wastedWater += currCup;

                    cups.Dequeue();
                }
            }


            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {Math.Abs(wastedWater)}");
        }
    }
}
