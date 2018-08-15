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

            Console.WriteLine(GetMostRecentBooks(context));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var categories =
                context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(x => x.Year)
                    .ToArray()
                })
                .OrderBy(b => b.Name)
                .ToArray();

            foreach (var category in categories)
            {
                stringBuilder.AppendLine($"--{category.Name}");
                foreach (var book in category.Books.Take(3))
                {
                    stringBuilder.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
