using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private int index;
    private IReadOnlyList<T> collection;

    public ListyIterator(params T[] elements)
    {
        this.index = 0;
        this.collection = elements;
    }

    public bool Move()
    {
        int temp = this.index + 1;
        bool IsInRange = temp < this.collection.Count;

        if (IsInRange)
        {
            index++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HasNext()
    {
        int temp = this.index + 1;
        return temp < this.collection.Count;
    }

    public T Print()
    {
        if (this.collection.Count == 0 || this.index > this.collection.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        else
        {
            return this.collection[this.index];
        }
    }

    public string PrintAll()
    {
        return string.Join(" ", this.collection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = 0; index < this.collection.Count; index++)
        {
            yield return this.collection[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}