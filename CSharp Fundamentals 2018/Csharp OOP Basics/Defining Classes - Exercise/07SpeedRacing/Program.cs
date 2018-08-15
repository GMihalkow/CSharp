using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        CarParameters parameters = new CarParameters();

        int carsCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < carsCount; index++)
        {
            string[] cars =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string carModel = cars[0];
            decimal fuelAmount = decimal.Parse(cars[1]);
            decimal fuelConsumptionPerKm = decimal.Parse(cars[2]);
            CarParameters Machines = new CarParameters();
            Machines.CarModel = carModel;
            Machines.FuelAmount = fuelAmount;
            Machines.FuelPerKm = fuelConsumptionPerKm;
            Machines.TraveledDistance = 0;
            car.AddingCars(Machines);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] DrivingInfo =
                command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = DrivingInfo[1];
            decimal kilometersToDrive = decimal.Parse(DrivingInfo[2]);

            car.DecreasingFuel(model, kilometersToDrive);
        }


        car.PrintingCars();
    }
}
