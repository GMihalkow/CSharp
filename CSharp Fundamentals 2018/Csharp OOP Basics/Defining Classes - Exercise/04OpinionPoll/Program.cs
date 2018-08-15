using System;
using System.Linq;
using System.Collections.Generic;

namespace _04OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            People AllPeople = new People();

            for (int index = 0; index < peopleCount; index++)
            {
                string input = Console.ReadLine();
                string[] NeededInfo =
                    input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string personName = NeededInfo[0];
                int personAge = int.Parse(NeededInfo[1]);

                Person person = new Person(personName, personAge);
                AllPeople.AddPeople(person);
            }

            AllPeople.OldestPeople();
        }
    }
}
