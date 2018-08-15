using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> stack = new List<int>();

        Engine engine = new Engine(stack);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            List<string> pushItems =
                input
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = pushItems[0];

            switch (command)
            {
                case "Push":
                    {
                        pushItems.RemoveAt(0);
                        int[] neededItems =
                            pushItems
                            .Select(int.Parse)
                            .ToArray();

                        engine.Push(neededItems);
                    }
                    break;
                case "Pop":
                    {
                        engine.Pop();
                    }
                    break;
            }
        }

        for (int index = 0; index < 2; index++)
        {
            Console.Write(engine.Stack.ToString());
        }
    }
}