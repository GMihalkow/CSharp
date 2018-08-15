using System;
using System.Collections.Generic;
using System.Text;

public class NewTuple<T, T1>
{
    private T item1;
    private T1 item2;

    public NewTuple(T item1, T1 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        Console.WriteLine($"{Item1} -> {item2}");
    }

    public T Item1
    {
        get
        {
            return this.item1;
        }
        private set
        {
            this.item1 = value;
        }
    }

    public T1 Item2
    {
        get
        {
            return this.item2;
        }
        private set
        {
            this.item2 = value;
        }
    }
}