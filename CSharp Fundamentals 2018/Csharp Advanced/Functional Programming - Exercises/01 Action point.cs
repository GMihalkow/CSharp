using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional_Programming_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = w => Console.WriteLine(w);
            List<string> input =
               Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            foreach (var word in input)
            {
                printer(word);
            }

        }
    }
}
