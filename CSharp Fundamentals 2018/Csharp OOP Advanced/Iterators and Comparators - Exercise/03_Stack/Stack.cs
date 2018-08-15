using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private List<T> stack;

    public Stack(List<T> stack)
    {
        this.stack = stack;
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            stack.Add(element);
        }
    }

    public T Pop()
    {
        if (this.stack.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
        int lastIndex = this.stack.Count - 1;
        T tempItem = this.stack[lastIndex];

        this.stack.RemoveAt(lastIndex);

        return tempItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var element in this.stack)
        {
            stringBuilder.AppendLine(String.Format($"{element}"));
        }

        return stringBuilder.ToString();    
    }
}