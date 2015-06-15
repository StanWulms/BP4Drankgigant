using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace BP4DrankGigant
{
    public class SubCategoriee
    {
        public String Naam { get; set; }
        public String ID { get; set; }
        public List<SubCategoriee> categorieen { get; set; }

        public SubCategoriee()
        {
            categorieen = new List<SubCategoriee>();
        }

        public SubCategoriee(string naam, string id)
        {
            this.Naam = naam;
            this.ID = id;
            categorieen = new List<SubCategoriee>();
        }

        public void getSubCat()
        {
            string categorienaam = (String)System.Web.HttpContext.Current.Session["categorie"];
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
                    SubCategoriee sc;
                    while (reader.Read())
                    {
                        sc = new SubCategoriee(reader.GetString(0),reader.GetString(1));
                        categorieen.Add(sc);
                    }
                }
                catch (NullReferenceException)
                {

                }
                catch
                {
                    
                }
            }
        }
    }
}