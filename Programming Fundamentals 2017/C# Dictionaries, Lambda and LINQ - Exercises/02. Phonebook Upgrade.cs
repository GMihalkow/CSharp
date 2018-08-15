using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_PHONEBOOK_UPGRADE
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();

            while (true)
            {
                var command =
                    Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                switch (command[0])
                {
                    case "A":
                        {
                            phonebook[command[1]] = command[2];
                        }break;
                    case "S":
                        {
                            if (phonebook.ContainsKey(command[1]))
                            {
                                Console.WriteLine($"{command[1]} -> {phonebook[command[1]]}");
                            }
                            else
                            {
                                Console.WriteLine($"Contact {command[1]} does not exist.");
                            }
                        }
                        break;
                    case "ListAll":
                        {
                            foreach (var item in phonebook)
                            {
                                Console.WriteLine($"{item.Key} -> {item.Value}");
                            }
                        }
                        break;
                    case "END":
                        {
                            return;
                        }
                }
            }
        }
    }
}
