using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] Input =
            Console.ReadLine()
            .Split()
            .ToArray();

        string names = (Input[0] + " " + Input[1]);
        string address = Input[2];

        NewTuple<string, string> tuple = new NewTuple<string, string>(names, address);

        Input =
            Console.ReadLine()
            .Split()
            .ToArray();

        string personName = Input[0];
        int litersOfBeer = int.Parse(Input[1]);

        NewTuple<string, int> secondTuple = new NewTuple<string, int>(personName, litersOfBeer);

        Input =
            Console.ReadLine()
            .Split()
            .ToArray();

        int firstInteger = int.Parse(Input[0]);
        double firstDouble = double.Parse(Input[1]);

        NewTuple<int, double> thirdTuple = new NewTuple<int, double>(firstInteger, firstDouble);

    }
}