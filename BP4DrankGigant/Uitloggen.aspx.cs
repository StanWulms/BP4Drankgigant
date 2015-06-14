using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BP4DrankGigant
{
    public partial class Uitloggen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUitloggen_Click(object sender, EventArgs e)
        {
            Session["Inlog"] = "N";
            Response.Redirect("Hoofdpagina.aspx");
        }
    }
}