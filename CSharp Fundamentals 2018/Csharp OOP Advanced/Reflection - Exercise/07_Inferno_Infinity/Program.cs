using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Command types:
        //⦁	Create;{weapon type};{weapon name}
        //⦁	Add;{weapon name};{socket index};{gem type}
        //⦁	Remove;{weapon name};{socket index}
        //⦁	Print;{weapon name}

        List<Weapon> weps = new List<Weapon>();
        Engine engine = new Engine(weps);
        

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            engine.Run(input);
        }
    }
}