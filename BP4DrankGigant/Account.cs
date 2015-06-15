using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess;

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

        public List<Account> accounts { get; set; }

        Helper h = new Helper();

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
        public void Inloggen(string email, string wachtwoord)
        {

        }
        public void Uitloggen(string email)
        {
            
        }

        public void Aanmaken(string email, string titel, string voornaam, string achternaam, string btwnummer, string wachtwoord, string rewachtwoord, string nieuwsbrief)
        {
            if (wachtwoord == rewachtwoord)
            {
                int maxid;
                using (DbConnection con = OracleClientFactory.Instance.CreateConnection())
                {
                    if (con == null)
                    {
                        //return "Error! No Connection";
                    }
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectieStr"].ConnectionString;
                    con.Open();
                    DbCommand com = OracleClientFactory.Instance.CreateCommand();
                    if (com == null)
                    {
                        //return "Error! No Command";
                    }
                    com.Connection = con;
                    OracleCommand cmd = (OracleCommand)con.CreateCommand();
                    try
                    {
                        cmd.Parameters.Add("email", email);
                        cmd.Parameters.Add("titel", titel);
                        cmd.Parameters.Add("voornaam",voornaam);
                        cmd.Parameters.Add("achternaam",achternaam);
                        cmd.Parameters.Add("btwnummer",btwnummer);
                        cmd.Parameters.Add("wachtwoord",wachtwoord);
                        cmd.Parameters.Add("nieuwsbrief",nieuwsbrief);
                        OracleTransaction otn = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                          cmd.CommandText = "INSERT INTO ACCOUNT (Email,Titel,Voornaam,Achternaam,Btwnummer,Wachtwoord,Nieuwsbrief) VALUES ('" + @email + "','" + @titel + "','" + @voornaam + "','" + @achternaam + "','" + @btwnummer + "','" + @wachtwoord + "','" + @nieuwsbrief + "')";
                        cmd.ExecuteNonQuery();
                        otn.Commit();

                        maxid = h.getMaXID("SELECT COUNT(LijstID) FROM LIJST");
                        OracleTransaction otn2 = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.CommandText = "INSERT INTO LIJST (LijstID, Email, lijsttype) VALUES ('" + maxid.ToString() + "','" + @email + "','" + "Winkelwagen" + "')";
                        cmd.ExecuteNonQuery();
                        otn2.Commit();
                    }
                    catch (NullReferenceException)
                    {

                    }
                    catch
                    {
                       
                    }
                } 
            }
            else
            {
                
            }
        }
    }
}