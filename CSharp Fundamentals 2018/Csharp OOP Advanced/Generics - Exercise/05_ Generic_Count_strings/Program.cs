using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        Box<string> box = new Box<string>(list);

        int inputCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < inputCount; index++)
        {
            string input = Console.ReadLine();
            box.Elements.Add(input);
        }

        string compareTo = Console.ReadLine();

        Console.WriteLine(box.CompareElements(compareTo));
    }
}