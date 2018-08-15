using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class People
{
    private List<Person> AllPeople = new List<Person>();

    public void AddPeople(Person person)
    {
        AllPeople.Add(person);
    }

    public void OldestPeople()
    {
        AllPeople = AllPeople.Where(x => x.Age > 30).ToList();
        foreach (var person in AllPeople.OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

