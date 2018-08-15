using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class CarParameters
{
    private decimal fuelAmount;
    private string carModel;
    private decimal fuelPerKm;
    private decimal KmtoDrive;
    private int traveledDistance;
   
    public CarParameters()
    {
        this.fuelAmount = FuelAmount;
        this.carModel = CarModel;
        this.fuelPerKm = FuelPerKm;
        this.KmtoDrive = KilometersToDrive;
    }

    public int TraveledDistance
    {
        get { return this.traveledDistance; }
        set { this.traveledDistance = value; }
    }

    public decimal FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public string CarModel
    {
        get { return this.carModel; }
        set { this.carModel = value; }
    }

    public decimal FuelPerKm
    {
        get { return this.fuelPerKm; }
        set { this.fuelPerKm = value; }
    }

    public decimal KilometersToDrive
    {
        get { return this.KmtoDrive; }
        set { this.KmtoDrive = value; }
    }
}

