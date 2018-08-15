using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Car
{
    private string model;
    private List<Engine> engine = new List<Engine>();
    private int weight;
    private string color;

    public Car(string model, List<Engine> eng, int weight, string color)
    {
        this.engine = new List<Engine>();
        this.model = model;
        this.engine = eng;
        this.weight = weight;
        this.color = color;
    }

    public List<Engine> Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }
}

