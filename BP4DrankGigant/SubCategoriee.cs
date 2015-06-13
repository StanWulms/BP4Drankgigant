using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class SubCategoriee
    {
        List<Categorie> categorieen;
        public String Categorie { get; set; }

        public SubCategoriee()
        {

        }

        public SubCategoriee(string categorie)
        {
            this.Categorie = categorie;
        }
    }
}