using System;
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
        public string C_CODIGO { get; set; }
        public string DIREC1 { get; set; }
        public string DIREC2 { get; set; }
        public string TELEF1 { get; set; }
        public string TELEF2 { get; set; }
        public string TELEF3 { get; set; }
        public string FAX { get; set; }
        public string ENCCOM { get; set; }
        public double ACTUAL { get; set; }
        public string PASA { get; set; }
        public double CAPITAL { get; set; }
        public double INTERES { get; set; }
        public string CEDULA { get; set; }
        public string TIPO { get; set; }
        public double MONTO { get; set; }
        public double INGRES { get; set; }
        public double BALANC { get; set; }
        public string CLASE { get; set; }
        public Prestamo Prestamo;
       
        string hoyfecha =  DateTime.Now.ToString("yyyy-MM-dd");
         
        private DBConnection dbc;
        
       // private SqlConnection conn;



        public Cliente()
        { 
            dbc = new DBConnection();
            Prestamo = new Prestamo(dbc);
            CODIGO = "";
            NOMBRE = "";
            CLASE = "";
            TELEF1 = "";
            TELEF2 = "";
            TELEF3 = "";
            FAX = "";
            PASA = "";
        }

        public Cliente(string codigo)
        {
            dbc = new DBConnection();
            loadClienteFromDB(codigo);
            Prestamo = new Prestamo(CODIGO,dbc);
        } 
          

        public void createClienteNuevo()
        {

            string sqlIns = "INSERT INTO clientes (CL_CODIGO,CL_NOMBRE,CL_RAZON,ZO_CODIGO,CL_DIREC1,CL_DIREC2,CL_TELEF1,CL_TELEF2,CL_TELEF3,CL_FAX, CL_ACTUAL,CL_PASA,CL_CAPITAL,CL_INTERES,CL_CEDULA) VALUES  (@CL_CODIGO,@CL_NOMBRE,@CL_RAZON,@ZO_CODIGO,@CL_DIREC1,@CL_DIREC2,@CL_TELEF1,@CL_TELEF2,@CL_TELEF3,@CL_FAX, @CL_ACTUAL,@CL_PASA,@CL_CAPITAL,@CL_INTERES,@CL_CEDULA)";
                        
            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
            cmdIns.Parameters.AddWithValue("@CL_NOMBRE", NOMBRE);
            cmdIns.Parameters.AddWithValue("@CL_RAZON", RAZON);
            cmdIns.Parameters.AddWithValue("@ZO_CODIGO", Z_CODIGO);
            cmdIns.Parameters.AddWithValue("@CL_DIREC1", DIREC1);
            cmdIns.Parameters.AddWithValue("@CL_DIREC2", DIREC2);
            cmdIns.Parameters.AddWithValue("@CL_TELEF1", TELEF1);
            cmdIns.Parameters.AddWithValue("@CL_TELEF2", TELEF2);
            cmdIns.Parameters.AddWithValue("@CL_TELEF3", TELEF3);
            cmdIns.Parameters.AddWithValue("@CL_FAX", FAX);
            cmdIns.Parameters.AddWithValue("@CL_ACTUAL", ACTUAL);
            cmdIns.Parameters.AddWithValue("@CL_PASA", PASA);
            cmdIns.Parameters.AddWithValue("@CL_CAPITAL", CAPITAL);
            cmdIns.Parameters.AddWithValue("@CL_INTERES", INTERES);
            cmdIns.Parameters.AddWithValue("@CL_CEDULA", CEDULA);   
           int  resultID = dbc.query_insert(cmdIns); 
             
            
        }

        public DataTable ClienteListaHoy(string fecha )
        {  
            DataTable dt = dbc.query("SELECT h.CL_CODIGO as CLIENTE ,c.CL_NOMBRE as NOMBRE" +
                          ",HI_BALCAP as CAPITAL" +
                          ",HI_BALINT as INTEREST" +
                          ",(HI_BALCAP + HI_BALINT) as TOTAL " +
                          ",HI_DOCUM as CUOTA " +  
                          " FROM historia h  " +
                          "INNER JOIN prestamos p on (h.PRESTAMOID=p.PRESTAMOID)" +
                          "INNER JOIN clientes c on (h.CL_CODIGO=c.CL_CODIGO)" +
                          "WHERE h.HI_FECHA='"+fecha+"' AND h.HI_BALCAP >0 and p.INACTIVO=0   order by c.CL_NOMBRE");
          
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

        public DataTable ClienteListaAtraso(string inactivo)
        { 

            DataTable dt = dbc.query("SELECT p.CL_CODIGO as CLIENTE ,c.CL_NOMBRE as NOMBRE,PRESTAMOID as PRESTAMO,CO_CAPITAL AS CAPITAL,CO_CAVEN AS CAPVEN,CO_BALI AS INTVEN FROM  prestamos  p  INNER JOIN clientes c on (p.CL_CODIGO=c.CL_CODIGO) where INACTIVO="+inactivo+" AND (CO_CAVEN>0 or  CO_BALI>0)   order by NOMBRE ");

            return dt;

        } 

        public  void ModificarCliente()
        { 
            dbc.query_single(String.Format("UPDATE clientes SET CL_NOMBRE='{1}', CL_DIREC1='{2}', CL_DIREC2='{3}',CL_TELEF1='{4}',CL_TELEF2='{5}',CL_TELEF3='{6}',CL_RAZON='{7}',ZO_CODIGO='{8}' WHERE CL_CODIGO='{0}'", CODIGO, NOMBRE, DIREC1, DIREC2, TELEF1, TELEF2, TELEF3, RAZON, Z_CODIGO));
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
               Z_CODIGO =  q["ZO_CODIGO"].ToString();

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
            SqlDataReader dtp = dbc.query_single("SELECT  HI_DOCUM as CUOTA, CONVERT(VARCHAR(15), HI_FECHA, 105)  AS FECHA, HI_BALCAP AS CAPITAL, HI_BALINT AS INTERES,HI_MORA as MORA,(HI_BALCAP + HI_BALINT + HI_MORA) as TOTAL FROM historia where PRESTAMOID='" + prestamo + "' and (HI_BALCAP >0 or HI_BALINT>0)");

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

        public bool isPrestamoToday(string prestamo)
        {
            bool result = false;

            SqlDataReader getRecibo = dbc.query_single("SELECT  PRESTAMOID from prestamos where  PRESTAMOID='" + prestamo + "' and CO_FECHA='" + hoyfecha + "'");
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
            SqlDataReader dtp = dbc.query_single("SELECT  CONVERT(VARCHAR(15), CO_FECHA, 105)  AS FECHA ,[CO_CAPITAL] ,[CO_INTERES],[CO_TIPPAG] ,[CO_CANPAG] ,[CO_INTDIA] ,[CO_ACTUAL] ,[CO_REAL] ,[CO_MORA]  ,[CO_BALI]  ,[CO_CAVEN]  ,CONVERT(VARCHAR(15), CO_FECPAG, 105) as CO_FECPAG  FROM prestamos where PRESTAMOID='" + prestamo + "'");

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

            DataTable dtp = dbc.query("SELECT  CONVERT(VARCHAR(15), r.HE_FECHA, 105) AS Fecha, r.PRESTAMOID AS Prestamo ,c.CL_NOMBRE as Nombre,r.RECIBOID as Recibo,CONVERT(varchar, CAST(r.HE_MONTO  as Money), 1)  as Capital,CONVERT(varchar, CAST(r.HE_DESC as Money), 1)  as Interes,CONVERT(varchar, CAST((r.HE_MONTO + r.HE_DESC + r.HE_MORA) as Money), 1) as Monto  FROM  recibos r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO) where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "' order by r.RECIBOID ");
            return dtp;
        }

        public SqlDataReader IngresoMensualSuma(string d1, string d2)
        {

            SqlDataReader dtp = dbc.query_single("SELECT  sum(HE_MONTO) as Capital , sum(HE_DESC) as Interes , sum(HE_MORA) as Mora, (sum(HE_MONTO) + sum(HE_DESC) +sum(HE_MORA) ) as Monto   FROM  recibos where HE_FECHA >='" + d1 + "' and HE_FECHA <='" + d2 + "'  ");
            return dtp;
        } 

        public SqlDataReader PrestamoMensualSuma(string d1, string d2)
        { 
            SqlDataReader dtp = dbc.query_single("SELECT COUNT(*) as totalcount ,SUM(CO_CAPITAL) as totalsum from prestamos  where CO_FECHA >='" + d1 + "' and CO_FECHA <='" + d2 + "'  ");
            return dtp;
        }
    }
}
