using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Trainer
{
    private string trainername;
    private int badges;
    private List<Pokemon> pokemons = new List<Pokemon>();
    
    public Trainer(string name, int badge, Pokemon pokemon)
    {
        this.trainername = name;
        this.badges = badge;
        this.pokemons.Add(pokemon);
    }
    
    public string TrainerName
    {
        get { return this.trainername; }
        set { this.trainername = value; }
    }

    public int Badges
    {
        get { return this.badges; }
        set { this.badges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }
}

