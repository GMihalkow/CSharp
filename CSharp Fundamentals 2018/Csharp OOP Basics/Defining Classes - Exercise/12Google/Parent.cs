using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Parent
{
    private string name;
    private string parentname;
    private string parentbirthday;

    public Parent(string personName, string parentName, string parentBirthday)
    {
        this.name = personName;
        this.parentname = parentName;
        this.parentbirthday = parentBirthday;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string ParentName
    {
        get { return this.parentname; }
        set { this.parentname = value; }
    }

    public string ParentBirthday
    {
        get { return this.parentbirthday; }
        set { this.parentbirthday = value; }
    }

}

