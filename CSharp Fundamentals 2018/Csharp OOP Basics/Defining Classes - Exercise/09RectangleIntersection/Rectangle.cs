using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Rectangle
{
    private string id;
    private decimal x1;
    private decimal y1;
    private decimal x2;
    private decimal y2;

    public Rectangle(string idd, decimal xx1, decimal yy1, decimal xx2, decimal yy2)
    {
        this.id = idd;
        this.x1 = xx1;
        this.y1 = yy1;
        this.x2 = xx2;
        this.y2 = yy2;
    }

    public string ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public decimal X1
    {
        get { return this.x1; }
        set { this.x1 = value; }
    }
    public decimal Y1
    {
        get { return this.y1; }
        set { this.y1 = value; }
    }

    public decimal X2
    {
        get { return this.x2; }
        set { this.x2 = value; }
    }
    public decimal Y2
    {
        get { return this.y2; }
        set { this.y2 = value; }
    }
}

