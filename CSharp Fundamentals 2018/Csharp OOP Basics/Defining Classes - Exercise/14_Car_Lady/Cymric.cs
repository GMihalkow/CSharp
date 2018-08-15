using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Cymric : ICat
{
    private string catname;
    private string catbreed;
    private decimal furlength;

    public string CatName { get { return this.catname; } set { this.catname = value; } }
    public string CatBreed { get { return this.catbreed; } set { this.catbreed = value; } }
    public decimal FurLength { get { return this.furlength; } set { this.furlength = value; } }

    public Cymric(string name, string breed, decimal fur)
    {
        this.catname = name;
        this.catbreed = breed;
        this.furlength = fur;
    }

}