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
    public class Categorie
    {
        public String Naam { get; set; }
        public String SubNaam { get; set; }
        public List<Categorie> categorieen { get; set; }

        List<SubCategoriee> subcategorieen;
        SubCategoriee sc;

        public Categorie()
        {
            categorieen = new List<Categorie>();
        }
        public Categorie(string naam)
        {
            this.Naam = naam;
            categorieen = new List<Categorie>();
            
        }

        public Categorie(string naam, string subnaam)
        {
            this.Naam = naam;
            this.SubNaam = subnaam;
            categorieen = new List<Categorie>();
        }

        public void AddSubCat(string naam)
        {
            sc = new SubCategoriee();
            subcategorieen.Add(sc);
        }

        public void getSubCat()
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
                    Categorie c;
                    while (reader.Read())
                    {
                        c = new Categorie(reader.GetString(0));
                        categorieen.Add(c);
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