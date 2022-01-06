using System;
using System.Collections.Generic;
using System.Linq;

namespace Т07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolStationCount = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < petrolStationCount; i++)
            {
                queue.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            int startingIndex = 0;
            int cycle = 0;

            while (cycle < petrolStationCount)
            {
                int totalFuel = 0;
                cycle = 0;

                foreach (int[] info in queue)
                {
                    int petrolAmount = info[0];
                    int distanceTillNextStation = info[1];

                    totalFuel += petrolAmount;
                    totalFuel -= distanceTillNextStation;

                    cycle++;

                    if (totalFuel < 0)
                    {
                        queue.Enqueue(queue.Dequeue());
                        startingIndex++;
                        break;
                    }
                }
            }

            Console.WriteLine(startingIndex);
        }
    }
}
