﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}