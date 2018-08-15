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
            IncreasePrices(context);
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books =
                context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();

        }
    }
}
