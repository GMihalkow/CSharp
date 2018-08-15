using System;
using System.Collections.Generic;
using System.Text;

public class Gunner : Unit
{
    private const int gunnerHealth = 20;
    private const int gunnerAttackDamage = 20;

    public Gunner() : base(gunnerHealth, gunnerAttackDamage)
    {
    }
}