using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int carsCount = int.Parse(Console.ReadLine());
        Car car = new Car();

        for (int index = 0; index < carsCount; index++)
        {
            string[] input =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            //car engine
            string carModel = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            Engine engine = new Engine(engineSpeed, enginePower, carModel);
            car.AddingEngine(engine);

            //car cargo
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            Cargo cargo = new Cargo(cargoType, cargoWeight, carModel);

            car.AddingCargo(cargo);

            //Tires
            double tire1Pressure = double.Parse(input[5]);
            int tire1Age = int.Parse(input[6]);
            double tire2Pressure = double.Parse(input[7]);
            int tire2Age = int.Parse(input[8]);
            double tire3Pressure = double.Parse(input[9]);
            int tire3Age = int.Parse(input[10]);
            double tire4Pressure = double.Parse(input[11]);
            int tire4Age = int.Parse(input[12]);
            Tire tires = new Tire(carModel, tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure);

            car.AddingTires(tires);
        }

        string command = Console.ReadLine();

        switch (command)
        {
            case "fragile":
                {
                  car.CheckingIfFragile();
                }
                break;
            case "flamable":
                {
                    car.CheckingIfFlamable();
                }
                break;
        }
    }
}
