using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    public Knife(string name, int minDMG, int maxDMG, int sockets)
        : base(name, minDMG = 3, maxDMG = 4, sockets = 2)
    {
    }
}