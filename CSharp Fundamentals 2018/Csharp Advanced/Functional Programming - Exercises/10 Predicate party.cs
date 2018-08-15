using System;
using System.Linq;
using System.Collections.Generic;

namespace _10_Predicate_party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> InvitedPeople =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] CommandInfo =
                    command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = CommandInfo[0];
                string criteria = CommandInfo[1];
                string LastParameter = CommandInfo[2];

                switch (commandType)
                {
                    case "Remove":
                        {
                            switch (criteria)
                            {
                                case "StartsWith":
                                    {
                                        Func<List<string>, List<string>> RemoveStartsWith = n =>
                                        {
                                            n.RemoveAll(w => w.StartsWith(LastParameter));
                                            return n.ToList();
                                        };
                                        RemoveStartsWith(InvitedPeople);
                                    }
                                    break;
                                case "Length":
                                    {
                                        Func<List<string>, List<string>> RemoveWithLength = n =>
                                        {
                                            n.RemoveAll(w => w.Length == int.Parse(LastParameter));
                                            return n.ToList();
                                        };
                                        RemoveWithLength(InvitedPeople);
                                    }
                                    break;
                                case "EndsWith":
                                    {
                                        Func<List<string>, List<string>> RemoveEndsWith = n =>
                                        {
                                            n.RemoveAll(w => w.EndsWith(LastParameter));
                                            return n.ToList();
                                        };
                                        RemoveEndsWith(InvitedPeople);
                                    }
                                    break;
                            }
                        }
                        break;
                    case "Double":
                        {
                            switch (criteria)
                            {
                                case "StartsWith":
                                    {
                                        Func<List<string>, List<string>> DoubleStartsWith = n =>
                                         {
                                             for (int i = 0; i < n.Count; i++)
                                             {
                                                 if (n[i].StartsWith(LastParameter))
                                                 {
                                                     n.Insert(i, n[i]);
                                                     i++;
                                                 }
                                             }
                                             return n.ToList();
                                         };
                                        DoubleStartsWith(InvitedPeople);
                                    }
                                    break;
                                case "Length":
                                    {
                                        Func<List<string>, List<string>> DoubleLength = n =>
                                         {
                                             for (int i = 0; i < n.Count; i++)
                                             {
                                                 if (n[i].Length == int.Parse(LastParameter))
                                                 {
                                                     n.Insert(i, n[i]);
                                                     i++;
                                                 }
                                             }
                                             return n.ToList();
                                         };
                                        DoubleLength(InvitedPeople);
                                    }
                                    break;
                                case "EndsWith":
                                    {
                                        Func<List<string>, List<string>> DoubleEndsWith = n =>
                                        {
                                            for (int i = 0; i < n.Count; i++)
                                            {
                                                if (n[i].EndsWith(LastParameter))
                                                {
                                                    n.Insert(i, n[i]);
                                                    i++;
                                                }
                                            }
                                            return n.ToList();
                                        };
                                        DoubleEndsWith(InvitedPeople);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            if (InvitedPeople.Count < 1)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", InvitedPeople) + " are going to the party!");
            }
        }
    }
}

