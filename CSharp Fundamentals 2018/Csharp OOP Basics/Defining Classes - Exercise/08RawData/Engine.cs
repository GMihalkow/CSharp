using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Engine
{
    private int engineSpeed;
    private int enginePower;
    private string model;


    public Engine(int engspeed, int engpower, string carmodel)
    {
        this.engineSpeed = engspeed;
        this.model = carmodel;
        this.enginePower = engpower;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public int EngineSpeed
    {
        get { return this.engineSpeed; }
        set { this.engineSpeed = value; }
    }

    public int EnginePower
    {
        get { return this.enginePower; }
        set { this.enginePower = value; }
    }
}

