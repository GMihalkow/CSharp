using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string invalidHappinessErrorMessage = "Invalid happiness";
        private const string invalidEnergyErrorMessage = "Invalid energy";
        private const string defaultOwner = "Centre";

        private string name;
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = defaultOwner;
            this.IsChipped = false;
            this.IsAdopt = false;
            this.IsVaccinated = false;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Happiness
        {
            get { return this.happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(invalidHappinessErrorMessage);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(invalidEnergyErrorMessage);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }
    }
}