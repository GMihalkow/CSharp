using System;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        Spy spy = new Spy();

        string command;
        while ((command = Console.ReadLine()) != "HARVEST")
        {
            Console.WriteLine(spy.GetFields("HarvestingFields", command));
        }
    }
}