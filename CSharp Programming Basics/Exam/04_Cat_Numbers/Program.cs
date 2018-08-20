using System;

namespace _04_Cat_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string egn = string.Empty;

            int catsCount = int.Parse(Console.ReadLine());
            for (int index = 1; index <= catsCount; index++)
            {
                string catFirstName = Console.ReadLine();
                string catLastName = Console.ReadLine();
                int lastTwoDigitsFromBirthYear = int.Parse(Console.ReadLine());
                egn += lastTwoDigitsFromBirthYear.ToString();
                egn += (int)catFirstName[0];
                egn += (int)catLastName[0];
                egn += index.ToString();
                Console.WriteLine(egn);
                egn = string.Empty;
            }
        }
    }
}
