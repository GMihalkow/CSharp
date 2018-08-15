using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Engine
{
    private List<Object> lights;
    private int turns;

    public Engine(List<Object> lights, int turns)
    {
        this.lights = lights;
        this.turns = turns;
    }

    public void Run()
    {
        for (int turn = 0; turn < turns; turn++)
        {
            for (int index = 0; index < lights.Count; index++)
            {
                if (lights[index] is Green)
                {
                    lights[index] = Activator.CreateInstance(Type.GetType("Yellow"));
                    continue;
                }
                if (lights[index] is Red)
                {
                    lights[index] = Activator.CreateInstance(Type.GetType("Green"));
                    continue;
                }
                if (lights[index] is Yellow)
                {
                    lights[index] = Activator.CreateInstance(Type.GetType("Red"));
                    continue;
                }
            }
            Console.WriteLine(string.Join(" ", lights));
        }
    }
}