using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Unit
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    
    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            bool IsPositive = value > 0 && value <= 20000;
            if (IsPositive == false)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }
    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            bool IsPositive = value > 0;
            if (IsPositive == false)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }
}