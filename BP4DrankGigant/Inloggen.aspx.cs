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

namespace BP4DrankGigant
{
    public partial class Inloggen : System.Web.UI.Page
    {
        Account a;
        Helper h = new Helper();
        List<Account> accounts = new List<Account>();
        string gebruikersnaam;
        string wachtwoord;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Alle accounts uit de database ophalen. Hierdoor is het later niet mogelijk om SQL-injections te doen.
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
                    com.CommandText = "SELECT * FROM Account";
                    DbDataReader reader = com.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            a = new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                            accounts.Add(a);
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                    catch
                    {
                        return "-1";
                    }
                }
        }

        protected void btnAccountMaken_Click(object sender, EventArgs e)
        {
            //Kijken of alle velden naar behoren ingevuld zijn.
            Page.Validate("AllValidators");
            if (Page.IsValid)
            { 
                a.Aanmaken(tbEmail.Text, ddlTitel.SelectedValue, tbVoornaam.Text, tbAchternaam.Text, "NL1324576809", tbWachtwoord.Text, tbReWachtwoord.Text, rbNieuwsbrief.SelectedValue);
                Session["Inlog"] = "Y";
                Response.Redirect("Hoofdpagina.aspx");
            }
            //Als de velden niet goed ingevuld zijn, laat een tekst zien.
            else
            {
                lblError.Text = "Sommige velden zijn niet correct ingevuld.";
                lblError.ForeColor = System.Drawing.Color.Red;    
            }
        }

        protected void btnInloggen_Click(object sender, EventArgs e)
        {
            //Het is hier niet mogelijk om SQL-injections te krijgen, omdat ik de list vergelijk met het ingevulde.
            //Roep de methode van de klasse Account aan ipv dit.
            gebruikersnaam = tbInlogEmail.Text;
            wachtwoord = tbInlogWachtwoord.Text;
            foreach (Account a in accounts)
            {
                if(a.Email == gebruikersnaam && a.Wachtwoord == wachtwoord)
                {
                    //Sessie om de username te onthouden en om te onthouden of er ingelogd is.
                    Session["Username"] = gebruikersnaam;
                    Session["Inlog"] = "Y";
                    //MessageBox
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('U bent ingelogd.');</script>");
                    //Na het inloggen komt men altijd terug op de hoofdpagina.
                    Response.Redirect("Hoofdpagina.aspx");
                }
                else
                {
                    //Pop-up als het email adres niet overeenkomt met het wachtwoord.
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Verkeerde email/wachtwoord. Probeer het opnieuw.');</script>");
                    tbInlogEmail.Text = "";
                    tbInlogWachtwoord.Text = "";
                }
            }
        }
    }
}