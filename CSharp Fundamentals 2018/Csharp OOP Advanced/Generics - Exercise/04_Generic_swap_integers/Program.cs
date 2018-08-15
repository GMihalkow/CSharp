using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Box<int> box = new Box<int>(list);

        int inputCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < inputCount; index++)
        {
            int input = int.Parse(Console.ReadLine());
            box.Elements.Add(input);
        }

        int[] swapIndexes =
            Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int firstIndex = swapIndexes[0];
        int secondIndex = swapIndexes[1];

        box.SwapElements(firstIndex, secondIndex);

        Console.Write(box.ToString());
    }
}