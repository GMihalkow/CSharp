using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Street_Extraordinaire
{
    private string catname;
    private string catbreed;
    private decimal meow;

    public string CatName { get { return this.catname; } set { this.catname = value; } }
    public string CatBreed { get { return this.catbreed; } set { this.catbreed = value; } }
    public decimal Meowing { get { return this.meow; } set { this.meow = value; } }

    public Street_Extraordinaire(string name, string breed, decimal meow)
    {
        this.catname = name;
        this.catbreed = breed;
        this.meow = meow;
    }
}

