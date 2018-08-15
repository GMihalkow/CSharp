using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        Box<string> newBox = new Box<string>(list);

        int inputCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < inputCount; index++)
        {
            string input = Console.ReadLine();
            newBox.Elements.Add(input);
        }

        int[] swapIndexes =
            Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int firstIndex = swapIndexes[0];
        int secondIndex = swapIndexes[1];

        newBox.SwapIndex(firstIndex, secondIndex);

        Console.Write(newBox.ToString());
    }
}
