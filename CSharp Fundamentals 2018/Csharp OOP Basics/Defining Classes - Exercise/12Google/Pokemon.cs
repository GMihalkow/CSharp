using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Pokemon
{
    private string name;
    private string pokemonname;
    private string pokemontype;

    public Pokemon(string personName, string pokemonName, string pokemonType)
    {
        this.name = personName;
        this.pokemonname = pokemonName;
        this.pokemontype = pokemonType;
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string PokemonName
    {
        get { return this.pokemonname; }
        set { this.pokemonname = value; }
    }

    public string PokemonType
    {
        get { return this.pokemontype; }
        set { this.pokemontype = value; }
    }

}

