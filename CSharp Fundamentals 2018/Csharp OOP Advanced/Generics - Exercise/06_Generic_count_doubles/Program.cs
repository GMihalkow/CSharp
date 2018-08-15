using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> list = new List<double>();
        Box<double> box = new Box<double>(list); 

        int inputCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < inputCount; index++)
        {
            double input = double.Parse(Console.ReadLine());
            box.Elements.Add(input);
        }

        double comparer = double.Parse(Console.ReadLine());
        Console.WriteLine(box.CompareElements(comparer));
    }
}