using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Assembler
{
    private List<Person> people = new List<Person>();

    public List<Person> People
    {
        get { return this.people; }
        set { this.people = value; }
    }

    public void AddPeople(string name, Person person)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {

        }
        else
        {
            people.Add(person);
        }
    }

    public void AddPokemon(string name, Pokemon pokemon)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {
            foreach (var prsn in people)
            {
                if (prsn.Name == name)
                {
                    prsn.Pokemons.Add(pokemon);
                    break;
                }
            }
        }

    }

    public void AddParent(string name, Parent parent)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {
            foreach (var prsn in people)
            {
                if (prsn.Name == name)
                {
                    prsn.Parents.Add(parent);
                    break;
                }
            }
        }
    }

    public void AddCompany(string name, Company company)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {
            foreach (var prsn in people)
            {
                if (prsn.Name == name)
                {
                    if (prsn.Company.Count == 0)
                    {
                        prsn.Company.Add(company);
                    }
                    else
                    {
                        prsn.Company[0] = company;

                    }
                    break;
                }
            }
        }
    }

    public void AddCar(string name, Car car)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {
            foreach (var prsn in people)
            {
                if (prsn.Name == name)
                {
                    if (prsn.Car.Count == 0)
                    {
                        prsn.Car.Add(car);
                    }
                    else
                    {
                        prsn.Car[0] = car;
                    }
                    break;
                }
            }
        }
    }

    public void AddChild(string name, Child child)
    {
        bool personIsThere = people.Any(p => p.Name == name);
        if (personIsThere == true)
        {
            foreach (var prsn in people)
            {
                if (prsn.Name == name)
                {
                    prsn.Children.Add(child);
                    break;
                }
            }
        }
    }

    public void PrintingPerson(string name)
    {
        foreach (var prsn in people)
        {
            if (prsn.Name == name)
            {
                Console.WriteLine($"{prsn.Name}");
                Console.WriteLine($"Company:");
                if (prsn.Company.Count > 0)
                {
                    Console.WriteLine($"{prsn.Company[0].CompanyName} {prsn.Company[0].Department} {prsn.Company[0].Salary:f2}");
                }
                Console.WriteLine("Car:");
                if (prsn.Car.Count > 0)
                {
                    Console.WriteLine($"{prsn.Car[0].CarModel} {prsn.Car[0].CarSpeed}");
                }
                Console.WriteLine("Pokemon:");
                foreach (var pokemon in prsn.Pokemons)
                {
                    Console.WriteLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
                }
                Console.WriteLine("Parents:");
                foreach (var parent in prsn.Parents)
                {
                    Console.WriteLine($"{parent.ParentName} {parent.ParentBirthday}");
                }
                Console.WriteLine("Children:");
                foreach (var child in prsn.Children)
                {
                    Console.WriteLine($"{child.ChildName} {child.ChildBirthday}");
                }
                break;
            }
        }
    }
}



