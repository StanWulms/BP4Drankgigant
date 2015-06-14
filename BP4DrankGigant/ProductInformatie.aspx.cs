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
        List<Product> winkellijst;
        Product p;
        Winkelwagen ww;
        protected void Page_Load(object sender, EventArgs e)
        {
            string product = (string)Session["Product"];
            p = new Product();
            p.getProductInfo();

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
           
            ImageButton WinkelWagenIMG = new ImageButton();
            WinkelWagenIMG.ID = "WinkelWagenIMG";
            WinkelWagenIMG.AlternateText = "ImagButton";
            WinkelWagenIMG.ImageUrl = "~/Images/WinkelWagen.jpg";
            WinkelWagenIMG.Click += new ImageClickEventHandler(WinkelWagenIMG_Click);
            Panel1.Controls.Add(WinkelWagenIMG); 

            /*using (DbConnection con = OracleClientFactory.Instance.CreateConnection())
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
                com.CommandText = "SELECT Productnaam, categorieID, soortID, inhoud, alcoholpercentage, merk, land, prijs FROM Product WHERE productnaam = '" + product + "'";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    //dropdownmenu
                    // lbItems.Items.Clear();
                    ImageButton img = new ImageButton();

                    img.ID = "img";

                    img.AlternateText = "ImageButton";
                    img.ImageUrl = "~/Images/" + product + ".jpg";
                    Panel1.Controls.Add(img);
 
                    while (reader.Read())
                    {


                        Label labelNaam = new Label();
                        labelNaam.Text = "<br /> " + "Naam: " + reader[0].ToString() + "<br /><br />";
                        labelNaam.ID = reader[0].ToString() + ".";
                        Panel1.Controls.Add(labelNaam);

                        Label labelInhoud = new Label();
                        labelInhoud.Text = "Inhoud: " + reader[3].ToString() + "<br /><br />";
                        labelInhoud.ID = reader[3].ToString();
                        Panel1.Controls.Add(labelInhoud);

                        Label labelAlcoholpercentage = new Label();
                        labelAlcoholpercentage.Text = "Alcohol Percentage: " + reader[4].ToString() + "<br /><br />";
                        labelAlcoholpercentage.ID = reader[4].ToString();
                        Panel1.Controls.Add(labelAlcoholpercentage);

                        Label labelMerk = new Label();
                        labelMerk.Text = "Merk: " + reader[5].ToString() + "<br /><br />";
                        labelMerk.ID = reader[5].ToString();
                        Panel1.Controls.Add(labelMerk);

                        Label labelLand = new Label();
                        labelLand.Text = "Land: " + reader[6].ToString() + "<br /><br />";
                        labelLand.ID = reader[6].ToString();
                        Panel1.Controls.Add(labelLand);

                        Label labelPrijs = new Label();
                        labelPrijs.Text = "Prijs: €" + reader[7].ToString() + "<br /><br />";
                        labelPrijs.ID = reader[7].ToString();
                        Panel1.Controls.Add(labelPrijs);

                        Product p = new Product(reader[0].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader.GetInt32(7));
                       
                    }

                    
                    ImageButton WinkelWagenIMG = new ImageButton();

                    WinkelWagenIMG.ID = "WinkelWagenIMG";

                    WinkelWagenIMG.AlternateText = "ImagButton";
                    WinkelWagenIMG.ImageUrl = "~/Images/WinkelWagen.jpg";
                    WinkelWagenIMG.Click += new ImageClickEventHandler(WinkelWagenIMG_Click);
                    Panel1.Controls.Add(WinkelWagenIMG); 
                }
                catch (NullReferenceException)
                {

                }
            }*/
        }
    /*    public void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + button.ID + "');</script>");
            Session["ProductInfo"] = button.ID;
            Response.Redirect("ProductInformatie.aspx");
        }*/
        protected void WinkelWagenIMG_Click(object sender, ImageClickEventArgs e)
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
                com.CommandText = "SELECT * FROM LIJST";
                OracleCommand cmd = (OracleCommand)con.CreateCommand();
                try
                {
                    if((String)Session["Inlog"] == "Y")
                    {
                        string lijstID = h.getLijstID("SELECT * FROM LIJST WHERE email ='" + Session["Username"] + "' AND lijsttype = 'Winkelwagen'");
                        Session["Lijst"] = lijstID;
                        OracleTransaction otn = (OracleTransaction)con.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.CommandText = "INSERT INTO PRODUCTLIJST (productnaam, lijstID, aantal) VALUES ('" + (String)Session["Product"] + "','" + (String)Session["Lijst"] + "','" + "1" + "')";
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
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