using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private string commandType;

    public Engine(List<string> arguments, DraftManager draftManager)
    {
        string commandType = arguments[0];
        this.commandType = commandType;

        switch (this.commandType)
        {
            case "RegisterHarvester":
                {
                    arguments.RemoveAt(0);
                    Console.WriteLine(draftManager.RegisterHarvester(arguments));
                }
                break;
            case "RegisterProvider":
                {
                    arguments.RemoveAt(0);
                    Console.WriteLine(draftManager.RegisterProvider(arguments));
                }
                break;
            case "Day":
                {
                    arguments.RemoveAt(0);
                    Console.WriteLine(draftManager.Day());
                }
                break;
            case "Mode":
                {
                    arguments.RemoveAt(0);
                    Console.WriteLine(draftManager.Mode(arguments));
                }
                break;
            case "Check":
                {
                    arguments.RemoveAt(0);
                    Console.WriteLine(draftManager.Check(arguments));
                }
                break;
            default:
                throw new Exception();

        }
    }
}