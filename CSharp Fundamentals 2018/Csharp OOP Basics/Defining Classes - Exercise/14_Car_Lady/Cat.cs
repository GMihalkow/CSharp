using System;
using System.Collections.Generic;
using System.Text;

public class Cat
{
    private List<Siamese> siameses = new List<Siamese>();
    private List<Cymric> cymrics = new List<Cymric>();
    private List<Street_Extraordinaire> streetcats = new List<Street_Extraordinaire>();

    public List<Siamese> Siameses { get { return this.siameses; } set { this.siameses = value; } }
    public List<Cymric> Cymrics { get { return this.cymrics; } set { this.cymrics = value; } }
    public List<Street_Extraordinaire> StreetCats { get { return this.streetcats; } set { this.streetcats = value; } }

    public void AddSiamese(Siamese siamese)
    {
        siameses.Add(siamese);
    }

    public void AddCymric(Cymric cymric)
    {
        cymrics.Add(cymric);
    }

    public void AddStreetCat(Street_Extraordinaire streetcat)
    {
        streetcats.Add(streetcat);
    }

}

