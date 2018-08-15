using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        CustomList<string> bag = new CustomList<string>(list);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] arguments =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandType = arguments[0];

            switch (commandType)
            {
                case "Add":
                    {
                        string element = arguments[1];
                        bag.Add(element);
                    }
                    break;
                case "Remove":
                    {
                        int index = int.Parse(arguments[1]);
                        bag.Remove(index);
                    }
                    break;
                case "Contains":
                    {
                        string element = arguments[1];
                        Console.WriteLine(bag.Contains(element));
                    }
                    break;
                case "Swap":
                    {
                        int index1 = int.Parse(arguments[1]);
                        int index2 = int.Parse(arguments[2]);

                        bag.Swap(index1, index2);
                    }
                    break;

                case "Greater":
                    {
                        string element = arguments[1];
                        Console.WriteLine(bag.CountGreaterThan(element));
                    }
                    break;

                case "Max":
                    {
                        Console.WriteLine(bag.Max());
                    }
                    break;
                case "Min":
                    {
                        Console.WriteLine(bag.Min());
                    }
                    break;
                case "Sort":
                    {
                        bag.Sort();
                    }
                    break;
                case "Print":
                    {
                        foreach (var item in bag.Inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
            }
        }
    }
}