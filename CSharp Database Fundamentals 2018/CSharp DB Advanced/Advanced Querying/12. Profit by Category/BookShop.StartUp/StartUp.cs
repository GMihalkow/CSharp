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

            Console.WriteLine(GetTotalProfitByCategory(context));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var books =
                context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ToArray();

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Name} ${book.TotalProfit:f2}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
