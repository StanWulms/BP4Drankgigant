using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Product
    {
        public String Naam { get; set; }
        public String Inhoud { get; set; }
        public String Alcoholpercentage { get; set; }
        public String Merk { get; set; }
        public String Land { get; set; }
        public int Prijs { get; set; }

        List<Categorie> categorieen;
        List<SubCategorie> subcategorieen;
        List<Product> winkelwagenlijst;

        public Product(string naam,String inhoud, String alcoholpercentage, string merk, string land, int prijs)
        {
            this.Naam = naam;
            this.Inhoud = inhoud;
            this.Alcoholpercentage = alcoholpercentage;
            this.Merk = merk;
            this.Land = land;
            this.Prijs = prijs;
        }
        public void Zoeken(string naam)
        {
            
        }


    }
}