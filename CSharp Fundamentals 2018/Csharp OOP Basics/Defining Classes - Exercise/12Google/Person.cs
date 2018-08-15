using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Person
{
    private string name;
    private List<Car> car = new List<Car>();
    private List<Company> company = new List<Company>();
    private List<Parent> parents = new List<Parent>();
    private List<Child> children = new List<Child>();
    private List<Pokemon> pokemons = new List<Pokemon>();

    public Person()
    {

    }

    public Person(string personName, Car personCar)
    {
        this.name = personName;
        car.Add(personCar);
    }

    public Person(string personName, Parent personParents)
    {
        this.name = personName;
        parents.Add(personParents);
    }

    public Person(string personName, Child personChildren)
    {
        this.name = personName;
        children.Add(personChildren);
    }

    public Person(string personName, Pokemon personPokemon)
    {
        this.name = personName;
        pokemons.Add(personPokemon);
    }

    public Person(string personName, Company personCompany)
    {
        this.name = personName;
        company.Add(personCompany);
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public List<Car> Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Company> Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Child> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }
}

