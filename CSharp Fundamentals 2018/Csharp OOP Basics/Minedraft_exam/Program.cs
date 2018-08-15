using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();
        string input;
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            List<string> actualInput =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            try
            {
                Engine engine = new Engine(actualInput, draftManager);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        Console.Write(draftManager.ShutDown());
    }
}