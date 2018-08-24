using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            ///You will receive how much damage these attacks do from the console.
            //Gosho attacks with “Thunderous fist” on every even turn
            //Pesho attacks with “Roundhouse kick” on every odd turn.

            int PeshoDamage = int.Parse(Console.ReadLine());
            int GoshoDamage = int.Parse(Console.ReadLine());

            //Both players start with 100 Health points. 
            //On every third turn Pesho and Gosho restore 10 Health Points
            //Health points are restored after the attack is made.
            int GoshoHealth = 100;
            int PeshoHealth = 100;
            int counter = 0;

            while (true)
            {
                counter++;
                if (counter % 2 == 0)
                {

                    PeshoHealth -= GoshoDamage;

                    if (PeshoHealth <= 0)
                    {
                        Console.WriteLine($"Gosho won in {counter}th round.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {PeshoHealth} health.");

                    }

                }
                else
                {
                    GoshoHealth -= PeshoDamage;

                    if (GoshoHealth <= 0)
                    {
                        Console.WriteLine($"Pesho won in {counter}th round.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {GoshoHealth} health.");

                    }

                }
                
                if (counter % 3 == 0)
                {
                    GoshoHealth += 10;
                    PeshoHealth += 10;
                }
            }
        }
    }
}
