using System;
using System.Collections.Generic;
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
    public partial class Hoofdpagina : System.Web.UI.Page
    {
        int i = 1;
        Helper h;
        Categorie c = new Categorie();
        Categorie cat = new Categorie();
        List<Categorie> categorieen = new List<Categorie>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if((String)Session["Inlog"] == "Y")
            {
                string user = (String)Session["User"];
                Label labelNaam = new Label();
                labelNaam.Text = "<br /> " + "U bent ingelogd" + "<br /><br />";
                labelNaam.ID = user;
                Panel1.Controls.Add(labelNaam);
            }
            h = new Helper();
            c = new Categorie();
            
            Session["Categorie"] = c;
            //
            c.getSubCat();
            
          //  ContentDiv.InnerHtml += "<div id=" + "lijst" + "><ul class=" + "categorielijst" + ">";
           // ContentDiv.InnerHtml += "<li><a class=" + "catsdogs" + "href=" + "SubCategorie.aspx" + ">" + reader[0].ToString() + "</a></li>";
           // ContentDiv.InnerHtml += "</ul></div>";

            foreach (Categorie cat in c.categorieen)
            {
                Button ButtonChange = new Button();
                ButtonChange.Height = 100;
                ButtonChange.Width = 100;

                ButtonChange.Text = cat.Naam;
                ButtonChange.ID = cat.Naam;
                ButtonChange.Font.Size = FontUnit.Point(7);
                ButtonChange.ControlStyle.CssClass = "button";
                ButtonChange.Click += new EventHandler(btn_Click);

                Panel1.Controls.Add(ButtonChange);
            }


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
                com.CommandText = "SELECT categorienaam FROM CATEGORIE WHERE supercategorienaam IS NULL";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    //dropdownmenu
                    // lbItems.Items.Clear();

                    while (reader.Read())
                    {

                        ContentDiv.InnerHtml += "<div id=" + "lijst" + "><ul class=" + "categorielijst" + ">";
                        ContentDiv.InnerHtml += "<li><a class=" + "catsdogs" + "href=" + "SubCategorie.aspx"+">" +reader[0].ToString() + "</a></li>";
                        ContentDiv.InnerHtml += "</ul></div>";

                        Button ButtonChange = new Button();
                        ButtonChange.Height= 100;
                        ButtonChange.Width = 100;
                        
                        ButtonChange.Text = reader[0].ToString();
                        ButtonChange.ID = reader[0].ToString();
                        ButtonChange.Font.Size = FontUnit.Point(7);
                        ButtonChange.ControlStyle.CssClass = "button";
                        ButtonChange.Click += new EventHandler(btn_Click);
                        
                        Panel1.Controls.Add(ButtonChange);

                    }
                }
                catch (NullReferenceException)
                {

                }
            }*/
        }

        protected void btnSterkeDrank_Click(object sender, EventArgs e)
        {
            Session["categorie"] = "Sterke drank";
            Response.Redirect("SubCategorie.aspx");
        }
        protected void btnAlcVrij_Click(object sender, EventArgs e)
        {
            Session["categorie"] = "Alc.vrij";
            Response.Redirect("SubCategorie.aspx");
        }
        public void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + button.ID +"');</script>");
            Session["categorie"] = button.ID;
            Response.Redirect("SubCategorie.aspx");
        }

    }
}