using System;

namespace _06_Cat_Shelter
{
    class Program
    {
        static void Main(string[] args)
        {
            int catFood = int.Parse(Console.ReadLine());

            int catFoodInKgs = catFood * 1000;

            int eatenFood = 0;


            string stopWord = string.Empty;
            while ((stopWord = Console.ReadLine()) != "Adopted")
            {
                int catMeal = int.Parse(stopWord);
                eatenFood += catMeal;
            }

            if (eatenFood <= catFoodInKgs)
            {
                Console.WriteLine($"Food is enough! Leftovers: {catFoodInKgs - eatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {eatenFood - catFoodInKgs} grams more.");
            }
        }
    }
}
