using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Engine
{
    private List<Weapon> weapons;

    public Engine(List<Weapon> weps)
    {
        this.weapons = weps;
    }

    public void Run(string input)
    {
        Type weaponFactory = Type.GetType("WeaponFactory");
        Object wep = Activator.CreateInstance(weaponFactory);

        string[] args =
            input
            .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string command = args[0];

        MethodInfo method = weaponFactory.GetMethod(command);

        method.Invoke(wep, new object[] { weapons, args });
    }
}