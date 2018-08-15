using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class CatPrinter
{
    private Cat allcats = new Cat();
    public Cat AllCats { get { return this.allcats; } set { this.allcats = value; } }

    public CatPrinter(Cat cat)
    {
        this.allcats = cat;
    }

    public string PrintCat(string name, Cat allCats)
    {
        foreach (var cymric in allCats.Cymrics)
        {
            if (cymric.CatName == name)
            {
                return ($"{cymric.CatBreed} {cymric.CatName} {cymric.FurLength:f2}").ToString();
            }
        }
        //Siameses
        foreach (var siamese in allCats.Siameses)
        {
            if (siamese.CatName == name)
            {
                return ($"{siamese.CatBreed} {siamese.CatName} {siamese.EarSize}").ToString();
            }
        }
        //StreetCats
        foreach (var streetcat in allCats.StreetCats)
        {
            if (streetcat.CatName == name)
            {
                return ($"{streetcat.CatBreed} {streetcat.CatName} {streetcat.Meowing}").ToString();

            }
        }
        return ("no cat found").ToString();
    }
}

