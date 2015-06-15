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
    public partial class Producten : System.Web.UI.Page
    {
        Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
            string subcategorieID = (string)Session["subcategorie"];
            p = new Product();
            //Het goede product nemen. De sessie wordt doorgegeven waardoor het juiste product genomen kan worden.
            p.getProduct();
            foreach (Product pr in p.producten)
            {
              Button ButtonChange = new Button();
              ButtonChange.Height = 100;
              ButtonChange.Width = 100;

              ButtonChange.Text = pr.Naam;
              ButtonChange.ID = pr.Naam;
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
            Session["Product"] = button.ID;
            Response.Redirect("ProductInformatie.aspx");
        }
    }
}