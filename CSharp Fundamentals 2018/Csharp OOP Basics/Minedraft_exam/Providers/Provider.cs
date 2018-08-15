using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Unit
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            bool IsInRange = value >= 0 && value <= 10000;
            if (IsInRange == false)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }
}