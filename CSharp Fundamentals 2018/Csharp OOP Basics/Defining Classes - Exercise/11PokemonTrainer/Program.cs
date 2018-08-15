using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Competitors competitors = new Competitors();
        string command;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] TrainerInformation =
                command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string trainerName = TrainerInformation[0];
            string pokemonName = TrainerInformation[1];
            string pokemonElement = TrainerInformation[2];
            int pokemonHealth = int.Parse(TrainerInformation[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            Trainer trainer = new Trainer(trainerName, 0, pokemon);
            competitors.AddingCompetitors(trainerName, trainer, pokemon);
        }

        string element;
        while ((element = Console.ReadLine()) != "End")
        {
            competitors.CheckingElements(element);
        }

        competitors.PrintingResults();
    }
}

