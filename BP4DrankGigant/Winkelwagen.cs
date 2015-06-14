using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Winkelwagen
    {
        public List<Product> winkelwagenproducten { get; set; }

        List<Product> winkelwagenlijst;

        public Winkelwagen()
        {

        }

        public void ToevoegenAanWinkelwagen(Product p)
        {
            winkelwagenproducten = new List<Product>();
            winkelwagenproducten.Add(p);
        }
    }
}