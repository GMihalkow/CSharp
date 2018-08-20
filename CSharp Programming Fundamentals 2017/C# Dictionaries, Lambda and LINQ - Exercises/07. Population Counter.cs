using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_POPULATION_COUNTER
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> countries =
                new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] parameters = input.Split('|');

                string city = parameters[0];
                string country = parameters[1];
                long population = long.Parse(parameters[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                    countries[country].Add(city, population);
                }
                else
                {
                    if (!countries[country].ContainsKey(city))
                    {
                        countries[country].Add(city, population);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var land in countries.OrderByDescending(n => n.Value.Values.Sum()))
            {
                Console.WriteLine($"{land.Key} (total population: {land.Value.Values.Sum()})");
                foreach (var city in land.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
