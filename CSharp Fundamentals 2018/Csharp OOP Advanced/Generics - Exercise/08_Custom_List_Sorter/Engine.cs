using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private CustomList<string> bag;

    public Engine(List<string> list)
    {
        this.bag = new CustomList<string>(list);
    }

    public void Run(string[] arguments)
    {
      
    }
}