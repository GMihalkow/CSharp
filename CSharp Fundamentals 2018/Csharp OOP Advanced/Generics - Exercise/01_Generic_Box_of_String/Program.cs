using System;

class Program
{
    static void Main(string[] args)
    {
        int inputCount = int.Parse(Console.ReadLine());

        for (int index = 0; index < inputCount; index++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
        }
    }
}