﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{
    class Cliente
    {
        public string CODIGO  { get; set; }
        public string NOMBRE { get; set; }
        public string RAZON { get; set; }
        public string Z_CODIGO { get; set; }
        public string CA_CODIGO;
        public string DIREC1 { get; set; }
        public string DIREC2 { get; set; }
        public string TELEF1 { get; set; }
        public string TELEF2 { get; set; }
        public string TELEF3 { get; set; }
        public string FAX { get; set; }
        private string CL_ENCCOM;
        private double CL_ACTUAL = 0.00;
        private string CL_PASA;
        private double CL_CAPITAL = 0.00;
        private double CL_INTERES = 0.00;
        private string CL_CEDULA;
        private string CL_TIPO;
        private double CL_MONTO = 0.00;
        private double CL_INGRES = 0.00;
        private double CL_BALANC = 0.00;
        private string CL_CLASE;
        public Prestamo Prestamo;
       
        string hoyfecha =  DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
         
        private DBConnection dbc;
        
       // private SqlConnection conn;



        public Cliente()
        {

            dbc = new DBConnection();  
        }

        public Cliente(string codigo)
        {
            dbc = new DBConnection();
            loadClienteFromDB(codigo);
            Prestamo = new Prestamo(CODIGO,dbc);
        } 
        public string C_CODIGO
        {
            get
            {
                return CA_CODIGO;
            }
            set
            {
                CA_CODIGO = value;
            }
        } 
         

        public string ENCCOM
        {
            get
            {
                return CL_ENCCOM;
            }
            set
            {
                CL_ENCCOM = value;
            }
        }

        public double ACTUAL
        {
            get
            {
                return CL_ACTUAL;
            }
            set
            {
                CL_ACTUAL = value;
            }
        }

        public string PASA
        {
            get
            {
                return CL_PASA;
            }
            set
            {
                CL_PASA = value;
            }
        }

        public double CAPITAL
        {
            get
            {
                return CL_CAPITAL;
            }
            set
            {
                CL_CAPITAL = value;
            }
        }

        public double INTERES
        {
            get
            {
                return CL_INTERES;
            }
            set
            {
                CL_INTERES = value;
            }
        }

        public string CEDULA
        {
            get
            {
                return CL_CEDULA;
            }
            set
            {
                CL_CEDULA = value;
            }
        }

        public string TIPO
        {
            get
            {
                return CL_TIPO;
            }
            set
            {
                CL_TIPO = value;
            }
        }

        public double MONTO
        {
            get
            {
                return CL_MONTO;
            }
            set
            {
                CL_MONTO = value;
            }
        }

        public double INGRES
        {
            get
            {
                return CL_INGRES;
            }
            set
            {
                CL_INGRES = value;
            }
        }
        public double BALANC
        {
            get
            {
                return CL_BALANC;
            }
            set
            {
                CL_BALANC = value;
            }
        }

        public string CLASE
        {
            get
            {
                return CL_CLASE;
            }
            set
            {
                CL_CLASE = value;
            }
        }



        public void createClienteNuevo()
        {
            dbc.query_insert("INSERT INTO clientes ( " +
                       "[CL_CODIGO]" +
                      " ,[CL_NOMBRE]" +
                      " ,[CL_RAZON]" +
                      " ,[ZO_CODIGO]" +
                      " ,[CA_CODIGO]" +
                      " ,[CL_DIREC1]" +
                      " ,[CL_DIREC2]" +
                      " ,[CL_TELEF1]" +
                      " ,[CL_TELEF2]" +
                      " ,[CL_TELEF3]" +
                      " ,[CL_FAX]" +
                      " ,[CL_ENCCOM]" +
                      " ,[CL_ACTUAL]" +
                      " ,[CL_PASA]" +
                      " ,[CL_CAPITAL]" +
                      " ,[CL_INTERES]" +
                      " ,[CL_CEDULA]" +
                      " ,[CL_TIPO]" +
                      " ,[CL_INGRESO]" +
                      " ,[CL_MONTO]" +
                      " ,[CL_BALANCE]" +
                      " ,[CL_CLASE])" +
                      "  VALUES" +
                      " ('" + CODIGO + "'" +
                      " ,'" + NOMBRE + "'" +
                      " ,'" + RAZON + "'" +
                      " ,'" + Z_CODIGO + "'" +
                      " ,'" + CA_CODIGO + "'" +
                      " ,'" + DIREC1 + "'" +
                      " ,'" + DIREC2 + "'" +
                      " ,'" + TELEF1 + "'" +
                      " ,'" + TELEF2 + "'" +
                      " ,'" + TELEF3 + "'" +
                      " ,'" + FAX + "'" +
                      " ,'" + CL_ENCCOM + "'" +
                      " ," + CL_ACTUAL + "" +
                      " ,'" + CL_PASA + "'" +
                      " ," + CL_CAPITAL +  
                      " ," + CL_INTERES + 
                      " ,'" + CL_CEDULA + "'" +
                      " ,'" + CL_TIPO + "'" +
                      " ," + CL_INGRES   +
                      " , " + CL_MONTO +   
                      " , " + CL_BALANC +  
                      " ,'" + CL_CLASE + "');");
             
            
        }

        public DataTable ClienteListaHoy( )
        {
            DateTime today = DateTime.Now;
            string fecha = today.Year + "-" + today.Month + "-" + today.Day;
      
            DataTable dt = dbc.query("SELECT h.CL_CODIGO as CLIENTE ,c.CL_NOMBRE as NOMBRE" +
                          ",HI_BALCAP as CAPITAL" +
                          ",HI_BALINT as INTEREST" +
                          ",(HI_BALCAP + HI_BALINT) as TOTAL " +
                          ",HI_DOCUM as CUOTA " +  
                          " FROM historia h " +
                          "INNER JOIN clientes c on (h.CL_CODIGO=c.CL_CODIGO and c.CL_ACTUAL>0)" +
                          "WHERE h.HI_FECHA='"+fecha+"' AND h.HI_BALCAP >0  order by c.CL_NOMBRE");
          
            return dt;

        }

        public DataTable ClienteBuscar(string nombre,string columnname)
        {

            DataTable dt = dbc.query("SELECT [CL_CODIGO] as CLIENTE ,[CL_NOMBRE]as NOMBRE ,[CL_DIREC1] as DIRECCION ,[CL_TELEF1] as TELEFONO ,[CL_ACTUAL] as ACTUAL ,[CL_CAPITAL] as CAPITAL ,[CL_INTERES] as INTERES  FROM clientes " +
                                     "WHERE  "+columnname+" like'" + nombre + "%'  order by CL_NOMBRE");

            return dt;

        }

        public DataTable ClienteBuscarMini(string nombre, string columnname)
        {
            DataTable dt = dbc.query("SELECT [CL_CODIGO] as CLIENTE ,[CL_NOMBRE] as NOMBRE FROM clientes " +
                                     "WHERE  " + columnname + " like'" + nombre + "%'  order by CL_NOMBRE");
            return dt;
        }

        public DataTable ClienteListaAtraso()
        {

            DataTable dt = dbc.query("SELECT p.CL_CODIGO as CLIENTE ,c.CL_NOMBRE as NOMBRE,CO_CONTRA as PRESTAMO,CO_CAPITAL AS CAPITAL,CO_CAVEN AS CAPVEN,CO_BALI AS INTVEN FROM  prestamos  p  INNER JOIN clientes c on (p.CL_CODIGO=c.CL_CODIGO and c.CL_ACTUAL>0) where (CO_CAVEN>0 or  CO_BALI>0) AND CO_CANPAG !='1.00' order by NOMBRE ");

            return dt;

        }

        private void loadClienteFromDB(string codigo)
        {

           SqlDataReader q = dbc.query_single("SELECT * FROM clientes where CL_CODIGO='" + codigo +"'");
           if (q.Read())
           {
               CODIGO = q["CL_CODIGO"].ToString();
               NOMBRE = q["CL_NOMBRE"].ToString();
               DIREC1 = q["CL_DIREC1"].ToString();
               DIREC2 = q["CL_DIREC2"].ToString();
               TELEF1 = q["CL_TELEF1"].ToString();
               TELEF2 = q["CL_TELEF2"].ToString();
               TELEF3 = q["CL_TELEF3"].ToString();
               RAZON = q["CL_RAZON"].ToString();

               try
               {

                   ACTUAL = Double.Parse(q["CL_ACTUAL"].ToString());
                   CAPITAL = Double.Parse(q["CL_CAPITAL"].ToString());
                   // PASA = Double.Parse(q["CL_CAPITAL"].ToString());
                   INTERES = Double.Parse(q["CL_INTERES"].ToString());
               }
               catch (Exception err)
               {
                   //MessageBox.Show(err.Message, "Clientes, loadClienteFromDB");
               }

           }
           q.Close();

            // busca prestamos.
        
           
        }

        public SqlDataReader prestamoHistoria(string prestamo)
        {
            SqlDataReader dtp = dbc.query_single("SELECT  HI_DOCUM as CUOTA, CONVERT(VARCHAR(15), HI_FECHA, 105)  AS FECHA, HI_BALCAP AS CAPITAL, HI_BALINT AS INTERES,(HI_BALCAP + HI_BALINT) as TOTAL FROM historia where PRESTAMOID='" + prestamo + "' and (HI_BALCAP >0 or HI_BALINT>0)");

            return dtp;
        }

        public SqlDataReader loadRecibos()
        {
            SqlDataReader dtp = dbc.query_single("SELECT RECIBOID as Recibo, CONVERT(VARCHAR(15), HE_FECHA, 105) AS Fecha, PRESTAMOID AS Prestamo ,CONVERT(varchar, CAST(HE_MONTO  as Money), 1)  as Capital,CONVERT(varchar, CAST(HE_DESC as Money), 1)  as Interes,CONVERT(varchar, CAST(HE_MORA as Money), 1) as Mora  FROM  recibos WHERE CL_CODIGO='" + CODIGO + "' order by RECIBOID desc");

            return dtp;
        }
        
        public bool isReciboToday(string recibo)
        {
            bool result = false;

            SqlDataReader getRecibo = dbc.query_single("SELECT HE_FECHA, RECIBOID from recibos where  RECIBOID='"+recibo+"' and HE_FECHA='" + hoyfecha +"'");
            if (getRecibo.Read())
            {
                result = true; 
            }
            getRecibo.Close();
            return result;
        }
        public SqlDataReader loadReciboHistoria(string recibo)
        {
            SqlDataReader dtp = dbc.query_single(" SELECT  h1.HI_FACAFEC as Cuota ,h1.PRESTAMOID as Prestamo ,CONVERT(VARCHAR(15), h1.HI_FECHA, 105) as Fecha ,h1.HI_MONTO as Capital ,h2.HI_MONTO as Interes,h1.CL_CODIGO FROM historia h1 left join historia h2 on(h1.HI_DOCUM = h2.HI_DOCUM and h2.HI_TIPPAG='I' and h1.HI_FACAFEC = h2.HI_FACAFEC) where h1.HI_DOCUM='"+recibo+"' and h1.HI_TIPPAG='C'");

            return dtp;
        }
       
        public SqlDataReader prestamoBalanceInfo(string prestamo)
        {
            SqlDataReader dtp = dbc.query_single("SELECT  CONVERT(VARCHAR(15), CO_FECHA, 105)  AS FECHA ,[CO_CAPITAL] ,[CO_INTERES],[CO_TIPPAG] ,[CO_CANPAG] ,[CO_INTDIA] ,[CO_ACTUAL] ,[CO_REAL]  ,[CO_BALINT]  ,[CO_MORA]  ,[CO_BALI]  ,[CO_CAVEN]  ,CONVERT(VARCHAR(15), CO_FECPAG, 105) as CO_FECPAG  FROM prestamos where PRESTAMOID='" + prestamo + "'");

            return dtp;
        }

        public DataTable prestamoListaHistoria()
        {
             
            DataTable dtp = dbc.query("SELECT PRESTAMOID AS PRESTAMO ,CONVERT(VARCHAR(15), CO_FECHA, 105)  AS FECHA ,CO_CAPITAL AS CAPITAL,CO_INTERES AS INTERES,CO_CANPAG as CUOTAS  ,CO_TIPPAG as FORMA  FROM  prestamos  where  CL_CODIGO='" + CODIGO + "'");

            return dtp;
        }

        public SqlDataReader getZona()
        { 
            SqlDataReader zona = dbc.query_single ("SELECT ZO_NOMBRE, ZO_CODIGO FROM zona order by ZO_NOMBRE"); 
            return zona; 
        }

        
        

        

        public DataTable IngresoMensual(string d1, string d2)
        {

            DataTable dtp = dbc.query("  SELECT  CONVERT(VARCHAR(15), r.HE_FECHA, 105) AS Fecha, r.PRESTAMOID AS Prestamo ,c.CL_NOMBRE as Nombre,r.RECIBOID as Recibo,CONVERT(varchar, CAST(r.HE_MONTO  as Money), 1)  as Capital,CONVERT(varchar, CAST(r.HE_DESC as Money), 1)  as Interes,CONVERT(varchar, CAST(r.HE_MORA as Money), 1) as Mora  FROM  recibos r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO and c.CL_ACTUAL>0) where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "' order by r.RECIBOID ");
            return dtp;
        }

        public SqlDataReader IngresoMensualSuma(string d1, string d2)
        {

            SqlDataReader dtp = dbc.query_single("SELECT CONVERT(varchar, CAST(sum(HE_MONTO)  as Money), 1) as Capital ,CONVERT(varchar, CAST(sum(HE_DESC)  as Money), 1) as Interes ,CONVERT(varchar, CAST(sum(HE_MORA)  as Money), 1) as Mora   FROM  recibos where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "'  ");
            return dtp;
        }

       

    }
}
