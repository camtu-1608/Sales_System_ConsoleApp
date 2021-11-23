using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OOP_SaleSystem
{
    public class SQLConnect
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;

       public SQLConnect()
        {
            OpenConnection();
        }


        public SqlConnection OpenConnection()
        {
            Console.WriteLine("Getting connection......");

            var datasource = @"ADMINMI-QJ4NRGA\MISAMIMOSA2014";
            var database = "OOP";
            //var username = "sa";
            //var password = "parsnip";


            string connectionString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";

            
            con = new SqlConnection(connectionString);
            cmd = con.CreateCommand();
            
            try
            {
                Console.WriteLine("Openning Connection ...");
                //cmd = con.CreateCommand();
                //open connection
                con.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


            return (con);

        }

        public void CloseConnection()
        {
            con.Close();
        }

        public DataSet ExecuteQueryDataSet(
            string strSQL, CommandType ct,
            params SqlParameter[] param)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            if (param != null)
            {
                cmd.Parameters.Clear();
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            }
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                adp.Fill(ds);
            }
            catch (Exception)
            {
                return null;
            }
            return ds;
        }
    }
}
