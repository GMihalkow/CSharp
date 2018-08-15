using System;
using System.Reflection;
//using Contracts;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        //TODO: implement for Problem 3
        Type classType = Type.GetType("UnitRepository");
        Type typeOfUnit = Type.GetType(unitType);
        object instanceRepo = Activator.CreateInstance(classType);
        MethodInfo method = classType.GetMethod("AddUnit");

        var unit =(IUnit)Activator.CreateInstance(typeOfUnit);

        method.Invoke(instanceRepo, new object[] { unit });

        return unit;
    }
}
