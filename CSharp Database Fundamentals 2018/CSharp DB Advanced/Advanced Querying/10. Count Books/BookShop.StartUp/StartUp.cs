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
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(CountBooks(context, input));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books =
                context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToArray();

            int result = books.Count();

            return result;
        }
    }
}
