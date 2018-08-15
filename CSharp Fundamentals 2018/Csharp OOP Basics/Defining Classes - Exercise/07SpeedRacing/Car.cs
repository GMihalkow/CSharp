using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Car
{
    private List<CarParameters> Cars = new List<CarParameters>();

    public void AddingCars(CarParameters car)
    {
        Cars.Add(car);
    }

    public void DecreasingFuel(string model, decimal KmtoDrive)
    {
        foreach (var car in Cars)
        {
            if (car.CarModel == model)
            {
                decimal FuelPerKm = car.FuelPerKm * KmtoDrive;
                decimal totalFuelUsed = car.FuelAmount - FuelPerKm;

                if (totalFuelUsed < 0)
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
                else
                {
                    car.TraveledDistance += (int)KmtoDrive;
                    car.FuelAmount = totalFuelUsed;
                }
            }   
        }   
    }

    public void PrintingCars()
    {
        foreach (var car in Cars)
        {
            Console.WriteLine($"{car.CarModel} {car.FuelAmount:f2} {car.TraveledDistance}");
        }
    }
}