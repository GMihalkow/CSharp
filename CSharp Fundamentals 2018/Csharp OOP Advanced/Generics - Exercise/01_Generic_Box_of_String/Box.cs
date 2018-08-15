using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T value;

    public Box(T element)
    {
        this.value = element;
        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {value}";
    }
}