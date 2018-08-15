using System;
using System.Linq;
using System.Collections.Generic;

namespace _06_Reverse_and_exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            List<int> Numbers =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToList();


            Func<List<int>,List<int>> Checker = n =>
            {
                int Divisor = int.Parse(Console.ReadLine());
                n.Reverse();
                n.RemoveAll(w => w % Divisor == 0);
                return n;
            };

            Console.WriteLine(string.Join(" ",Checker(Numbers)));
        }
    }
}
