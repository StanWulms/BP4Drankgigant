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
        Helper h;
        Categorie c = new Categorie();
        Categorie cat = new Categorie();
        List<Categorie> categorieen = new List<Categorie>();

        protected void Page_Load(object sender, EventArgs e)
        {
            h = new Helper();
            c = new Categorie();
            
            Session["Categorie"] = c;
            c.getSubCat();

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