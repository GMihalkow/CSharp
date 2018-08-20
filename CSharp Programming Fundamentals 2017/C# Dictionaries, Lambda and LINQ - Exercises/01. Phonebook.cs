using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DICTIONERIES__LAMBDA_AND_LINQ__EXERCISES
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            List<string> number = new List<string> { "temp" };
            while (true)
            {
                number =
                                Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

                switch (number[0])
                {
                    case "A":
                        {
                            
                                phonebook[number[1]]= number[2];

                        }
                        break;
                    case "S":
                        {
                            if (phonebook.ContainsKey(number[1]))
                            {
                                Console.WriteLine($"{number[1]} -> {phonebook[number[1]]}");

                            }
                            else
                            {
                                Console.WriteLine($"Contact {number[1]} does not exist.");
                            }
                        }
                        break;
                    case "END":
                        {
                            
                            return;
                        }
                        break;
                }

            }
        }
    }
}
