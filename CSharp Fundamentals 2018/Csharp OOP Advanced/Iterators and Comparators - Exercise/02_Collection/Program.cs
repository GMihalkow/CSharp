using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> createCommand =
           Console.ReadLine()
           .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
           .ToList();

        createCommand.RemoveAt(0);
        Engine engine = new Engine(createCommand.ToArray());

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {

                switch (input)
                {
                    case "PrintAll":
                        {
                            engine.PrintAll();
                        }
                        break;
                    case "HasNext":
                        {
                            engine.HasNext();
                        }
                        break;
                    case "Move":
                        {
                            engine.Move();
                        }
                        break;
                    case "Print":
                        {
                            engine.Print();
                        }
                        break;
                }

            }
            catch (InvalidOperationException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}