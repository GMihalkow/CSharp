namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Linq;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner =
                context
                .Prisoners
                .Where(p => p.Id == prisonerId)
                .First();

            string result = string.Empty;

            if (prisoner.ReleaseDate == null)
            {
                 result = $"Prisoner {prisoner.FullName} is sentenced to life";
            }
            else
            {
                prisoner.ReleaseDate = DateTime.Now;
                prisoner.CellId = null;
                result = $"Prisoner {prisoner.FullName} released";
            }

            context.SaveChanges();

            return result.TrimEnd();
        }
    }
}
