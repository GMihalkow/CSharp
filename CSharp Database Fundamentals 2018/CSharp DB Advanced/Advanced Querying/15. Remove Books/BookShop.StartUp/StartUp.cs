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
            Console.WriteLine($"{RemoveBooks(context)} books were deleted");
        }

        public static int RemoveBooks(BookShopContext context)
        {
            int tempCount = 0;

            var booksToDelete =
                context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            tempCount = booksToDelete.Count();

            while (booksToDelete.Count != 0)
            {
                context.Entry(booksToDelete.First()).State = EntityState.Deleted;
                booksToDelete.Remove(booksToDelete.First());

            }

            context.SaveChanges();

            return tempCount;
        }
    }
}
