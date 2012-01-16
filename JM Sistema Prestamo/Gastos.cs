using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JM_Sistema_Prestamo
{
    class Gastos
    {
        private DBConnection dbc;
        public string FECHA { get; set; }
        public int GASTOID { get; set; }
        public string DETALLE { get; set; }
        public string CONCEPTO { get; set; }
        public double CANTIDAD { get; set; } 

        public Gastos()
        {
            dbc = new DBConnection();
        }

        public void  Load(string gid)
        {
              SqlDataReader q = dbc.query_single(String.Format("SELECT * FROM gastos where GASTOID={0}",  gid ));
              if (q.Read())
              {
                  FECHA = q["FECHA"].ToString();
                  GASTOID = int.Parse(q["GASTOID"].ToString());
                  DETALLE = q["DETALLE"].ToString();
                  CONCEPTO = q["CONCEPTO"].ToString();
                  CANTIDAD = Double.Parse(q["CANTIDAD"].ToString());
              }
              q.Close();
        }
        public void Grabar()
        {
            string sql = string.Format("UPDATE gastos SET FECHA='{1}', DETALLE='{2}', CONCEPTO='{3}', CANTIDAD={4} WHERE GASTOID={0}", GASTOID, FECHA, DETALLE, CONCEPTO, CANTIDAD);
            SqlDataReader q = dbc.query_single(sql);
        }

        public int Nuevo()
        {
            int resultID = 0; 
            string sqlIns = "INSERT INTO gastos (DETALLE,CONCEPTO, CANTIDAD,FECHA ) VALUES (@DETALLE,@CONCEPTO, @CANTIDAD,@FECHA)";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@DETALLE", DETALLE);
            cmdIns.Parameters.AddWithValue("@CONCEPTO", CONCEPTO);
            cmdIns.Parameters.AddWithValue("@CANTIDAD", CANTIDAD);
            cmdIns.Parameters.AddWithValue("@FECHA", FECHA); 
           
            resultID = dbc.query_insert(cmdIns);

            return resultID;
        }
    }
}
