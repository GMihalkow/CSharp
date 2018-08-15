using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Engine
{
    private string enginemodel;
    private int enginepower;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power, int disc, string eff)
    {
        this.enginemodel = model;
        this.enginepower = power;
        this.displacement = disc;
        this.efficiency = eff;
    }
    public string EngineModel
    {
        get { return this.enginemodel; }
        set { this.enginemodel = value; }
    }

    public int EnginePower
    {
        get { return this.enginepower; }
        set { this.enginepower = value; }
    }

    public int Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

}

