using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace T11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockQueue = new Queue<int>(locks);

            int totalBullets = bulletStack.Count;

            while (true)
            {
                for (int i = 0; i < gunBarrelSize; i++)
                {
                    if (bulletStack.Count == 0 || lockQueue.Count == 0)
                        break;

                    int bullet = bulletStack.Peek();
                    int lockk = lockQueue.Peek();

                    if (bullet <= lockk)
                    {
                        bulletStack.Pop();
                        lockQueue.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        bulletStack.Pop();
                        Console.WriteLine("Ping!");
                    }
                }

                if (bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (bulletStack.Count == 0 || lockQueue.Count == 0)
                    break;
            }

            if (lockQueue.Count == 0)
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${intelligenceValue - ((totalBullets - bulletStack.Count) * priceOfBullet)}");
            }
            else if (bulletStack.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }

        }
    }
}
