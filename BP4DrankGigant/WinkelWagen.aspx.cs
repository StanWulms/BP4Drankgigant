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
    public partial class WinkelWagen : System.Web.UI.Page
    {
        Winkelwagen winkelwagen = new Winkelwagen();
        List<Product> winkelwagenlijst;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["Inlog"] == "Y")
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
                    com.CommandText = "SELECT productnaam FROM PRODUCTLIJST WHERE lijstID = '" + (String)Session["Lijst"] + "'";
                    DbDataReader reader = com.ExecuteReader();
                    try
                    {
                        //dropdownmenu
                        // lbItems.Items.Clear();

                        while (reader.Read())
                        {
                            Label labelNaam = new Label();
                            labelNaam.Text = "<br /> " + "Product: " + reader[0].ToString() + "<br /><br />";
                            labelNaam.ID = reader[0].ToString();
                            Panel1.Controls.Add(labelNaam);

                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                }
            }
            else
            {
                Label labelFout = new Label();
                labelFout.Text = "<br /><br />" + "U dient in te loggen om de winkelwagen te kunnen zien.";
                Panel1.Controls.Add(labelFout);
            }
        }
    }
}