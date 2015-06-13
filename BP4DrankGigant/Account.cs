using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP4DrankGigant
{
    public class Account
    {
        public String Email { get; set; }
        public String Titel { get; set; }
        public String Voornaam { get; set; }
        public String Achternaam { get; set; }
        public String Btwnummer { get; set; }
        public String Wachtwoord { get; set; }
        public String Nieuwsbrief { get; set; }
      //Delete uit klassendiagram  public String NieuwWachtworod { get; set; }

        public Account(string email, string titel, string voornaam, string achternaam, string btwnummer, string wachtwoord, string nieuwsbrief)
        {
            this.Email = email;
            this.Titel = titel;
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Btwnummer = btwnummer;
            this.Wachtwoord = wachtwoord;
            this.Nieuwsbrief = nieuwsbrief;
        }

        public void VeranderWachtwoord(string wachtwoord, string nieuwwachtwoord)
        {
            if(wachtwoord == this.Wachtwoord)
            {
                this.Wachtwoord = nieuwwachtwoord;
            }
        }
        public void Inloggen(string email, string wachttwoord)
        {

        }
        public void Uitloggen(string email)
        {
            
        }
    }
}