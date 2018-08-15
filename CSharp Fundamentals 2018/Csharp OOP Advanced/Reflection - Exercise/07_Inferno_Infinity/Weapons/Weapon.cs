using System;
using System.Collections.Generic;
using System.Text;

public class Weapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private int socketsCount;
    private int strength;
    private int agility;
    private int vitality;
    private Gem[] gems;

    protected Weapon(string name, int minDMG, int maxDMG, int sockets)
    {
        this.Name = name;
        this.minDamage = minDMG;
        this.maxDamage = maxDMG;
        this.socketsCount = sockets;
        Gems = new Gem[sockets];
    }

    public int RarityType { get; set; }

    public Gem[] Gems
    {
        get
        {
            return this.gems;
        }
        private set
        {
            this.gems = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            this.name = value;
        }
    }

    public int Strength
    {
        get
        {
            return this.strength;
        }
        set
        {
            this.strength = value;
        }
    }

    public int Agility
    {
        get
        {
            return this.agility;
        }
        private set
        {
            this.agility = value;
        }
    }

    public int Vitality
    {
        get
        {
            return this.vitality;
        }
        private set
        {
             this.vitality = value;
        }
    }

    public int MinDamage
    {
        get
        {
            return this.minDamage;
        }
        protected set
        {
            this.minDamage = value;
        }
    }

    public int MaxDamage
    {
        get
        {
            return this.maxDamage;
        }
        protected set
        {
            this.maxDamage = value;
        }
    }
    
    public void RarityEffect()
    {
        this.MinDamage *= RarityType;
        this.MaxDamage *= RarityType;
    }
    
    public void OverwriteGem(Gem oldGem, Gem newGem, int index)
    {
        this.Agility -= oldGem.BonusAgility + oldGem.Clarity;
        this.Strength -= oldGem.BonusStrength + oldGem.Clarity;
        this.Vitality -= oldGem.BonusVitality + oldGem.Clarity;

        this.Agility += newGem.BonusAgility + newGem.Clarity;
        this.Strength += newGem.BonusStrength + newGem.Clarity;
        this.Vitality += newGem.BonusVitality + newGem.Clarity;

        gems[index] = newGem;
    }

    public void AddGem(Gem gem, int index)
    {
        this.Agility += gem.BonusAgility;
        this.Strength+= gem.BonusStrength;
        this.Vitality+= gem.BonusVitality;

        this.Agility+= gem.Clarity;
        this.Strength += gem.Clarity;
        this.Vitality+= gem.Clarity;

        gems[index] = gem;
    }

    public void RemoveGem(int index, Gem oldGem)
    {
        this.Agility -= oldGem.BonusAgility + oldGem.Clarity;
        this.Strength -= oldGem.BonusStrength + oldGem.Clarity;
        this.Vitality -= oldGem.BonusVitality + oldGem.Clarity;

        gems[index] = null;
    }
}