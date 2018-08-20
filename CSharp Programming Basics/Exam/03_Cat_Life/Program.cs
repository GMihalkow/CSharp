using System;

namespace _03_Cat_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectedCatLifeLength;
            string catBreed = Console.ReadLine();
            char catSex = char.Parse(Console.ReadLine());
            if (catSex == 'm')
            {
                switch (catBreed)
                {
                    case "British Shorthair": expectedCatLifeLength = 13; break;
                    case "Siamese": expectedCatLifeLength = 15; break;
                    case "Persian": expectedCatLifeLength = 14; break;
                    case "Ragdoll": expectedCatLifeLength = 16; break;
                    case "American Shorthair": expectedCatLifeLength = 12; break;
                    case "Siberian": expectedCatLifeLength = 11; break;
                    default: expectedCatLifeLength = 0; break;
                }
            }
            else
            {
                switch (catBreed)
                {
                    case "British Shorthair": expectedCatLifeLength = 14; break;
                    case "Siamese": expectedCatLifeLength = 16; break;
                    case "Persian": expectedCatLifeLength = 15; break;
                    case "Ragdoll": expectedCatLifeLength = 17; break;
                    case "American Shorthair": expectedCatLifeLength = 13; break;
                    case "Siberian": expectedCatLifeLength = 12; break;
                    default: expectedCatLifeLength = 0;break;
                }
            }

            if (expectedCatLifeLength == 0)
            {
                Console.WriteLine($"{catBreed} is invalid cat!");
            }
            else
            {
                int humanMonthsExpected = expectedCatLifeLength * 12;
                int humanToCatMonths = humanMonthsExpected / 6;
                Console.WriteLine($"{humanToCatMonths} cat months");
            }
        }
    }
}
