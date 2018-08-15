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

            Console.WriteLine(GetBooksByAuthor(context, input));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            var booksWithAuthors =
                context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    BookTitle = b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach (var book in booksWithAuthors)
            {
                builder.AppendLine($"{book.BookTitle} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return builder.ToString().Trim();
        }
    }
}
