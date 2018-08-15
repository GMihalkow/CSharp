using System;
using System.Collections.Generic;
using System.Text;

public class Comparator : IEqualityComparer<Person>, IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.CompareTo(y.Name);
        if (result != 0)
        {
            return result;
        }
        else
        {
            result = x.Age.CompareTo(y.Age);
        }
        return result;
    }

    public bool Equals(Person x, Person y)
    {
        bool AreTheyEqual = x.Equals(y);
        return AreTheyEqual;
    }

    public int GetHashCode(Person obj)
    {
        //    int result = obj.GetHashCode();
        //    return result;
        return base.GetHashCode();
    }
}