using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Pokemon
{
    private string pokemonname;
    private string element;
    private int pokemonhealth;

    public Pokemon(string name, string pokemonelement, int health)
    {
        this.pokemonname = name;
        this.element = pokemonelement;
        this.pokemonhealth = health;
    }

    public string PokemonNme
    {
        get { return this.pokemonname; }
        set { this.pokemonname = value; }
    }

    public string Element
    {
        get { return this.element; }
        set { this.element = value; }
    }

    public int PokemonHealth
    {
        get { return this.pokemonhealth; }
        set { this.pokemonhealth = value; }
    }
}
