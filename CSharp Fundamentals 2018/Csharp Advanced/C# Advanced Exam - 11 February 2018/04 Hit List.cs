using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input Format:
            //“{name}={key}:{value};{key}:{value};…”.
            int TargetIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> PeopleInfo =
               new Dictionary<string, Dictionary<string, string>>();

            List<string> Temp = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                Temp.Clear();
                string[] inputMessages =
                    input
                    .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string Name = inputMessages[0];

                for (int i = 1; i < inputMessages.Length; i++)
                {
                    Temp.Add(inputMessages[i]);
                }

                if (PeopleInfo.ContainsKey(Name))
                {

                }
                if (!(PeopleInfo.ContainsKey(Name)))
                {
                    PeopleInfo.Add(Name, new Dictionary<string, string>());
                }

                foreach (var element in Temp)
                {
                    string[] ElementInfo =
                        element
                        .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    string Key = ElementInfo[0];
                    string Value = ElementInfo[1];

                    if (PeopleInfo[Name].ContainsKey(Key))
                    {
                        PeopleInfo[Name][Key] = Value;
                    }
                    if (!(PeopleInfo[Name].ContainsKey(Key)))
                    {
                        PeopleInfo[Name].Add(Key, Value);
                    }
                }

            }

            string[] PersonToKill =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string Person = PersonToKill[1];

            int InfoIndexValue = 0;
            Console.WriteLine($"Info on {Person}:");
            foreach (var person in PeopleInfo[Person].OrderBy(x => x.Key))
            {
                InfoIndexValue += person.Key.Length;
                InfoIndexValue += person.Value.Length;
                Console.WriteLine($"---{person.Key}: {person.Value}");
            }
            Console.WriteLine($"Info index: {InfoIndexValue}");
            if (InfoIndexValue >= TargetIndex)
            {
                Console.WriteLine($"Proceed");
            }
            else
            {
                Console.WriteLine($"Need {TargetIndex-InfoIndexValue} more info.");
            }
        }
    }
}
