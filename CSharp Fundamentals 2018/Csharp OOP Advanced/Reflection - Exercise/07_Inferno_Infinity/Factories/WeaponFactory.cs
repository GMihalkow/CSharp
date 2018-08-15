using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class WeaponFactory
{
    public void Create(List<Weapon> weaponsList, string[] arguments)
    {
        string wepRarity =
            arguments[1]
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
        string wepType =
            arguments[1]
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];

        var Rarity = (Rarity)Enum.Parse(typeof(Rarity), wepRarity);

        Type type = Type.GetType(wepType);

        Weapon weaponType = (Weapon)Activator.CreateInstance(Type.GetType(wepType), new object[] { arguments[2], 0, 0, 0 });

        weaponType.RarityType = (int)Rarity;
        weaponType.RarityEffect();
        weaponsList.Add(weaponType);
    }

    public void Add(List<Weapon> weaponList, string[] arguments)
    {
        string wepName = arguments[1];

        int socketIndex = int.Parse(arguments[2]);

        string clarityType =
            arguments[3]
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];

        string gemType =
            arguments[3]
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];

        Type realGemType = Type.GetType(gemType);
        Gem gem = (Gem)Activator.CreateInstance(Type.GetType(gemType));

        GemsClarity clarity = (GemsClarity)Enum.Parse(typeof(GemsClarity), clarityType);

        MethodInfo neededClarityField = realGemType.GetMethod("set_Clarity", (BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance));

        neededClarityField.Invoke(gem, new object[] { (int)clarity });

        bool DoesWeaponExist = weaponList.Any(w => w.Name == wepName);
        if (DoesWeaponExist == true)
        {
            Weapon neededWep = weaponList.First(w => w.Name == wepName);

            if (socketIndex < 0 || socketIndex > neededWep.Gems.Length - 1)
            {
            }
            else
            {
                if (neededWep.Gems[socketIndex] != null)
                {
                    Gem oldGem = neededWep.Gems[socketIndex];
                    neededWep.OverwriteGem(oldGem, gem, socketIndex);
                }
                else
                {
                    neededWep.AddGem(gem, socketIndex);
                }
            }
        }
    }

    public void Remove(List<Weapon> weaponList, string[] arguments)
    {
        string wepName = arguments[1];
        int socketIndex = int.Parse(arguments[2]);

        if ((weaponList.Any(w => w.Name == wepName)) == true)
        {
            Weapon weapon = weaponList.First(w => w.Name == wepName);
            if (socketIndex >= 0 && socketIndex <= weapon.Gems.Length - 1)
            {

                Gem oldGem = weapon.Gems[socketIndex];

                if (weapon.Gems[socketIndex] == null)
                {

                }
                else
                {
                    weapon.RemoveGem(socketIndex, oldGem);
                }
            }
        }
    }

    public void Print(List<Weapon> weaponList, string[] arguments)
    {
        //Print weapons in the given format:
        //"{weapon's name}: {min damage}-{max damage} Damage, +{points} Strength, +{points} Agility, +{points} Vitality"

        string wepname = arguments[1];
        if ((weaponList.Any(w => w.Name == wepname)) == true)
        {
            Weapon weapon = weaponList.First(w => w.Name == wepname);
            Type wepType = Type.GetType(weapon.GetType().Name);
            //var wepInstance = Activator.CreateInstance(wepType);

            PropertyInfo strength = wepType.GetProperty("Strength");
            PropertyInfo agility = wepType.GetProperty("Agility");
            PropertyInfo vitality = wepType.GetProperty("Vitality");

            Console.WriteLine($"{weapon.Name}: {weapon.MinDamage + (weapon.Strength * 2) + (weapon.Agility)}-{weapon.MaxDamage + (weapon.Strength * 3) + (weapon.Agility* 4)} Damage, +{weapon.Strength} Strength, +{weapon.Agility} Agility, +{weapon.Vitality} Vitality");
        }

    }
}