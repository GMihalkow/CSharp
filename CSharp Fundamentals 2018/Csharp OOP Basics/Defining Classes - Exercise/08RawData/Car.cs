using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Car
{
    private List<Engine> engine = new List<Engine>();
    private List<Cargo> cargo = new List<Cargo>();
    private List<Tire> alltires = new List<Tire>();
    
    public void AddingEngine(Engine carengine)
    {
        engine.Add(carengine);
    }

    public void AddingCargo(Cargo carcargo)
    {
        cargo.Add(carcargo);
    }

    public void AddingTires(Tire tir)
    {
        alltires.Add(tir);   
    }

    public void CheckingIfFragile()                                 
    {
        foreach (var cargoType in cargo)
        {
            string carModel = cargoType.Model;
            string TypeOfCargo = cargoType.CargoType;
            if (TypeOfCargo == "fragile")
            {
                foreach (var tire in alltires)
                {
                    if (tire.Model == carModel)
                    {
                        try
                        {
                            double isFragile = tire.TiresPressure.First(x => x < 1);
                            Console.WriteLine(carModel);
                        }
                        catch (Exception)
                        {
                            
                        }
                        break;
                    }
                }
            }
        }
    }

    public void CheckingIfFlamable()
    {
        foreach (var cargotype in cargo)
        {
            string carmodel = cargotype.Model;
            if (cargotype.CargoType == "flamable")
            {
                foreach (var enginepower in engine)
                {
                    if (enginepower.Model == carmodel && enginepower.EnginePower > 250)
                    {
                        Console.WriteLine(enginepower.Model);
                        break;
                    }
                }
            }
        }
    }
}

