using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double catBedPrice = double.Parse(Console.ReadLine());
            double toiletPricePerMonth = double.Parse(Console.ReadLine());

            double monthlyCatFoodPrice = toiletPricePerMonth * 1.25;
            double catToysPrice = monthlyCatFoodPrice * 0.50;
            double vetPrice = catToysPrice * 1.10;

            double paymentsPerMonth = (toiletPricePerMonth + monthlyCatFoodPrice + vetPrice + catToysPrice);

            double totalCost = catBedPrice + (12 * paymentsPerMonth) + 12 * (paymentsPerMonth * 0.05);

            Console.WriteLine($"{totalCost:F2} lv.");


        }
    }
}
