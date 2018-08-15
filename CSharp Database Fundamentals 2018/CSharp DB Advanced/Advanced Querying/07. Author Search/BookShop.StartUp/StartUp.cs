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

            Console.WriteLine(GetAuthorNamesEndingIn(context, input));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();
            int stringLength = input.Length;

            var authors =
                context
                .Authors
                .Where(a => a.FirstName.Substring(a.FirstName.Length - stringLength) == input)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName + " " + a.LastName)
                .ToArray();

            foreach (var author in authors)
            {
                builder.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return builder.ToString().Trim();
        }
    }
}
