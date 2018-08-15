using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Comparator equalityComparer = new Comparator();

        SortedSet<Person> sortedSet = new SortedSet<Person>(equalityComparer);

        int peopleCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < peopleCount; index++)
        {
            string[] person =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = person[0];
            int age = int.Parse(person[1]);

            sortedSet.Add(new Person(name, age));
        }

        HashSet<Person> hashSet = new HashSet<Person>(equalityComparer);
        hashSet = sortedSet.ToHashSet();

        Console.WriteLine(sortedSet.Count + Environment.NewLine + hashSet.Count);

    }
}