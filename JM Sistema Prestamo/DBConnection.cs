﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace JM_Sistema_Prestamo
{
    class DBConnection
    {
        private SqlConnection myconn;
        private string dbhost;
        private string dbname;
        private string dbuser;
        private string dbpass;

        public DBConnection()
        {
            loadConfig();
            myconn = new SqlConnection("Data Source=" + dbhost + ";Initial Catalog=" + dbname + ";User id=" + dbuser + ";Password=" + dbpass + ";");

            try
            {
                myconn.Open();
            }
            catch
            {
                MessageBox.Show("La base de datos no estas disponible, favor de consultar al ingeniero. ", "Connection de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadConfig()
        {
             XmlDocument itemDoc = new XmlDocument();
             itemDoc.Load(@"C:\\JMSistemaPrestamo\\jmconfig.xml");

             XmlNodeList xnList = itemDoc.SelectNodes("/configuration/appSettings/database");

             foreach (XmlNode xn in xnList)
             { 
                dbhost = xn["dbHost"].InnerText;
                dbname = xn["dbName"].InnerText;
                dbuser = xn["dbUser"].InnerText;
                dbpass = xn["dbPass"].InnerText;
            } 

            
        }

        public SqlDataReader query_single(string query)
        {
            
            SqlDataReader dr = null;
           
            try
            {
                
                SqlCommand cmd = new SqlCommand(query, myconn);
                dr = cmd.ExecuteReader();
               
    
            } catch(SqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message +"\r\n" + query);
            }
            
          // myconn.Close();
            

            return dr;
        }

        public SqlDataAdapter dt_query(string query)
        {

            SqlDataAdapter dr = null;

            try
            {

                SqlCommand cmd = new SqlCommand(query, myconn);
                dr = new SqlDataAdapter( cmd);


            }
            catch (SqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            }

            // myconn.Close();


            return dr;
        }

        public DataTable query(string query)
        {
             
            DataTable dt = new DataTable();
 
            try
            {
                SqlCommand cmd = new SqlCommand(query, myconn);
                dt.Load(cmd.ExecuteReader());
               
            }
            catch (SqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            }

          //  myconn.Close();

            return dt;
        }

        public  void query_insert(string query)
        { 
            try
            {
                SqlCommand cmd = new SqlCommand(query, myconn);
                cmd.ExecuteNonQuery(); 
            }
            catch (SqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            } 
        }

        public void query(SqlCommand command)
        {
            try
            {
               // SqlCommand cmd = new SqlCommand(query, myconn);
                command.Connection = myconn;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            }
        }

        public int query_insert(SqlCommand cmd)
        {

            int insertID = 0;
            try
            {
                
                cmd.Connection = myconn; 
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT @@IDENTITY";

                // Get the last inserted id.
                insertID = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();
                cmd = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message,"ERROR ",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
            }

            return insertID;
        }

        public void query_update(SqlCommand cmd)
        { 
            try
            {

                cmd.Connection = myconn;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
               
                cmd.Dispose();
                cmd = null;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void Close()
        {
            myconn.Close();
        }

    }
}
