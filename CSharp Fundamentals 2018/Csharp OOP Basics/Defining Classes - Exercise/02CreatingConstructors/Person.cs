using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private int age;
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
      
    }

    public Person(int age):this()
    {
        Name = name;
        this.Age = age;
    }

    public Person(string name, int age):this(0)
    {
        Name = name;
        Age = age;
    }

}

