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
    public partial class dbTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                com.CommandText = "SELECT categorienaam FROM CATEGORIE WHERE supercategorienaam IS NULL";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    //dropdownmenu
                    // lbItems.Items.Clear();
                    ListBox1.Items.Clear();
                    while (reader.Read())
                    {
                        //   lbItems.Items.Add(reader[0].ToString());
                        ListBox1.Items.Add(reader[0].ToString());
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
    }
}