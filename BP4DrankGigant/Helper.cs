using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace BP4DrankGigant
{
    public class Helper
    {
        List<Categorie> categorien;
        Categorie c;
        public Helper()
        {

        }

        public void addCategorie(string naam)
        {
            c= new Categorie(naam);
            categorien.Add(c);
        }

        public int getMaXID(string query)
        {
            //Fields
            int maxid;

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
                com.CommandText = query;
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    reader.Read();
                    /// <summary>
                    /// Ik return de maximum van het ID en tel daar 1 bij op.
                    /// Zo kan ik INSERT statements aanroepen zonder bang te zijn een dubbele primary key te krijgen
                    /// </summary>
                    /// 
                   // maxid = Convert.ToInt32(reader.GetString(0));
                    maxid = reader.GetInt32(0);
                    maxid++;
                    reader.Close();
                    return maxid;
                    
                }
                catch (NullReferenceException)
                {
                    return -1;

                }
            }
        }
        public string getLijstID(string query)
        {
            string lijstID;
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
                com.CommandText = query;
                DbDataReader reader = com.ExecuteReader();
                try
                {
                    reader.Read();
                    /// <summary>
                    /// Ik return de maximum van het ID en tel daar 1 bij op.
                    /// Zo kan ik INSERT statements aanroepen zonder bang te zijn een dubbele primary key te krijgen
                    /// </summary>
                    /// 
                    // maxid = Convert.ToInt32(reader.GetString(0));
                    lijstID = reader.GetString(0);
                    // maxid++;
                    reader.Close();
                    return lijstID;

                }
                catch (NullReferenceException)
                {
                    return "-1";

                }
            }
        }
    }
}