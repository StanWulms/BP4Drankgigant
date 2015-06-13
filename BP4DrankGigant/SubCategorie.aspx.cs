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
        protected void Page_Load(object sender, EventArgs e)
        {
            string categorienaam = (string)Session["categorie"];

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
                com.CommandText = "SELECT categorienaam, categorieID FROM CATEGORIE WHERE supercategorienaam = '" + categorienaam + "'";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    //dropdownmenu
                    // lbItems.Items.Clear();

                    while (reader.Read())
                    {

                        //h.addCategorie(reader[0].ToString());

                        //        links.InnerHtml = "<b><a runat=" + "server" + "  href=" + "SubCategorie.aspx" + ">" + reader[0].ToString() + "</a></b>";
                        //     links.InnerHtml += "<b><a runat=" + "server" + "  href=" + "SubCategorie.aspx" + ">" + reader[0].ToString() + "</a></b><br /> <br />";
                        //     links.InnerHtml += "<ul><li><a>" + reader[0].ToString() + "</a></li></ul>";
                        //     links.InnerHtml += "<div class=" + "categorie" + " runat=" + "server" + " style=" + "height" + ">" + reader[0].ToString() + "</div>";
                        //links.InnerHtml = "<b>Hello World</b>";
                        //links.InnerHtml += "<br/>Booya";
                        // links.InnerHtml = "";
                        //    links.InnerHtml += "<div style='background-color:red'>";
                        //    rechts.InnerHtml = "<b>" + reader[1].ToString() + "</b>";
                        Button ButtonChange = new Button();
                        ButtonChange.Height = 100;
                        ButtonChange.Width = 100;

                        ButtonChange.Text = reader[0].ToString();
                        ButtonChange.ID = reader[1].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["terug"] = "terug";
            Response.Redirect("Hoofdpagina.aspx");
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