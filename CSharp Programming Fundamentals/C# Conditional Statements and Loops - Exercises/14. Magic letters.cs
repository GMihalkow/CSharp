using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            string Combination = String.Empty;

            for (char i = first; i <= second; i++)
            {
                if (i == third) continue;
                for (char w = first; w <= second; w++)
                {
                    if (w == third) continue;
                    for (char x = first; x <= second; x++)
                    {
                        if (x == third) continue;
                        Console.Write($"{i}{w}{x} ");
                    }
                }
            }
        }
    }
}
