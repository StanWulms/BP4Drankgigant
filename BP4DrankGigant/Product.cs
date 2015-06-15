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
    public class Product
    {
        public String Naam { get; set; }
        public String Inhoud { get; set; }
        public String Alcoholpercentage { get; set; }
        public String Merk { get; set; }
        public String Land { get; set; }
        public int Prijs { get; set; }
        public List<Product> producten { get; set; }
        public List<Product> producteninfo { get; set; }

        public Product(string naam,String inhoud, String alcoholpercentage, string merk, string land, int prijs)
        {
            this.Naam = naam;
            this.Inhoud = inhoud;
            this.Alcoholpercentage = alcoholpercentage;
            this.Merk = merk;
            this.Land = land;
            this.Prijs = prijs;
            producten = new List<Product>();
            producteninfo = new List<Product>();
        }
        public Product()
        {
            producten = new List<Product>();
            producteninfo = new List<Product>();
        }

        public void Zoeken(string naam)
        {
            
        }

        public void getProduct()
        {
            string subcategorieID = (String)System.Web.HttpContext.Current.Session["subcategorie"];
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
                com.CommandText = "SELECT Productnaam, categorieID, soortID, inhoud, alcoholpercentage, merk, land, prijs FROM Product WHERE categorieID = '" + subcategorieID + "'";
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    Product p;
                    while (reader.Read())
                    {
                        p = new Product(reader[0].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader.GetInt32(7));
                        producten.Add(p);
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }

        public void getProductInfo()
        {
            string product = (String)System.Web.HttpContext.Current.Session["Product"];
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
                    Product p;
                    while (reader.Read())
                    {
                        p = new Product(reader[0].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader.GetInt32(7));
                        producteninfo.Add(p);
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }
    }
}