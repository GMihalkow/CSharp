using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private const string procedureTimeErrorMessage = "Animal doesn't have enough procedure time";

        private List<IAnimal> procedureList;

        protected Procedure()
        {
            this.procedureList = new List<IAnimal>();
        }

        protected IEnumerable<IAnimal> ProcedureHistory { get { return this.procedureList; } }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                this.procedureList.Add(animal);
                animal.ProcedureTime -= procedureTime;
            }
            else
            {
                throw new ArgumentException(procedureTimeErrorMessage);
            }
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine($"   Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}