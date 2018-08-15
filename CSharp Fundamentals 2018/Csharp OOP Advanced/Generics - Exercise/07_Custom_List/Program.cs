using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        Engine engine = new Engine(list);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] command =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            engine.Run(command);
        }
    }
}