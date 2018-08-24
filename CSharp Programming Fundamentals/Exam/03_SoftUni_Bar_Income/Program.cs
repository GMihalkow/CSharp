using System;
using System.Text.RegularExpressions;

namespace _03_SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^\%{1}([A-Z][a-z]+)\%[^\|\%\$\.]*\<(\w*)\>[^\|\%\$\.]*\|([0-9]+)\|[^\|\%\$\.]*?([0-9]+\.[0-9]+|[0-9]+)\$[^\|\%\$\.]*?$";

            Regex regex = new Regex(pattern);

            double income = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                if (regex.Match(input).Success == false) continue;

                var match = regex.Match(input);
                var groups = match.Groups;

                string name = groups[1].ToString();
                string product = groups[2].ToString();
                long count = long.Parse(groups[3].ToString());
                double price = double.Parse(groups[4].ToString());

                double totalPrice = price * count;
                income += totalPrice;
                Console.WriteLine($"{name}: {product} - {totalPrice:F2}");
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
