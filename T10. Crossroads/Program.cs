using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<Queue<char>> collectionOfCars = new Queue<Queue<char>>();

            string command = String.Empty;
            string currCar = String.Empty;

            int carsPassed = 0;

            while (true)
            {
                while (true)
                {
                    command = Console.ReadLine();
                    if (command == "green")
                    {
                        break;
                    }
                    if (command == "END")
                    {
                        Console.WriteLine("Everyone is safe.");
                        Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
                        Environment.Exit(0);
                    }

                    collectionOfCars.Enqueue(new Queue<char>(command));
                }


                if (collectionOfCars.Count > 0)
                {
                    Queue<char> carLength = new Queue<char>(collectionOfCars.Dequeue());
                    currCar = string.Join("", carLength);


                    for (int i = 0; i < greenLightSeconds; i++)
                    {
                        carLength.Dequeue();

                        if (carLength.Count == 0)
                        {
                            carsPassed++;

                            if (collectionOfCars.Count == 0)
                            {
                                break;
                            }
                            
                            if (i < greenLightSeconds - 1)
                            {
                                carLength = new Queue<char>(collectionOfCars.Dequeue());
                                currCar = string.Join("", carLength);
                            }
                        }
                    }

                    if (carLength.Count > 0 )
                    {
                        for (int i = 0; i < freeWindowSeconds; i++)
                        {
                            carLength.Dequeue();

                            if (carLength.Count == 0)
                            {
                                carsPassed++;
                                break;
                            }
                        }
                    }


                    if (carLength.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currCar} was hit at {carLength.Peek()}.");
                        return;
                    }
                }
            }
        }
    }
}
