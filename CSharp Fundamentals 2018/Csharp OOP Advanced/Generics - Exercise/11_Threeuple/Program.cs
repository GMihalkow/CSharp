using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input =
            Console.ReadLine()
            .Split()
            .ToArray();

        string names = input[0] + " " + input[1];
        string street = input[2];
        string town = input[3];

        Threeuple<string, string, string> firstTuple
            = new Threeuple<string, string, string>(names, street, town);
        Console.WriteLine(firstTuple.ToString());

        input =
            Console.ReadLine()
            .Split()
            .ToArray();

        string name = input[0];
        int litersOfBeer = int.Parse(input[1]);


        bool IsDrunk = input[2] == "drunk";


        Threeuple<string, int, string> secondTuple
            = new Threeuple<string, int, string>(name, litersOfBeer, IsDrunk.ToString());
        Console.WriteLine(secondTuple.ToString());

        input =
            Console.ReadLine()
            .Split()
            .ToArray();

        string nextName = input[0];
        double accBalance = double.Parse(input[1]);
        string bankName = input[2];

        Threeuple<string, double, string> thirdTuple =
            new Threeuple<string, double, string>(nextName, accBalance, bankName);
        Console.WriteLine(thirdTuple.ToString());

    }
}