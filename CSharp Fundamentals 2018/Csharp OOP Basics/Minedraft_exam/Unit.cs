using System;
using System.Collections.Generic;
using System.Text;

public abstract class Unit
{
    private string id;

    protected Unit(string id)
    {
        this.ID = id;
    }

    public string ID
    {
        get
        {
            return this.id;
        }
        protected set
        {
            this.id = value;
        }
    }
}