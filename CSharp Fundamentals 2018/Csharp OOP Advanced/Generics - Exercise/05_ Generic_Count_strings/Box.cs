using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T> where T : IComparable
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

    public int CompareElements(T element)
    {
        List<T> remainingElements = elements.Where(e => e.CompareTo(element) > 0).ToList(); 
        return remainingElements.Count();
    }
}