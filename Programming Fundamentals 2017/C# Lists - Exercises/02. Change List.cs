using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> EVENS = new List<int>();
            List<int> ODDS = new List<int>();

            for (int w = 1; w > 0; w++)

            {
                string[] command =
                (Console.ReadLine())
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


                switch (command[0])
                {
                    case "Delete":
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == Convert.ToInt32(command[1]))
                                {
                                    numbers.RemoveAll(a => a == numbers[i]);
                                }
                            }
                        }
                        break;
                        
                    case "Insert":
                        {
                            numbers.Insert(Convert.ToInt32(command[2]), Convert.ToInt32(command[1]));
                        }break;
                }
                
                if (command[0] == "Even")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0 )
                        {
                            EVENS.Add(numbers[i]);
                        }
                            
                        
                    }
                    Console.WriteLine(String.Join(" ", EVENS));
                    break;

                }

                if(command[0] == "Odd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0 )
                        {
                            ODDS.Add(numbers[i]);
                        }
                    }
                    Console.WriteLine(String.Join(" ", ODDS));
                    break;
                }

            }
        }
    }
}
