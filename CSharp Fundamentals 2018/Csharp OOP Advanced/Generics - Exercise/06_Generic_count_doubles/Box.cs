using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Box<T>
    where T : IComparable
{
    private List<T> elements;

    public Box(List<T> elements)
    {
        this.Elements = elements;
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
    
    public double CompareElements(T comparer)
    {
        List<T> greaterElements = this.elements.Where(e => e.CompareTo(comparer) > 0).ToList();

        return greaterElements.Count;
    }

}