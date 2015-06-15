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

using System.Web.UI.HtmlControls;

namespace BP4DrankGigant
{
    public partial class ProductInformatieaspx : System.Web.UI.Page
    {
        Helper h = new Helper();
        Product p;

        protected void Page_Load(object sender, EventArgs e)
        {
            string product = (string)Session["Product"];
            p = new Product();
            //De informatie over het product opvragen. Dit kan doordat de sessie doorgegevn wordt.
            p.getProductInfo();
            //De afbeelding van het product.
            ImageButton img = new ImageButton();
            img.ID = "img";
            img.AlternateText = "ImageButton";
            img.ImageUrl = "~/Images/" + product + ".jpg";
            Panel1.Controls.Add(img);

            foreach (Product pr in p.producteninfo)
            {
                Label labelNaam = new Label();
                labelNaam.Text = "<br /> " + "Naam: " + pr.Naam + "<br /><br />";
                labelNaam.ID = p.Naam + ".";
                Panel1.Controls.Add(labelNaam);

                Label labelInhoud = new Label();
                labelInhoud.Text = "Inhoud: " + pr.Inhoud + "<br /><br />";
                labelInhoud.ID = p.Inhoud;
                Panel1.Controls.Add(labelInhoud);

                Label labelAlcoholpercentage = new Label();
                labelAlcoholpercentage.Text = "Alcohol Percentage: " + pr.Alcoholpercentage + "<br /><br />";
                labelAlcoholpercentage.ID = p.Alcoholpercentage;
                Panel1.Controls.Add(labelAlcoholpercentage);

                Label labelMerk = new Label();
                labelMerk.Text = "Merk: " + pr.Merk + "<br /><br />";
                labelMerk.ID = p.Merk;
                Panel1.Controls.Add(labelMerk);

                Label labelLand = new Label();
                labelLand.Text = "Land: " + pr.Land + "<br /><br />";
                labelLand.ID = p.Land;
                Panel1.Controls.Add(labelLand);

                Label labelPrijs = new Label();
                labelPrijs.Text = "Prijs: €" + pr.Prijs + "<br /><br />";
                labelPrijs.ID = p.Prijs.ToString();
                Panel1.Controls.Add(labelPrijs);
            }
            //Clickable afbeelding om het geselecteerde product in de winkelwagen te zetten. 
            ImageButton WinkelWagenIMG = new ImageButton();
            WinkelWagenIMG.ID = "WinkelWagenIMG";
            WinkelWagenIMG.AlternateText = "ImagButton";
            WinkelWagenIMG.ImageUrl = "~/Images/WinkelWagen.jpg";
            WinkelWagenIMG.Click += new ImageClickEventHandler(WinkelWagenIMG_Click);
            Panel1.Controls.Add(WinkelWagenIMG);  
        }
   
        protected void WinkelWagenIMG_Click(object sender, ImageClickEventArgs e)
        {
            //Code als er op de winkelwagen afbeelding geklikt wordt.
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
                com.CommandText = "SELECT * FROM LIJST";
                OracleCommand cmd = (OracleCommand)con.CreateCommand();
                try
                {
                    //Alleen als er ingelogd is, kan er een winkelwagen gezien worden.
                    if((String)Session["Inlog"] == "Y")
                    {
                        //Selecteer de juiste lijst en Insert daarin het product.
                        string lijstID = h.getLijstID("SELECT * FROM LIJST WHERE email ='" + Session["Username"] + "' AND lijsttype = 'Winkelwagen'");
                        Session["Lijst"] = lijstID;
                        OracleTransaction otn = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.CommandText = "INSERT INTO PRODUCTLIJST (productnaam, lijstID, aantal) VALUES ('" + (String)Session["Product"] + "','" + (String)Session["Lijst"] + "','" + "1" + "')";
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        //Als er een excpetion van Oracle komt, als er twee dezelfde unique keys ingevoerd worden, wordt er naar de hoofdpagina verwezen en gebeurt er verder niets.
                        catch (OracleException ex)
                        {
                            if (ex.Message.Contains("UniqueConstraint"))
                            {
                                Response.Redirect("Hoofdpagina.aspx");
                            }
                        }
                        otn.Commit();
                    }
                    else
                    {

                    }
                }
                catch (NullReferenceException)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('U dient eerst in te loggen.');</script>");
                }
                catch(DuplicateNameException)
                {
                    OracleTransaction otn = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmd.CommandText = "INSERT INTO LIJST (LijstID, Email, lijsttype) VALUES ('" + (1+1).ToString() + "','" + (String)Session["Username"] + "','" + "Winkelwagen" + "')";
                    cmd.ExecuteNonQuery();
                    otn.Commit();
                }
            }
            Response.Redirect("WinkelWagen.aspx");
        }
    }
}