using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_Knights_of_honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> ToKnight = w => Console.WriteLine(w);

            string[] Knights =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var warrior in Knights)
            {
                ToKnight("Sir " + warrior);
            }
        }
    }
}
