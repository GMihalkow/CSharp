using System;

class Program
{
    static void Main(string[] args)
    {
        int inputCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < inputCount; index++)
        {
            int input = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(input);
        }
    }
}