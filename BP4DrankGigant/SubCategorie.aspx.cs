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
    public partial class SubCategorie : System.Web.UI.Page
    {
        SubCategoriee sc;
        protected void Page_Load(object sender, EventArgs e)
        {
            string categorienaam = (string)Session["categorie"];
            sc = new SubCategoriee();
            //Haal de juiste subcategorie op.
            sc.getSubCat();
            foreach (SubCategoriee subcat in sc.categorieen)
            {
                Button ButtonChange = new Button();
                ButtonChange.Height = 100;
                ButtonChange.Width = 100;

                ButtonChange.Text = subcat.Naam;
                ButtonChange.ID = subcat.ID;
                ButtonChange.Font.Size = FontUnit.Point(7);
                ButtonChange.ControlStyle.CssClass = "button";
                ButtonChange.Click += new EventHandler(btn_Click);

                Panel1.Controls.Add(ButtonChange); 
            }
        }

        public void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + button.ID + "');</script>");
            Session["subcategorie"] = button.ID;
            Response.Redirect("Producten.aspx");
        }
    }
}