namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            BookShopContext context = new BookShopContext();
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(context, input));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DateTime neededDate = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var books =
                context
                .Books
                .Where(b => b.ReleaseDate < neededDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return stringBuilder.ToString().Trim(); ;
        }
    }
}
