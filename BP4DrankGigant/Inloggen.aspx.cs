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
        List<Account> accounts = new List<Account>();
        string gebruikersnaam;
        string wachtwoord;
        
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    //dropdownmenu
                    // lbItems.Items.Clear();

                    while (reader.Read())
                    {
                        a = new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                        accounts.Add(a);

                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }

        protected void btnAccountMaken_Click(object sender, EventArgs e)
        {
            if (tbWachtwoord.Text == tbReWachtwoord.Text)
            {
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
                    OracleCommand cmd = (OracleCommand)con.CreateCommand();
                    try
                    {
                        OracleTransaction otn = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.CommandText = "INSERT INTO ACCOUNT (Email,Titel,Voornaam,Achternaam,Btwnummer,Wachtwoord,Nieuwsbrief) VALUES ('" + tbEmail.Text + "','" + ddlTitel.SelectedValue + "','" + tbVoornaam.Text + "','" + tbAchternaam.Text + "','" + "NL12349921" + "','" + tbWachtwoord.Text + "','" + rbNieuwsbrief.SelectedValue + "')";
                        cmd.ExecuteNonQuery();
                        otn.Commit();
                        //dropdownmenu
                        // lbItems.Items.Clear();


                    }
                    catch (NullReferenceException)
                    {

                    }
                }
                Response.Redirect("Hoofdpagina.aspx");
            }
        }

        protected void btnInloggen_Click(object sender, EventArgs e)
        {
            //Roep de methode van de klasse Account aan ipv dit.
            gebruikersnaam = tbInlogEmail.Text;
            wachtwoord = tbInlogWachtwoord.Text;
            foreach (Account a in accounts)
            {
                if(a.Email == gebruikersnaam && a.Wachtwoord == wachtwoord)
                {
                    Session["Username"] = gebruikersnaam;
                    Session["Password"] = wachtwoord;
                    Session["Inlog"] = "Y";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('U bent ingelogd.');</script>");
                    Response.Redirect("Hoofdpagina.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Verkeerde email/wachtwoord. Probeer het opnieuw.');</script>");
                    tbInlogEmail.Text = "";
                    tbInlogWachtwoord.Text = "";
                }
            }
        }
    }
}