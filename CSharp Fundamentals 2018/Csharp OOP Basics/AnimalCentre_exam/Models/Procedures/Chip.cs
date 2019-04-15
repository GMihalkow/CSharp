using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const string IsChippedErrorMessage = "{0} is already chipped";

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException(string.Format(IsChippedErrorMessage, animal.Name));
            }
            else
            {
                animal.IsChipped = true;
                animal.Happiness -= 5;
            }
        }
    }
}