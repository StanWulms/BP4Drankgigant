using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Categorie
    {
        public String Naam { get; set; }
        public String SubNaam { get; set; }
        public List<Categorie> categorieen { get; set; }

        List<SubCategoriee> subcategorieen;
        SubCategoriee sc;

        public Categorie()
        {

        }
        public Categorie(string naam)
        {
            this.Naam = naam;
            
        }

        public Categorie(string naam, string subnaam)
        {
            this.Naam = naam;
            this.SubNaam = subnaam;
        }

        public void AddSubCat(string naam)
        {
            sc = new SubCategoriee();
            subcategorieen.Add(sc);
        }
    }
}