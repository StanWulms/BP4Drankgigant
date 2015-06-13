using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Helper
    {
        List<Categorie> categorien;
        Categorie c;
        public Helper()
        {

        }

        public void addCategorie(string naam)
        {
            c= new Categorie(naam);
            categorien.Add(c);
        }
    }
}