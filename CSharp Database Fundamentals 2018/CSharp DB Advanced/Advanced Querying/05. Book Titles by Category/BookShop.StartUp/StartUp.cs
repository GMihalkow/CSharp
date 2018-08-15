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
            string input = Console.ReadLine().ToLower();

            Console.WriteLine(GetBooksByCategory(context, input));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> bookTitles = new List<string>();

            StringBuilder stringBuilder = new StringBuilder();

            var books =
                context
                .Categories
                .Where(c => categories.Any(c1 => c1.ToLower() == c.Name.ToLower()))
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BookTitles = c.CategoryBooks.Select(b => b.Book.Title).ToArray()
                })
                .ToArray();

            foreach (var category in books)
            {
                foreach (var book in category.BookTitles)
                {
                    bookTitles.Add(book);
                }
            }

            bookTitles = bookTitles.OrderBy(b => b).ToList();

            foreach (var title in bookTitles)
            {
                stringBuilder.AppendLine($"{title}");
            }
            int count = bookTitles.Count();
            //това с count го видях от един колега

            return stringBuilder.ToString().Trim();
        }
    }
}
