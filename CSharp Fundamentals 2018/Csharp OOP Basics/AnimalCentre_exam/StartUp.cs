using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var hotel = new Hotel();
            var owners = new Dictionary<string, List<IAnimal>>();

            var animalCentre = new AnimalCentre(hotel, owners);

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var splitParameters =
                    input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = splitParameters[0];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            {
                                var type = splitParameters[1];
                                var name = splitParameters[2];
                                var energy = int.Parse(splitParameters[3]);
                                var happiness = int.Parse(splitParameters[4]);
                                var procedureTime = int.Parse(splitParameters[5]);

                                Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime));
                            }
                            break;
                        case "Chip":
                            {
                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.Chip(name, procedureTime));
                            }
                            break;
                        case "Vaccinate":
                            {

                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
                            }
                            break;
                        case "Fitness":
                            {

                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.Fitness(name, procedureTime));
                            }
                            break;
                        case "Play":
                            {

                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.Play(name, procedureTime));
                            }
                            break;
                        case "DentalCare":
                            {

                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
                            }
                            break;
                        case "NailTrim":
                            {

                                var name = splitParameters[1];
                                var procedureTime = int.Parse(splitParameters[2]);

                                Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
                            }
                            break;
                        case "Adopt":
                            {
                                var animalName = splitParameters[1];
                                var owner = splitParameters[2];

                                Console.WriteLine(animalCentre.Adopt(animalName, owner));
                            }
                            break;
                        case "History":
                            {
                                var procedureType = splitParameters[1];

                                Console.WriteLine(animalCentre.History(procedureType));
                            }
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.GetType().Name + ": " + e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.GetType().Name + ": " + e.Message);
                }
            }

            foreach (var owner in owners.OrderBy(o => o.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value.Select(a => a.Name))}");
            }
        }
    }
}