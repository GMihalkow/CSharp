﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);
        return result;
    }
}