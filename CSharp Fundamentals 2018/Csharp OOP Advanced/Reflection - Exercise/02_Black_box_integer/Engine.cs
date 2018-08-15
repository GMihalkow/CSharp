using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Engine
{
    private Object blackBox;

    public Engine()
    {
        Type classType = Type.GetType("BlackBoxInteger");
         blackBox = Activator.CreateInstance(classType, true);
    }

    public string Run(string className, string methodName, int parameter)
    {
        Type classType = Type.GetType(className);
        MethodInfo method = classType.GetMethod(methodName, (BindingFlags.NonPublic | BindingFlags.Instance));

        method.Invoke(blackBox, new object[] { parameter });
        FieldInfo field = classType.GetField("innerValue", (BindingFlags.NonPublic | BindingFlags.Instance));

        return $"{field.GetValue(blackBox)}";
    }
}