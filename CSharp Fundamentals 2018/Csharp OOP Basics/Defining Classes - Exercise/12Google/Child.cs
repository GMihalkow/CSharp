using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Child
{
    private string name;
    private string childname;
    private string childbirthday;

    public Child(string personName, string childName, string childBirthday)
    {
        this.name = personName;
        this.childname = childName;
        this.childbirthday = childBirthday;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string ChildName
    {
        get { return this.childname; }
        set { this.childname = value; }
    }

    public string ChildBirthday
    {
        get { return this.childbirthday; }
        set { this.childbirthday = value; }
    }
}

