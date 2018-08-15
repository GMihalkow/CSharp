using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Familiy
{
    private List<Person> People = new List<Person>();

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public Person GetOldestMember()
    {
        People = People.OrderByDescending(x => x.Age).ToList();
        return People.First();
    }
}

