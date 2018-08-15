using System;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string lastDate = Console.ReadLine();

        DateModifier Actions = new DateModifier();
        DateTime start = Actions.Parse(firstDate);
        DateTime end = Actions.Parse(lastDate);

        Actions.DaysExcluder(start, end);
    }
}

