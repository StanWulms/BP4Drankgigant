﻿using System;
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
          /*  using (DbConnection con = OracleClientFactory.Instance.CreateConnection())
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
                    contentDiv.InnerHtml = "<div id=" + "catlijst" + "><ul class=" + "catlist" + ">";

                    while (reader.Read())
                    {
                        Categorie c = new Categorie(reader.GetString(0));
                        categorieen.Add(c);
                    }

                    foreach (Categorie cat in categorieen)
                    {
                        contentDiv.InnerHtml += "<li>" + cat.Naam + "<ul class=" + "catlist" + ">";
                        com.CommandText = "SELECT categorienaam FROM categorie WHERE supercategorienaam =" + cat.Naam + ";";
                        DbDataReader readerr = com.ExecuteReader();
                        while (readerr.Read())
                        {
                            contentDiv.InnerHtml += "<li><a class=" + "catolist" + " href=" + "Subcategorie.aspx" + ">" + readerr.GetString(0) + "</li>";
                        }
                        contentDiv.InnerHtml += "</ul></li>";
                    }
                    contentDiv.InnerHtml += "</ul></div>";
                }
                catch (NullReferenceException)
                {

                }
            }*/
        }
    }
}