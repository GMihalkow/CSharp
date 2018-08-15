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

            Console.WriteLine(GetBookTitlesContaining(context, input));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books =
                context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            string result = string.Join(Environment.NewLine, books);

            return result.Trim();
        }
    }
}
