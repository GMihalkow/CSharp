using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Car
{
    private string name;
    private string carmodel;
    private int carspeed;

    public Car(string personName, string carModel, int carSpeed)
    {
        this.name = personName;
        this.carmodel = carModel;
        this.carspeed = carSpeed;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string CarModel
    {
        get { return this.carmodel; }
        set { this.carmodel = value; }
    }

    public int CarSpeed
    {
        get { return this.carspeed; }
        set { this.carspeed = value; }
    }
}

