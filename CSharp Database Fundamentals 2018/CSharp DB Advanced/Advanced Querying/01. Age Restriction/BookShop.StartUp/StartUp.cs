namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();
            string ageRestriction = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(context, ageRestriction));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder builder = new StringBuilder();

            var Restriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var booksWithRestriction =
                context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(b => b.AgeRestriction == Restriction)
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var book in booksWithRestriction)
            {
                builder.AppendLine($"{book.Title}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
