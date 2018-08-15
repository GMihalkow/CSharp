using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Parameters
{
    private List<Car> car = new List<Car>();
    private List<Engine> engine = new List<Engine>();

    public List<Engine> Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public List<Car> Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public void AddingEngineInformation(Engine engineinfo)
    {
        engine.Add(engineinfo);
    }

    public void AddingCarInformation(Car carinfo)
    {
        car.Add(carinfo);
    }

    public override string ToString()
    {
        foreach (var car in Car)
        {
            Console.WriteLine($"{car.Model}:");
            
            foreach (var eng in car.Engine)
            {
                Console.WriteLine($"  {eng.EngineModel}:");
                Console.WriteLine($"  Power: {eng.EnginePower}");
                if (eng.Displacement == 0)
                {
                    Console.WriteLine(@"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {eng.Displacement}");
                }
                Console.WriteLine($"    Efficiency: {eng.Efficiency}");
                break;
            }
            if (car.Weight == 0)
            {
                Console.WriteLine(@"  Weight: n/a");
            }
            else
            {
                Console.WriteLine($"  Weight: {car.Weight}");
            }
            Console.WriteLine($"  Color: {car.Color}");
           
        }
        return "a";
    }
}

