using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> People =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> FilteredPeople = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] CommandInformation =
                    command
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string CommandType = CommandInformation[0];
                string Criteria = CommandInformation[1];
                string LastParameter = CommandInformation[2];

                switch (CommandType)
                {
                    case "Add filter":
                        {
                            switch (Criteria)
                            {
                                case "Starts with":
                                    {
                                        Func<List<string>, List<string>, List<string>> FilterStartsWith = (n, m) =>
                                        {
                                            m.AddRange(n.Where(w => w.StartsWith(LastParameter)));
                                            n.RemoveAll(w => w.StartsWith(LastParameter));
                                            return n.ToList();
                                        };
                                        FilterStartsWith(People, FilteredPeople);
                                    }
                                    break;
                                case "Ends with":
                                    {
                                        Func<List<string>, List<string>, List<string>> FilterEndsWith = (n, m) =>
                                         {
                                             m.AddRange(n.Where(w => w.EndsWith(LastParameter)));
                                             n.RemoveAll(w => w.EndsWith(LastParameter));
                                             return n.ToList();
                                         };
                                        FilterEndsWith(People, FilteredPeople);
                                    }
                                    break;
                                case "Length":
                                    {
                                        Func<List<string>, List<string>, List<string>> FilterByLength = (n, m) =>
                                          {
                                              m.AddRange(n.Where(w => w.Length == int.Parse(LastParameter)));
                                              n.RemoveAll(w => w.Length == int.Parse(LastParameter));
                                              return n.ToList();
                                          };
                                        FilterByLength(People, FilteredPeople);
                                    }
                                    break;
                                case "Contains":
                                    {
                                        Func<List<string>, List<string>, List<string>> FilterIfContains = (n, m) =>
                                        {
                                            m.AddRange(n.Where(w => w.Contains(LastParameter)));
                                            n.RemoveAll(w => w.Contains(LastParameter));
                                            return n.ToList();
                                        };
                                        FilterIfContains(People, FilteredPeople);
                                    }
                                    break;
                            }
                        }
                        break;
                    case "Remove filter":
                        {
                            switch (Criteria)
                            {
                                case "Starts with":
                                    {
                                        Func<List<string>, List<string>, List<string>> RemoveStartsWithFilter = (n, m) =>
                                          {
                                              n.AddRange(m.Where(w => w.StartsWith(LastParameter)));
                                              m.RemoveAll(w => w.StartsWith(LastParameter));
                                              return n.ToList();
                                          };
                                        RemoveStartsWithFilter(People, FilteredPeople);
                                    }
                                    break;
                                case "Ends with":
                                    {
                                        Func<List<string>, List<string>, List<string>> RemoveEndsWithFilter = (n, m) =>
                                          {
                                              n.AddRange(m.Where(w => w.EndsWith(LastParameter)));
                                              m.RemoveAll(w => w.EndsWith(LastParameter));
                                              return n.ToList();
                                          };
                                        RemoveEndsWithFilter(People, FilteredPeople);
                                    }
                                    break;
                                case "Length":
                                    {
                                        Func<List<string>, List<string>, List<string>> RemoveLengthFilter = (n, m) =>
                                          {
                                              n.AddRange(m.Where(w => w.Length == int.Parse(LastParameter)));
                                              m.RemoveAll(w => w.Length == int.Parse(LastParameter));
                                              return n.ToList();
                                          };
                                        RemoveLengthFilter(People, FilteredPeople);
                                    }
                                    break;
                                case "Contains":
                                    {
                                        Func<List<string>, List<string>, List<string>> RemoveContainsFilter = (n, m) =>
                                          {
                                              n.AddRange(m.Where(w => w.Contains(LastParameter)));
                                              m.RemoveAll(w => w.Contains(LastParameter));
                                              return n.ToList();
                                          };
                                        RemoveContainsFilter(People, FilteredPeople);
                                    }
                                    break;
                            }

                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",People));
        }
    }
}
