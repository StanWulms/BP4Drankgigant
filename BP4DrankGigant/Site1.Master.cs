using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace BP4DrankGigant
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        List<Categorie> categorieen = new List<Categorie>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string inlog = (String)Session["Inlog"];
            if((String)Session["Inlog"] == "Y")
            {
                //In de bovenbalk komt te staan als er ingelogd is. De 'Inlog' knop wordt nu vervangen door 'Uitloggen'.
                string user = (String)Session["Username"];
                Label labelNaam = new Label();
                labelNaam.Text = "<br /> " + "U bent ingelogd" + "<br /><br />";
                labelNaam.ID = user;
                form1.Controls.Add(labelNaam);
                headbar.InnerHtml = "<ul><li>U bent ingelogd</li><li><a href=" + "Winkelwagen.aspx" + ">Winkelwagen</a></li><li><a href=" + "Uitloggen.aspx" + ">Uitloggen</a></li><li><a>Afrekenen</a></li></ul>";
            
            }
            else // Als er niet ingelogd is, dan staat er niets, en wordt de tekst 'Inloggen'.
            {
                Session["Inlog"] = "N";
                Session["User"] = "";
                Session["Password"] = "";
                headbar.InnerHtml = "<ul><li><a href=" + "Winkelwagen.aspx" + ">Winkelwagen</a></li><li><a href=" + "Inloggen.aspx" + ">Inloggen</a></li><li><a>Afrekenen</a></li></ul>";
            }
        }

        protected void HeaderImage_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Hoofdpagina.aspx");
        }
    }
}