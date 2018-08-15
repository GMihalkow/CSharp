using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Competitors
{
    private List<Trainer> trainers = new List<Trainer>();

    public List<Trainer> Trainers
    {
        get { return this.trainers; }
        set { this.trainers = value; }
    }

    public void AddingCompetitors(string name, Trainer trainer, Pokemon pokemons)
    {
        bool tempName =
            trainers
            .Any(t => t.TrainerName == trainer.TrainerName);

        if (tempName == true)
        {
            foreach (var tr in trainers)
            {
                if (tr.TrainerName == name)
                {
                    tr.Pokemons.Add(pokemons);
                    break;
                }
            }
        }
        else
        {
            trainers.Add(trainer);
        }
    }

    public void CheckingElements(string element)
    {
        foreach (var trainer in trainers)
        {
            bool isThere = trainer.Pokemons.Any(p => p.Element == element);
            if (isThere == true)
            {
                trainer.Badges++;
            }
            else
            {
                trainer.Pokemons.Select(p => p.PokemonHealth -= 10).ToList();
            }
        }

        foreach (var trainer in trainers)
        {
            trainer.Pokemons.RemoveAll(p => p.PokemonHealth <= 0);
        }
    }

    public void PrintingResults()
    {
        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.TrainerName} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}

