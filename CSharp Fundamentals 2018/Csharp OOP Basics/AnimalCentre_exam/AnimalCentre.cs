using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre
{
    public class AnimalCentre
    {
        private const string animalDoesntExistErrorMessage = "Animal {0} does not exist";
        private const string animalRegisteredSuccessfullyMessage = "Animal {0} registered successfully";

        private const string chipMessage = "{0} had chip procedure";
        private const string vaccinationMessage = "{0} had vaccination procedure";
        private const string fitnessMessage = "{0} had fitness procedure";
        private const string playMessage = "{0} was playing for {1} hours";
        private const string dentalCareMessage = "{0} had dental care procedure";
        private const string nailTrimProcedure = "{0} had nail trim procedure";

        private const string adoptedWithChipMessage = "{0} adopted animal with chip";
        private const string adoptedWithoutChipMessage = "{0} adopted animal without chip";

        private static string[] animalTypes = new string[] { "Cat", "Dog", "Lion", "Pig" };

        private readonly IHotel hotel;

        private readonly Chip chip;
        private readonly Fitness fitness;
        private readonly Play play;
        private readonly NailTrim nailTrim;
        private readonly DentalCare dentalCare;
        private readonly Vaccinate vaccinate;

        private readonly Dictionary<string, List<IAnimal>> owners;

        public AnimalCentre(Hotel hotel, Dictionary<string, List<IAnimal>> owners)
        {
            this.owners = owners;
            this.hotel = hotel;

            this.chip = new Chip();
            this.vaccinate = new Vaccinate();
            this.play = new Play();
            this.nailTrim = new NailTrim();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
        }

        private bool AnimalExists(string name)
        {
            if (this.hotel.Animals.Any(a => a.Key == name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (!animalTypes.Contains(type))
            {
                throw new Exception("ERROR!");
            }

            Animal animal = null;

            if (type == "Cat")
            {
                animal = new Cat(name, energy, happiness, procedureTime);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, energy, happiness, procedureTime);
            }
            else if (type == "Lion")
            {
                animal = new Lion(name, energy, happiness, procedureTime);
            }
            else if (type == "Pig")
            {
                animal = new Pig(name, energy, happiness, procedureTime);
            }
            
            hotel.Accommodate(animal);
        
            return string.Format(animalRegisteredSuccessfullyMessage, animal.Name);
        }

        public string Chip(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            chip.DoService(animal, procedureTime);

            return string.Format(chipMessage, name);
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            vaccinate.DoService(animal, procedureTime);

            return string.Format(vaccinationMessage, name);
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            fitness.DoService(animal, procedureTime);

            return string.Format(fitnessMessage, name);
        }

        public string Play(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            play.DoService(animal, procedureTime);

            return string.Format(playMessage, name, procedureTime);
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            dentalCare.DoService(animal, procedureTime);

            return string.Format(dentalCareMessage, name);
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, name));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;
            
            nailTrim.DoService(animal, procedureTime);

            return string.Format(nailTrimProcedure, name);
        }

        public string Adopt(string animalName, string owner)
        {
            if (!AnimalExists(animalName))
            {
                throw new ArgumentException(string.Format(animalDoesntExistErrorMessage, animalName));
            }

            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == animalName);

            this.hotel.Adopt(animalName, owner);

            if (this.owners.ContainsKey(owner))
            {
                this.owners[owner].Add(animal.Value);
            }
            else
            {
                this.owners[owner] = new List<IAnimal>();
                this.owners[owner].Add(animal.Value);
            }

            if (animal.Value.IsChipped)
            {
                return string.Format(adoptedWithChipMessage, owner);
            }
            else
            {
                return string.Format(adoptedWithoutChipMessage, owner);
            }
        }

        public string History(string type)
        {
            if(type == "Chip")
            {
                return chip.History().TrimEnd();
            }
            else if (type == "DentalCare")
            {
                return dentalCare.History().TrimEnd();
            }
            else if (type == "Fitness")
            {
                return fitness.History().TrimEnd();
            }
            else if (type == "NailTrim")
            {
                return nailTrim.History().TrimEnd();
            }
            else if (type == "Play")
            {
                return play.History().TrimEnd();
            }
            else 
            {
                return vaccinate.History().TrimEnd();
            }
        }
    }
}