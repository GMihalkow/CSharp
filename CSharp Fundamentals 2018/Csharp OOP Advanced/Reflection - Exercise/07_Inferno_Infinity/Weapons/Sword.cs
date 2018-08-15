using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    public Sword(string name, int minDMG, int maxDMG, int sockets)
        : base(name, minDMG = 4, maxDMG = 6, sockets = 3)
    {
    }
}