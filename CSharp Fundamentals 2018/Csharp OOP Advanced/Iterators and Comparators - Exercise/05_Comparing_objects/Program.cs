using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person<string>> People = new List<Person<string>>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] personDetails =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            People.Add(new Person<string>(personDetails));
        }

        int personIndex = int.Parse(Console.ReadLine());

        int equalPeopleCount = 0;
        int notEqualPeople = 0;
        int totalPeopleCount = People.Count;

        if (personIndex > totalPeopleCount - 1)
        {
            Console.WriteLine("No matches");
            return;
        }
        Person<string> personToCompareWith = People[personIndex];

        for (int index = 0; index < totalPeopleCount; index++)
        {
            int result = personToCompareWith.CompareTo(People[index]);
            if (result == 0)
            {
                equalPeopleCount++;
            }
            else
            {
                notEqualPeople++;
            }
        }

        if (equalPeopleCount == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeopleCount} {notEqualPeople} {totalPeopleCount}");
        }
    }
}