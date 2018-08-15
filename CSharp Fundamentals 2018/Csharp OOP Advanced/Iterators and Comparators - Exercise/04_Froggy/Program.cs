using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] stoneNumbers =
             Console.ReadLine()
             .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

        Lake lake = new Lake(stoneNumbers);
        Console.WriteLine(lake.ToString());
    }
}