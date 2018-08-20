using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_A_MINER_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                int quantity;
                if (resource == "stop")
                {
                    break;
                }
                else
                {
                    quantity = int.Parse(Console.ReadLine());

                    if (source.ContainsKey(resource))
                    {
                        source[resource] += quantity;
                        continue;
                    }
                    source.Add(resource, quantity);
                   
                    continue;
                }

            }
            foreach (var item in source)
            { 
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
