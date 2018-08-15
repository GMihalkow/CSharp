using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        Engine engine = new Engine();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputParameters =
                input
                .Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = inputParameters[0];
            int parameter = int.Parse(inputParameters[1]);

            Console.WriteLine(engine.Run("BlackBoxInteger", command, parameter));
        }
    }
}