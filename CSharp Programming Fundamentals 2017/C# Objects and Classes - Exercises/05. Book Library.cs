using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _05_BOOK_LIBRARY
{
    class LIBRARY
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN{ get; set; }
        public decimal Price{ get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int booksCount = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < booksCount; i++)
            {
                books.Add(ReadBook(Console.ReadLine()));
            }

            LIBRARY library = new LIBRARY { Name = "Library", Books = books };

            Dictionary<string, decimal> authors = new Dictionary<string, decimal>();

            foreach (Book book in library.Books)
            {
                if (authors.ContainsKey(book.Author))
                {
                    authors[book.Author] += book.Price;
                }
                else
                {
                    authors[book.Author] = book.Price;
                }
            }

            foreach (var pair in authors.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
            }
        }

        static Book ReadBook (string input)
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string title = tokens[0];
            string author = tokens[1];
            string publisher = tokens[2];
            DateTime realeaseDate = DateTime.ParseExact(tokens[3], "d.M.yyyy",
                CultureInfo.InvariantCulture);
            string ISBN = tokens[4];
            decimal price = decimal.Parse(tokens[5]);

            return new Book
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                ReleaseDate = realeaseDate,
                ISBN = ISBN,
                Price = price
            };
        }
    }
}
