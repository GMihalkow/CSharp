using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        Assembler assembler = new Assembler();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] Information =
                input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string name = Information[0];
            string type = Information[1];

            //Company information
            string companyName = null;
            string department = null;
            decimal salary = 0;

            //Pokemon information
            string pokemonName = null;
            string pokemonType = null;

            //Parents information
            string parentName = null;
            string parentBirthday = null;

            //Children information
            string childName = null;
            string childBirthday = null;

            //Car information
            string carModel = null;
            int carSpeed = 0;

            switch (type)
            {
                case "pokemon":
                    {
                        pokemonName = Information[2];
                        pokemonType = Information[3];
                        Pokemon pokemon = new Pokemon(name, pokemonName, pokemonType);
                        person = new Person(name, pokemon);
                        assembler.AddPokemon(name, pokemon);
                    }
                    break;
                case "parents":
                    {
                        parentName = Information[2];
                        parentBirthday = Information[3];
                        Parent parent = new Parent(name, parentName, parentBirthday);
                        person = new Person(name, parent);
                        assembler.AddParent(name, parent);
                    }
                    break;
                case "company":
                    {
                        companyName = Information[2];
                        department = Information[3];
                        salary = decimal.Parse(Information[4]);
                        Company company = new Company(name, companyName, department, salary);
                        person = new Person(name, company);
                        assembler.AddCompany(name, company);
                    }
                    break;
                case "car":
                    {
                        carModel = Information[2];
                        carSpeed = int.Parse(Information[3]);
                        Car car = new Car(name, carModel, carSpeed);
                        person = new Person(name, car);
                        assembler.AddCar(name, car);
                    }
                    break;
                case "children":
                    {
                        childName = Information[2];
                        childBirthday = Information[3];
                        Child child = new Child(name, childName, childBirthday);
                        person = new Person(name, child);
                        assembler.AddChild(name, child);
                    }
                    break;
            }

            assembler.AddPeople(name, person);
        }

        string personName = Console.ReadLine();
        assembler.PrintingPerson(personName);
    }
}

