using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);

            int[] StartAndEnd =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToArray();


            int start = StartAndEnd[0];
            int end = StartAndEnd[1];
            int[] Range = Enumerable.Range(start, (end - start) + 1).ToArray();

            string command = Console.ReadLine();

            Func<int[], int[]> Checker = n =>
            {
                if (command == "even")
                {
                    return n.Where(x => x % 2 == 0).ToArray();
                }
                else
                {
                    return n.Where(x => x % 2 != 0).ToArray();
                }

            };

            Console.WriteLine(string.Join(" ",Checker(Range)));
        }
    }
}
