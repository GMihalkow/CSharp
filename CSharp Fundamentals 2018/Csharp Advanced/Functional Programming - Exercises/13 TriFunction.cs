using System;
using System.Linq;
using System.Collections.Generic;

namespace _13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number = int.Parse(Console.ReadLine());
            string[] Names =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            for (int index = 0; index < Names.Length; index++)
            {
                string tempName = Names[index];
                Func<string, int, bool> Checker = (name, sum) =>
                {
                    int InitialSum = 0;
                    for (int charIndex = 0; charIndex < name.Length; charIndex++)
                    {
                        InitialSum += (int)name[charIndex];

                    }
                    if (InitialSum >= sum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                Func<string, bool, string> Printer = (name, verdict) =>
                  {
                      if (verdict == true)
                      {
                          Console.WriteLine(name);
                      }
                      else
                      {
                      }
                      return name;
                  };

                Printer(tempName, Checker(tempName, Number));
                if (Checker(tempName, Number) == true)
                {
                    break;
                }
            }

        }
    }
}
