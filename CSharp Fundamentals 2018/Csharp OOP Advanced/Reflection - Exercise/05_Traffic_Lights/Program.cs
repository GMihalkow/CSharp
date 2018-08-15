using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        List<Object> inputLights =
            Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l => Activator.CreateInstance(Type.GetType(l)))
            .ToList();

        int turns = int.Parse(Console.ReadLine());

        Engine engine = new Engine(inputLights, turns);
        engine.Run();
    }
}