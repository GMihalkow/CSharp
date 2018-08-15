using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Cargo
{
    private string cargotype;
    private int cargoweight;
    private string model;

    public Cargo(string carcargotype, int carcargoweight, string carmodel)
    {
        this.cargotype = carcargotype;
        this.cargoweight = carcargoweight;
        this.model = carmodel;
    }
    
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public string CargoType
    {
        get { return this.cargotype; }
        set { this.cargotype = value; }
    }

    public int CargoWeight
    {
        get { return this.cargoweight; }
        set { this.cargoweight = value; }
    }
}

