using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const string CapacityErrorMessage = "Not enough capacity";

        private const string AnimalExistsErrorMessage = "Animal {0} already exist";

        private const string InvalidAnimalNameErrorMessage = "Animal {0} does not exist";

        private readonly Dictionary<string, IAnimal> animals;

        private int capacity = 10;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals { get { return this.animals; } }

        private int Capacity { get { return this.capacity; } }

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count() == this.Capacity)
            {
                throw new InvalidOperationException(CapacityErrorMessage);
            }
            else if (this.Animals.Any(a => a.Key == animal.Name))
            {
                throw new ArgumentException(string.Format(AnimalExistsErrorMessage, animal.Name));
            }
            else
            {
                this.animals.Add(animal.Name, animal);
            }
        }

        public void Adopt(string animalName, string owner)
        {
            var animal = this.Animals.FirstOrDefault(a => a.Key == animalName).Value;
            if (animal == null)
            {
                throw new ArgumentException(string.Format(InvalidAnimalNameErrorMessage, animalName));
            }
            else
            {
                animal.IsAdopt = true;
                animal.Owner = owner;
                this.animals.Remove(animalName);
            }
        }
    }
}