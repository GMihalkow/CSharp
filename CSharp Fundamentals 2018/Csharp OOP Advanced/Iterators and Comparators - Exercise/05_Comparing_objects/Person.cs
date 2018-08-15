using System;
using System.Collections.Generic;
using System.Text;

public class Person<T> : IComparable<Person<T>>
    where T : IComparable<T>
{
    public T Name { get; private set; }
    public T Age { get; private set; }
    public T Town { get; private set; }

    public Person(params T[] info)
    {
        this.Name = info[0];
        this.Age = info[1];
        this.Town = info[2];
    }

    public int CompareTo(Person<T> other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result != 0)
        {
            return result;
        }
        else
        {
            result = this.Age.CompareTo(other.Age);
        }

        if (result != 0)
        {
            return result;
        }
        else
        {
            result = this.Town.CompareTo(other.Town);
        }

        return result;
    }
}