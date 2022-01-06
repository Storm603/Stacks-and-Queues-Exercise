using System;
using System.Collections.Generic;

namespace T06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> library = new Queue<string>(songs);

            while (library.Count > 0)
            {
                List<string> command = new List<string>(Console.ReadLine().Split());

                switch (command[0])
                {
                    case "Play":
                        library.Dequeue();
                        break;
                    case "Add":
                        command.Remove("Add");
                        if (!library.Contains(string.Join(" ", command)))
                        {
                            library.Enqueue(string.Join(" ", command));
                        }
                        else
                        {
                            Console.WriteLine($"{string.Join(" ", command)} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", library));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
