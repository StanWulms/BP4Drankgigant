using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Bestelling
    {
        public Account Account { get; set; }
        public int Winkelwagen { get; set; }

        public Bestelling(Account account, int winkelwagen)
        {
            this.Account = account;
            this.Winkelwagen = winkelwagen;
        }
        public void Afrekenen(Account account, int winkelwagen)
        {

        }
    }
}