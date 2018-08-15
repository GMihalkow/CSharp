using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            Func<int, int> Add = n => n + 1;
            Func<int, int> Multiply = n => n * 2;
            Func<int, int> Substract = n => n - 1;
            Action<int[]> Printer = n => Console.WriteLine(string.Join(" ", n)); 

            int[] Numbers =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add": Numbers = Numbers.Select(Add).ToArray(); break;
                    case "multiply": Numbers = Numbers.Select(Multiply).ToArray(); break;
                    case "subtract": Numbers = Numbers.Select(Substract).ToArray(); break;
                    case "print": Printer(Numbers); break;
                }

            }
        }
    }
}
