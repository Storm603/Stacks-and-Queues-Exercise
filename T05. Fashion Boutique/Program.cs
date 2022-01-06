using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int spaceOnRack = int.Parse(Console.ReadLine());

            int racks = 1;
            int volumeSum = 0;
            Stack<int> clothes = new Stack<int>(clothesInBox);

            for (int i = 0; i < clothesInBox.Length; i++)
            {
                if (clothes.Count > 0)
                {
                    if (clothes.Peek() + volumeSum > spaceOnRack)
                    {
                        racks++;
                        volumeSum = 0;
                        i--;
                        continue;
                    }
                }

                volumeSum += clothes.Pop();
            }

            Console.WriteLine(racks);
        }
    }
}
