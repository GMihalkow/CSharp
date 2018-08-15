using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Tire
{ 
    private string model;

    private List<double> tirespressure = new List<double>();

    private double tire1pressure;
   // private int tire1age;

    private double tire2pressure;
   // private int tire2age;

    private double tire3pressure;
   // private int tire3age;

    private double tire4pressure;
    //private int tire4age;

    public List<double> TiresPressure
    {
        get { return this.tirespressure; }
        set { this.tirespressure = value; }
    }

    public Tire(string carmodel, double t1, double t2, double t3, double t4)
    {
        this.model = carmodel;
      //  this.tire1age = Tire1Age;
        this.tire1pressure = t1;
        //this.tire2age = Tire2Age;
        this.tire2pressure = t2;
        //tire3age = Tire3Age;
        this.tire3pressure = t3;
        //this.tire4age = Tire4Age;
        this.tire4pressure = t4;

        this.tirespressure.Add(t1);
        this.tirespressure.Add(t2);
        this.tirespressure.Add(t3);
        this.tirespressure.Add(t4);

    }
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    
    public double Tire1Pressure
    {
        get { return this.tire1pressure; }
        set { this.tire1pressure = value; }
    }

    //public int Tire1Age
    //{
    //    get { return this.tire1age; }
    //    set { this.tire1age = value; }
    //}

    public double Tire2Pressure
    {
        get { return this.tire2pressure; }
        set { this.tire2pressure = value; }
    }

    //public int Tire2Age
    //{
    //    get { return this.tire2age; }
    //    set { this.tire2age = value; }
    //}

    public double Tire3Pressure
    {
        get { return this.tire3pressure; }
        set { this.tire3pressure = value; }
    }

    //public int Tire3Age
    //{
    //    get { return this.tire3age; }
    //    set { this.tire3age = value; }
    //}

    public double Tire4Pressure
    {
        get { return this.tire4pressure; }
        set { this.tire4pressure = value; }
    }

    //public int Tire4Age
    //{
    //    get { return this.tire4age; }
    //    set { this.tire4age = value; }
    //}
}

