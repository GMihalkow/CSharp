using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private Bag<string> bag;

    public Engine(List<string> list)
    {

        bag = new Bag<string>(list);
    }

    public void Run(string[] components)
    {
        string commandType = components[0];

        switch (commandType)
        {
            case "Add":
                {
                    string element = components[1];
                    bag.Add(element);
                }
                break;
            case "Remove":
                {
                    int index = int.Parse(components[1]);
                    bag.Remove(index);
                }
                break;
            case "Contains":
                {
                    string element = components[1];
                    Console.WriteLine(bag.Contains(element));
                }
                break;
            case "Swap":
                {
                    int index1 = int.Parse(components[1]);
                    int index2 = int.Parse(components[2]);
                    bag.Swap(index1, index2);
                }
                break;
            case "Greater":
                {
                    string element = components[1];
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
            case "Print":
                {
                    Console.Write(bag.Print());
                }
                break;
        }
    }
}