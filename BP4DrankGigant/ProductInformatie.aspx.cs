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
    public partial class ProductInformatieaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string product = (string)Session["Product"];

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
                com.CommandText = "SELECT Productnaam, categorieID, soortID, inhoud, alcoholpercentage, merk, land, prijs FROM Product WHERE productnaam = '" + product + "'";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    //dropdownmenu
                    // lbItems.Items.Clear();

                    while (reader.Read())
                    {

                        Button ButtonChange = new Button();
                        ButtonChange.Height = 100;
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
            }
        }
        public void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + button.ID + "');</script>");
            Session["ProductInfo"] = button.ID;
            Response.Redirect("ProductInformatie.aspx");
        }
    }
}