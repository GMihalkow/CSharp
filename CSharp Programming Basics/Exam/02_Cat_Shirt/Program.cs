using System;

namespace _02_Cat_Shirt
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideLength = double.Parse(Console.ReadLine());
            double frontLength = double.Parse(Console.ReadLine());
            double materialCost;
            double tieCost;

            string material = Console.ReadLine();
            switch (material)
            {
                case "Linen": materialCost = 15; break;
                case "Cotton": materialCost = 12; break;
                case "Denim": materialCost = 20; break;
                case "Twill": materialCost = 16; break;
                case "Flannel": materialCost = 11; break;
                default: materialCost = 0.0; break;
            }

            string tie = Console.ReadLine();
            switch (tie)
            {
                case "Yes":tieCost = 1.20; break;
                default: tieCost = 1.00;break;
            }

            double totalShirtLength = ((sideLength * 2) + (frontLength * 2)) * 1.10;
            double lengthInMeters = totalShirtLength / 100;

            double shirtCost = (lengthInMeters * materialCost) + 10;

            double totalShirtCost = shirtCost * tieCost;

            Console.WriteLine($"The price of the shirt is: {totalShirtCost:f2}lv.");
        }
    }
}
