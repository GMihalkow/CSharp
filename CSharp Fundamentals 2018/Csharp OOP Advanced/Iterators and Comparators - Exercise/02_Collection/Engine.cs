using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private ListyIterator<string> listyIterator;

    public Engine(params string[] elements)
    {
        listyIterator = new ListyIterator<string>(elements);
    }

    public void Move()
    {
        Console.WriteLine(listyIterator.Move());
    }

    public void HasNext()
    {
        Console.WriteLine(listyIterator.HasNext());
    }

    public void Print()
    {
        Console.WriteLine(listyIterator.Print());
    }

    public void PrintAll()
    {
        Console.WriteLine(listyIterator.PrintAll());
    }
}