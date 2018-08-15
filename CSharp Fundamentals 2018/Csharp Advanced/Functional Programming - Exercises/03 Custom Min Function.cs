using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            Func<int[], int> SmallestNumber = n => n.Min();
            int[] Numbers =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToArray();

            Console.WriteLine(SmallestNumber(Numbers));
        }
    }
}
