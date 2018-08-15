using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Cat cats = new Cat();

        string cat;
        while ((cat = Console.ReadLine()) != "End")
        {
            string[] CatInfo =
                cat
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string catBreed = CatInfo[0];
            string catName = CatInfo[1];
            decimal catLastParameter = decimal.Parse(CatInfo[2]);

            switch (catBreed)
            {
                case "Siamese":
                    {
                        Siamese siamese = new Siamese(catName, catBreed, catLastParameter);
                        cats.AddSiamese(siamese);
                    }
                    break;
                case "Cymric":
                    {
                        Cymric Cymric = new Cymric(catName, catBreed, catLastParameter);
                        cats.AddCymric(Cymric);
                    }
                    break;
                case "StreetExtraordinaire":
                    {
                        Street_Extraordinaire streetCat = new Street_Extraordinaire(catName, catBreed, catLastParameter);
                        cats.AddStreetCat(streetCat);
                    }
                    break;
            }


        }
        CatPrinter printer = new CatPrinter(cats);
        string bestCat = Console.ReadLine();
        Console.WriteLine(printer.PrintCat(bestCat, cats));

    }
}

