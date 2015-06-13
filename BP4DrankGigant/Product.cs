using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Product
    {
        public String Naam { get; set; }
        public int Inhoud { get; set; }
        public int Alcoholpercentage { get; set; }
        public String Merk { get; set; }
        public String Land { get; set; }
        public int Prijs { get; set; }

        List<Categorie> categorieen;
        List<SubCategorie> subcategorieen;

        public Product(string naam,int inhoud, int alcoholpercentage, string merk, string land, int prijs)
        {

        }
        public void Zoeken(string naam)
        {
            
        }
    }
}