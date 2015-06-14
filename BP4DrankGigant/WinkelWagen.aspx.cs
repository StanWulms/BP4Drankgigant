using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BP4DrankGigant
{
    public partial class WinkelWagen : System.Web.UI.Page
    {
        Winkelwagen winkelwagen = new Winkelwagen();
        List<Product> winkelwagenlijst;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            winkelwagen.winkelwagenproducten = new List<Product>();
            winkelwagenlijst = new List<Product>();
            foreach (Product pro in winkelwagen.winkelwagenproducten)
            {
                Label labelPrijs = new Label();
                labelPrijs.Text = "Prijs: €" + "123123123123131313"  + "<br /><br />";
                labelPrijs.ID = "123123";
                Panel1.Controls.Add(labelPrijs);
            }
        }
    }
}