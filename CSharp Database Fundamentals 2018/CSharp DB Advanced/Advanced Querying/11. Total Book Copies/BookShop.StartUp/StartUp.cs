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
            //int input = int.Parse(Console.ReadLine());

            Console.WriteLine(CountCopiesByAuthor(context));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var AuthorsWithBooksCount =
                context
                .Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            foreach (var author in AuthorsWithBooksCount)
            {
                builder.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return builder.ToString().Trim();
        }
    }
}
