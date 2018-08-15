using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_List_of_predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            int EndOfRange = int.Parse(Console.ReadLine());
            List<int> Divisors =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToList();
            if (EndOfRange <= 0) return;
            List<int> Range = Enumerable.Range(1, EndOfRange).ToList();

            
            Func<List<int>, int[]> Checker = n =>
            {
                    foreach (var number in Divisors)
                    {
                        n = n.Where(s => s % number == 0).ToList();
                    }
               
                return n.ToArray();
            };

            Console.WriteLine(string.Join(" ", (Checker(Range))));
        }
    }
}
