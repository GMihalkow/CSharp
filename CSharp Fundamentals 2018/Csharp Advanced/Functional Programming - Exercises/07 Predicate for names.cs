using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_Predicate_for_names
{
    class Program
    {
        static void Main(string[] args)
        {
            int NameLength = int.Parse(Console.ReadLine());
            string[] Names =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Func<string[], string[]> Filter = n =>
            {
                return n = n.Where(w => w.Length <= NameLength).ToArray();
            };

            Console.WriteLine(String.Join("\n", Filter(Names)));
        }
    }
}
