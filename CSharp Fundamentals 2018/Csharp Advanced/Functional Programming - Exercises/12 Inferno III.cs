using System;
using System.Linq;
using System.Collections.Generic;

namespace _12_Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            List<int> Numbers =
                 Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(Parser)
                 .ToList();

            List<int> NumbersToExclude = new List<int>();

            string command;
            while ((command = Console.ReadLine()) != "Forge")
            {
                string[] CommandInformation =
                    command
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string CommandType = CommandInformation[0];
                string Direction = CommandInformation[1];
                int LastParameter = Parser(CommandInformation[2]);

                switch (CommandType)
                {
                    case "Exclude":
                        {
                            switch (Direction)
                            {
                                case "Sum Left":
                                    {
                                        Func<List<int>, List<int>, List<int>> ExcludeLeft = (firstNum, secondNum) =>
                                          {
                                              for (int index = 0; index < firstNum.Count; index++)
                                              {
                                                  if ((index - 1) < 0)
                                                  {
                                                      if ((firstNum[index] + 0) == LastParameter)
                                                      {
                                                          secondNum.Add(firstNum[index]);
                                                      }
                                                      continue;
                                                  }
                                                  if ((firstNum[index] + firstNum[index - 1]) == LastParameter)
                                                  {
                                                      secondNum.Add(firstNum[index]);
                                                  }
                                              }
                                              return secondNum.ToList();
                                          };
                                        ExcludeLeft(Numbers, NumbersToExclude);
                                    }
                                    break;
                                case "Sum Right":
                                    {
                                        Func<List<int>, List<int>, List<int>> ExcludeRight = (firstList, secondList) =>
                                         {
                                             for (int index = 0; index < firstList.Count; index++)
                                             {
                                                 if ((index + 1) > (firstList.Count - 1))
                                                 {
                                                     if ((firstList[index] + 0) == LastParameter)
                                                     {
                                                         secondList.Add(firstList[index]);
                                                     }
                                                     continue;
                                                 }
                                                 if ((firstList[index] + firstList[index + 1]) == LastParameter)
                                                 {
                                                     secondList.Add(firstList[index]);
                                                 }
                                             }
                                             return secondList.ToList();
                                         };
                                        ExcludeRight(Numbers, NumbersToExclude);
                                    }
                                    break;
                                case "Sum Left Right":
                                    {
                                        Func<List<int>, List<int>, List<int>> ExcludeBoth = (firstList, secondList) =>
                                        {
                                            for (int index = 0; index < firstList.Count; index++)
                                            {
                                                if ((index - 1) < 0 && (index + 1 > firstList.Count - 1))
                                                {
                                                    if ((firstList[index] + 0) == LastParameter)
                                                    {
                                                        secondList.Add(firstList[index]);
                                                    }
                                                    continue;
                                                }
                                                if ((index - 1) < 0)
                                                {
                                                    if ((firstList[index] + 0 + firstList[index + 1]) == LastParameter)
                                                    {
                                                        secondList.Add(firstList[index]);
                                                    }
                                                    continue;
                                                }
                                                if ((index + 1) > firstList.Count - 1)
                                                {
                                                    if ((firstList[index] + 0 + firstList[index - 1]) == LastParameter)
                                                    {
                                                        secondList.Add(firstList[index]);
                                                    }

                                                    continue;
                                                }
                                                if ((firstList[index] + firstList[index - 1] + firstList[index + 1]) == LastParameter)
                                                {

                                                    secondList.Add(firstList[index]);
                                                }
                                            }
                                            return secondList.ToList();
                                        };
                                        ExcludeBoth(Numbers, NumbersToExclude);
                                    }
                                    break;
                            }
                        }
                        break;
                    case "Reverse":
                        {
                            switch (Direction)
                            {
                                case "Sum Left":
                                    {
                                        Func<List<int>, List<int>, List<int>> ReverseSumLeftCommand = (oldNumbers, newNumbers) =>
                                          {
                                              for (int index = 0; index < Numbers.Count; index++)
                                              {
                                                  if (index - 1 < 0)
                                                  {
                                                      if ((oldNumbers[index] + 0) == LastParameter)
                                                      {
                                                          if (newNumbers.Contains(oldNumbers[index]))
                                                          {
                                                              newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                          }
                                                      }
                                                      continue;
                                                  }
                                                  if ((oldNumbers[index] + oldNumbers[index - 1]) == LastParameter)
                                                  {
                                                      if (newNumbers.Contains(oldNumbers[index]))
                                                      {
                                                          newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                      }
                                                  }
                                              }
                                              return oldNumbers.ToList();
                                          };
                                        ReverseSumLeftCommand(Numbers, NumbersToExclude);
                                    }
                                    break;
                                case "Sum Right":
                                    {
                                        Func<List<int>, List<int>, List<int>> ReverseSumLeftCommand = (oldNumbers, newNumbers) =>
                                        {
                                            for (int index = 0; index < Numbers.Count; index++)
                                            {
                                                if (index + 1 > Numbers.Count - 1)
                                                {
                                                    if ((oldNumbers[index] + 0) == LastParameter)
                                                    {
                                                        if (newNumbers.Contains(oldNumbers[index]))
                                                        {
                                                            newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                        }
                                                        
                                                    }
                                                    continue;
                                                }
                                                if ((oldNumbers[index] + oldNumbers[index + 1]) == LastParameter)
                                                {
                                                    if (newNumbers.Contains(oldNumbers[index]))
                                                    {
                                                        newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                    }
                                                }
                                            }
                                            return oldNumbers.ToList();
                                        };
                                        ReverseSumLeftCommand(Numbers, NumbersToExclude);
                                    }
                                    break;
                                case "Sum Left Right":
                                    {
                                        Func<List<int>, List<int>, List<int>> ReverseBothCommands = (oldNumbers, newNumbers) =>
                                        {
                                            for (int index = 0; index < Numbers.Count; index++)
                                            {
                                                if ((index - 1 < 0) && (index + 1 > Numbers.Count - 1))
                                                {
                                                    if ((oldNumbers[index] + 0) == LastParameter)
                                                    {
                                                        if (newNumbers.Contains(oldNumbers[index]))
                                                        {
                                                            newNumbers.RemoveAll(x => x == oldNumbers[index]);

                                                        }
                                                    }
                                                    continue;
                                                }

                                                if (index - 1 < 0)
                                                {
                                                    if ((oldNumbers[index] + 0 + oldNumbers[index + 1]) == LastParameter)
                                                    {
                                                        if (newNumbers.Contains(oldNumbers[index]))
                                                        {
                                                            newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                        }
                                                    }
                                                    continue;
                                                }

                                                if (index + 1 > Numbers.Count - 1)
                                                {
                                                    if ((oldNumbers[index] + 0 + oldNumbers[index - 1]) == LastParameter)
                                                    {
                                                        if (newNumbers.Contains(oldNumbers[index]))
                                                        {
                                                            newNumbers.RemoveAll(x => x == oldNumbers[index]);
                                                        }
                                                    }
                                                    continue;
                                                }
                                                if ((oldNumbers[index] + oldNumbers[index - 1] + oldNumbers[index + 1]) == LastParameter)
                                                {
                                                    if (newNumbers.Contains(oldNumbers[index]))
                                                    {
                                                        newNumbers.RemoveAll(x => x == oldNumbers[index]);

                                                    }
                                                }

                                            }
                                            return oldNumbers.ToList();
                                        };
                                        ReverseBothCommands(Numbers, NumbersToExclude);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }

            Func<List<int>, List<int>> FilteringSequence = numbers =>
            {
                foreach (var num in NumbersToExclude)
                {
                    numbers.Remove(num);
                }
                return numbers.ToList();
            };
            Console.WriteLine(String.Join(" ", FilteringSequence(Numbers)));
        }
    }
}