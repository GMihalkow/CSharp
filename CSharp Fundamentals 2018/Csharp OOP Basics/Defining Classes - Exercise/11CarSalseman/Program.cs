using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       // Car car = new Car();
        Parameters parameters = new Parameters();
        //Engine information format:
        //“<Model> <Power> <Displacement>* <Efficiency>*”. 
        // <Displacement>* <Efficiency>*
        int linesCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < linesCount; index++)
        {
            string[] EngineInfo =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string engineModel = EngineInfo[0];
            int enginePower = int.Parse(EngineInfo[1]);
            int displacement = 0;
            string efficiency = @"n/a";

            if (EngineInfo.Length == 3)
            {
                bool isDisplacement = int.TryParse(EngineInfo[2], out displacement);
                if (!isDisplacement)
                {
                    efficiency = EngineInfo[2];
                }
            }
            else if(EngineInfo.Length == 4)
            {
                displacement = int.Parse(EngineInfo[2]);
                efficiency = EngineInfo[3];
            }

            Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
            parameters.AddingEngineInformation(engine);
        }

        //Car information format:
        //“<Model> <Engine> <Weight>* <Color>*”.
        // <Weight>* <Color>*”.
        int carsCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < carsCount; index++)
        {
            string[] CarInformation =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string carModel = CarInformation[0];
            string carEngine = CarInformation[1];
            int carWeight = 0;
            string carColor = @"n/a";

            if (CarInformation.Length == 3)
            {
                bool IsWeight = int.TryParse(CarInformation[2], out carWeight);
                if (!IsWeight)
                {
                    carColor = CarInformation[2];
                }
            }
            else if (CarInformation.Length == 4)
            {
                carWeight = int.Parse(CarInformation[2]);
                carColor = CarInformation[3];
            }

            List<Engine> engines = new List<Engine>();


            foreach (var eng in parameters.Engine)
            {
                if (eng.EngineModel == carEngine)
                {
                    Engine en = new Engine(eng.EngineModel, eng.EnginePower,eng.Displacement, eng.Efficiency);
                    engines.Add(en);
                    break;
                }
            }

            Car car = new Car(carModel, engines, carWeight, carColor);
            parameters.AddingCarInformation(car);
        }

        parameters.ToString();
        //Output format:
        //<CarModel>:
        //< EngineModel >:
        //  Power: < EnginePower >
        //  Displacement: < EngineDisplacement >
        //  Efficiency: < EngineEfficiency >
        //Weight: < CarWeight >
        //Color: < CarColor >

    }
}
