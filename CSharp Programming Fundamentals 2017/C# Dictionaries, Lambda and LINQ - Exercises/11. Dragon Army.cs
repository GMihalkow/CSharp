using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEXERCISES
{
    class Program
    {
        static void Main(string[] args)
        {
            //You need to categorize dragons by their type.
            //For each dragon, identified by name, keep information about his stats.
            //Type is preserved as in the order of input,
            //but dragons are sorted alphabetically by name.
            //For each type, you should also prdecimal the average damage,
            //health and armor of the dragons.
            //For each dragon, prdecimal his own stats. 

            //Default values are as follows:
            //health 250, damage 45, and armor 10.
            //Missing stat will be marked by null.

            //The input is in the following format:
            //{type} {name} {damage} {health} {armor}

            //If the same dragon is added a second time,
            //the new stats should overwrite the previous ones.
            //Two dragons are considered equal if they match by both name and type.


            decimal DefaultHealth = 250;
            decimal DefaultDamage = 45;
            decimal DefaultArmor = 10;

            decimal Damage = 0;
            decimal Health = 0;
            decimal Armor = 0;

            Dictionary<string, Dictionary<string, List<decimal>>> DragonsAndStats = new Dictionary<string, Dictionary<string, List<decimal>>>();

            decimal lines = decimal.Parse(Console.ReadLine());
            for (decimal i = 0; i < lines; i++)
            {
                string[] input =
                    Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Length == 5)//{type} {name} {damage} {health} {armor}
                {
                    string DragonType = input[0];
                    string DragonName = input[1];
                    if (input[2] == "null")
                    {
                        Damage = DefaultDamage;

                    }
                    else
                    {
                        Damage = decimal.Parse(input[2]);
                    }
                    if (input[3] == "null")
                    {
                        Health = DefaultHealth;

                    }
                    else
                    {
                        Health = decimal.Parse(input[3]);
                    }
                    if (input[4] == "null")
                    {
                        Armor = DefaultArmor;
                    }
                    else
                    {
                        Armor = decimal.Parse(input[4]);
                    }
                    if (DragonsAndStats.ContainsKey(DragonType))
                    {

                    }
                    if (!(DragonsAndStats.ContainsKey(DragonType)))
                    {
                        DragonsAndStats.Add(DragonType, new Dictionary<string, List<decimal>>());
                    }
                    if (DragonsAndStats[DragonType].ContainsKey(DragonName))
                    {
                        DragonsAndStats[DragonType][DragonName].Clear();
                        DragonsAndStats[DragonType][DragonName].Add(Damage);
                        DragonsAndStats[DragonType][DragonName].Add(Health);
                        DragonsAndStats[DragonType][DragonName].Add(Armor);

                    }
                    if (!(DragonsAndStats[DragonType].ContainsKey(DragonName)))
                    {
                        DragonsAndStats[DragonType].Add(DragonName, new List<decimal>());
                        DragonsAndStats[DragonType][DragonName].Add(Damage);
                        DragonsAndStats[DragonType][DragonName].Add(Health);
                        DragonsAndStats[DragonType][DragonName].Add(Armor);
                    }

                }//{type} {name} {damage} {health} {armor}
            }

            decimal AverageDamage = 0;
            decimal AverageHealth = 0;
            decimal AverageArmor = 0;
            decimal counter = 0;

            // If the same dragon is added a second time,
            //the new stats should overwrite the previous ones.

            foreach (var type in DragonsAndStats)
            { 
                foreach (var a in type.Value)
                {
                    counter++;
                    AverageDamage += a.Value[0];
                    AverageHealth += a.Value[1];
                    AverageArmor += a.Value[2];
                }
                Console.WriteLine($"{type.Key}::({AverageDamage / counter:f2}/{AverageHealth / counter:f2}/{AverageArmor / counter:f2})");
                foreach (var name in type.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value[0]}, health: {name.Value[1]}, armor: {name.Value[2]}");

                }
                counter = 0;
                AverageDamage = 0;
                AverageHealth = 0;
                AverageArmor = 0;
            }
        }
    }
}
