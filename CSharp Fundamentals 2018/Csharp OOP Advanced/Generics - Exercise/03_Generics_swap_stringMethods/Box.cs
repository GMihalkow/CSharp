using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private List<T> elements;

    public Box(List<T> list)
    {
        this.Elements = list;
    }

    public List<T> Elements
    {
        get
        {
            return this.elements;
        }
        private set
        {
            this.elements = value;
        }
    }
    
    public void SwapIndex(int firstIndex, int secondIndex)
    {
        var tempElement = elements[firstIndex];

        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = tempElement;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var element in elements)
        {
            stringBuilder.AppendLine(String.Format($"{element.GetType().FullName}: {element}"));
        }
        return stringBuilder.ToString();
    }

}