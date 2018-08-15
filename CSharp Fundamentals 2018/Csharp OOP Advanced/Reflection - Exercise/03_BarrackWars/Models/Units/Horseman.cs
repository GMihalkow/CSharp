using System;
using System.Collections.Generic;
using System.Text;


public class Horseman : Unit
{
    private const int horsemanHealth = 50;
    private const int horsemanDamage = 10;

    public Horseman() : base(horsemanHealth, horsemanDamage)
    {
    }
}