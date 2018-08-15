using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AgeComparator ageComparator = new AgeComparator();
        NameComparator nameComparator = new NameComparator();

        SortedSet<Person> ageComparedPeople = new SortedSet<Person>(ageComparator);
        SortedSet<Person> nameComparedPeople = new SortedSet<Person>(nameComparator);

        int peopleCount = int.Parse(Console.ReadLine());
        for (int index = 0; index < peopleCount; index++)
        {
            string[] person =
            Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            string name = person[0];
            int age = int.Parse(person[1]);

            ageComparedPeople.Add(new Person(name, age));
            nameComparedPeople.Add(new Person(name, age));
        }

        foreach (var person in nameComparedPeople)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
        foreach (var person in ageComparedPeople)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
    }
}