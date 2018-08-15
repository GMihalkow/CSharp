using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Siamese
{
    private string catname;
    private string catbreed;
    private decimal earsize;

    public string CatName { get { return this.catname; } set { this.catname = value; } }
    public string CatBreed { get { return this.catbreed; } set { this.catbreed = value; } }
    public decimal EarSize { get { return this.earsize; } set { this.earsize = value; } }

    public Siamese(string name, string breed, decimal ear)
    {
        this.catname = name;
        this.catbreed = breed;
        this.earsize = ear;
    }
}

