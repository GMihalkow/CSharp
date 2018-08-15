using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
    public Axe(string name, int minDMG, int maxDMG, int sockets ) 
        : base(name, minDMG = 5, maxDMG = 10, sockets = 4)
    {

    }
}