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
        private string CL_CODIGO;
        private string CL_NOMBRE;
        private string CL_RAZON;
        private string ZO_CODIGO;
        private string CA_CODIGO;
        private string CL_DIREC1;
        private string CL_DIREC2;
        private string CL_TELEF1;
        private string CL_TELEF2;
        private string CL_TELEF3;
        private string CL_FAX;
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
        private readonly double WEEKLY = 4.3;
        private readonly double SEMIMONTHLY = 2.0;
        private readonly double MONTHLY = 1.0;
        private readonly double DAILY = 30.0; 
        string fecha =  DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
         
        private DBConnection dbc;
        public  List<string> PRESTAMO =  new List<string>() ;
       // private SqlConnection conn;



        public Cliente()
        {

            dbc = new DBConnection();  
        }

        public Cliente(string codigo)
        {
            dbc = new DBConnection();
            loadClienteFromDB(codigo);
        }

        public string CODIGO
        {
            get
            {
                return CL_CODIGO;
            }
            set
            {
                CL_CODIGO = value;
            }
        }

        public string NOMBRE
        {
            get
            {
                return CL_NOMBRE;
            }
            set
            {
                CL_NOMBRE = value;
            }
        }

        public string RAZON
        {
            get
            {
                return CL_RAZON;
            }
            set
            {
                CL_RAZON = value;
            }
        }

        public string Z_CODIGO
        {
            get
            {
                return ZO_CODIGO;
            }
            set
            {
                ZO_CODIGO = value;
            }
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

        public string DIREC1
        {
            get
            {
                return CL_DIREC1;
            }
            set
            {
                CL_DIREC1 = value;
            }
        }

        public string DIREC2
        {
            get
            {
                return CL_DIREC2;
            }
            set
            {
                CL_DIREC2 = value;
            }
        }

        public string TELEF1
        {
            get
            {
                return CL_TELEF1;
            }
            set
            {
                CL_TELEF1 = value;
            }
        }

        public string  TELEF2
        {
            get
            {
                return CL_TELEF2;
            }
            set
            {
                CL_TELEF2 = value;
            }
        }

        public string TELEF3
        {
            get
            {
                return CL_TELEF3;
            }
            set
            {
                CL_TELEF3 = value;
            }
        }

        public string FAX
        {
            get
            {
                return CL_FAX;
            }
            set
            {
                CL_FAX = value;
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
                      " ('" + CL_CODIGO + "'" +
                      " ,'" + CL_NOMBRE + "'" +
                      " ,'" + CL_RAZON + "'" +
                      " ,'" + ZO_CODIGO + "'" +
                      " ,'" + CA_CODIGO + "'" +
                      " ,'" + CL_DIREC1 + "'" +
                      " ,'" + CL_DIREC2 + "'" +
                      " ,'" + CL_TELEF1 + "'" +
                      " ,'" + CL_TELEF2 + "'" +
                      " ,'" + CL_TELEF3 + "'" +
                      " ,'" + CL_FAX + "'" +
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
        
           SqlDataReader prest = dbc.query_single("SELECT  PRESTAMOID FROM prestamos where CL_CODIGO='" + codigo + "' and CO_ACTUAL >0");
      
           while (prest.Read())
           {
               PRESTAMO.Add(prest["PRESTAMOID"].ToString());
           }
           prest.Close();
        }

        public SqlDataReader prestamoHistoria(string prestamo)
        {
            SqlDataReader dtp = dbc.query_single("SELECT  HI_DOCUM as CUOTA, CONVERT(VARCHAR(15), HI_FECHA, 105)  AS FECHA, HI_BALCAP AS CAPITAL, HI_BALINT AS INTERES,(HI_BALCAP + HI_BALINT) as TOTAL FROM historia where PRESTAMOID='" + prestamo + "' and HI_BALCAP >0");

            return dtp;
        }

        public SqlDataReader loadRecibos()
        {
            SqlDataReader dtp = dbc.query_single("SELECT RECIBOID as Recibo, CONVERT(VARCHAR(15), HE_FECHA, 105) AS Fecha, PRESTAMOID AS Prestamo ,CONVERT(varchar, CAST(HE_MONTO  as Money), 1)  as Capital,CONVERT(varchar, CAST(HE_DESC as Money), 1)  as Interes,CONVERT(varchar, CAST(HE_MORA as Money), 1) as Mora  FROM  recibos WHERE CL_CODIGO='" + CODIGO + "' order by RECIBOID desc");

            return dtp;
        }
        public SqlDataReader loadReciboHistoria(string recibo)
        {
            SqlDataReader dtp = dbc.query_single(" SELECT  h1.HI_FACAFEC as Cuota ,h1.PRESTAMOID as Prestamo ,CONVERT(VARCHAR(15), h1.HI_FECHA, 105) as Fecha ,h1.HI_MONTO as Capital ,h2.HI_MONTO as Interes FROM historia h1 left join historia h2 on(h1.HI_DOCUM = h2.HI_DOCUM and h2.HI_TIPPAG='I' and h1.HI_FACAFEC = h2.HI_FACAFEC) where h1.HI_DOCUM='"+recibo+"' and h1.HI_TIPPAG='C'");

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

        public int hacerPago(string prestamo, string pagare, double capital, double interes, double mora,string concepto )
        {
            int resultID = 0;
            if (capital == 0.00 && interes != 0.00)
            {
                //interes only
                string sqlIns = "INSERT INTO recibos (HE_FECHA, CL_CODIGO, HE_MONTO,HE_DESC, HE_MORA, PRESTAMOID, HE_CONCEP) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO,@HE_DESC, @HE_MORA, @PRESTAMOID, @HE_CONCEP)";

                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", fecha);
                cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdIns.Parameters.AddWithValue("@HE_MONTO", interes);
                cmdIns.Parameters.AddWithValue("@HE_DESC", 0.00);
                cmdIns.Parameters.AddWithValue("@HE_MORA", mora);
                cmdIns.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdIns.Parameters.AddWithValue("@HE_CONCEP", concepto);
                resultID = dbc.query_insert(cmdIns);
                if (resultID > 0)
                {
                    //update the date of last payment, keep balance the same.
                    dbc.query_insert("UPDATE prestamos SET  CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);
                }
            }
            else if (capital != 0.00 && interes == 0.00)
            {
                //capital only
            }
            else
            {
                string sqlIns = "INSERT INTO recibos (HE_FECHA, CL_CODIGO, HE_MONTO, HE_DESC, HE_MORA, PRESTAMOID, HE_CONCEP) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO, @HE_DESC, @HE_MORA, @PRESTAMOID, @HE_CONCEP)";

                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", fecha);
                cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdIns.Parameters.AddWithValue("@HE_MONTO", capital);
                cmdIns.Parameters.AddWithValue("@HE_DESC", interes);
                cmdIns.Parameters.AddWithValue("@HE_MORA", mora);
                cmdIns.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdIns.Parameters.AddWithValue("@HE_CONCEP", concepto);
                resultID = dbc.query_insert(cmdIns);

                if (resultID > 0)
                {
                    dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);


                    //insert capital payment
                    string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                    SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                    cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECHA", fecha);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", fecha);
                    cmdInspayc.Parameters.AddWithValue("@HI_TIPO", "R");
                    cmdInspayc.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspayc.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    cmdInspayc.Parameters.AddWithValue("@HI_MONTO", capital);
                    cmdInspayc.Parameters.AddWithValue("@HI_TIPPAG", "C");
                    int cID = dbc.query_insert(cmdInspayc);
                    //update intres
                    SqlCommand cmdInspayi = new SqlCommand(sqlInspay);
                    cmdInspayi.Parameters.AddWithValue("@HI_MONTO", interes);
                    cmdInspayi.Parameters.AddWithValue("@HI_TIPPAG", "I");
                    cmdInspayi.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspayi.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspayi.Parameters.AddWithValue("@HI_FECHA", fecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", fecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "R");
                    cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    int iID = dbc.query_insert(cmdInspayi);

                    dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + fecha + "' , HI_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + pagare + "' ");
                    dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");

                }
            }

            return resultID; 
        }

        public void updateHacerPago(int ReciboID, string prestamo, string pagare, double capital, double interes, double mora)
        {
            // int resultID = 0;
            if (ReciboID > 0)
            {
                //update for Multiple Payments.
                dbc.query_insert("UPDATE recibos SET  HE_MONTO= HE_MONTO + " + capital + ", HE_DESC=HE_DESC + " + interes + ", HE_MORA=HE_MORA + " + mora + " where RECIBOID=" + ReciboID);

                dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);


                //insert capital payment
                string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdInspayc.Parameters.AddWithValue("@HI_FECHA", fecha);
                cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", fecha);
                cmdInspayc.Parameters.AddWithValue("@HI_TIPO", "R");
                cmdInspayc.Parameters.AddWithValue("@HI_DOCUM", ReciboID);
                cmdInspayc.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                cmdInspayc.Parameters.AddWithValue("@HI_MONTO", capital);
                cmdInspayc.Parameters.AddWithValue("@HI_TIPPAG", "C");
                int cID = dbc.query_insert(cmdInspayc);
                //update intres
                SqlCommand cmdInspayi = new SqlCommand(sqlInspay);
                cmdInspayi.Parameters.AddWithValue("@HI_MONTO", interes);
                cmdInspayi.Parameters.AddWithValue("@HI_TIPPAG", "I");
                cmdInspayi.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdInspayi.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdInspayi.Parameters.AddWithValue("@HI_FECHA", fecha);
                cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", fecha);
                cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "R");
                cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", ReciboID);
                cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                int iID = dbc.query_insert(cmdInspayi);

                dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + fecha + "' , HI_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + pagare + "' ");
                dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");


            } 
        }

        public int HacerPrestamo(DateTime pfecha, double capital, double taza, int cuota, string formadepago, string distribution)
        {
            int resultID = 0;

            string sqlIns = "INSERT INTO prestamos (CL_CODIGO,CO_FECHA, CO_CAPITAL,CO_INTERES, CO_CANPAG,CO_TIPPAG,CO_DISTRI,CO_ACTUAL,CO_REAL,CO_CAPI,CO_BALI ) VALUES (@CL_CODIGO,@CO_FECHA, @CO_CAPITAL,@CO_INTERES, @CO_CANPAG,@CO_TIPPAG,@CO_DISTRI,@CO_ACTUAL,@CO_REAL,@CO_CAPI,@CO_BALI)";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@CO_FECHA", pfecha);
            cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
            cmdIns.Parameters.AddWithValue("@CO_CAPITAL", capital);
            cmdIns.Parameters.AddWithValue("@CO_ACTUAL", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_REAL",  Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota  );
            cmdIns.Parameters.AddWithValue("@CO_CAPI", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_BALI","0.00");
            cmdIns.Parameters.AddWithValue("@CO_INTERES", taza);
            cmdIns.Parameters.AddWithValue("@CO_CANPAG", cuota);
            cmdIns.Parameters.AddWithValue("@CO_TIPPAG", formadepago);
            cmdIns.Parameters.AddWithValue("@CO_DISTRI", distribution);
            resultID = dbc.query_insert(cmdIns);

            if (resultID > 0)
            {
                // insert cuota into historia
                DateTime sDate = new DateTime(pfecha.Year, pfecha.Month, pfecha.Day);
                double interes = 0.00;

                for (int i = 1; i <= cuota; i++)
                {

                    if (formadepago == "S")
                    {
                        sDate = sDate.AddDays(7);
                        interes = (capital * taza / 100) * (cuota / WEEKLY);
                    }
                    else if (formadepago == "Q")
                    {
                        sDate = sDate.AddDays(15);
                        interes = (capital * taza / 100) * (cuota / SEMIMONTHLY);
                    }
                    else if (formadepago == "M")
                    {
                        sDate = sDate.AddMonths(1);
                        interes = (capital * taza / 100) * (cuota / MONTHLY);
                    }
                    else if (formadepago == "D")
                    {
                        sDate = sDate.AddDays(1);
                        interes = (capital * taza / 100) * (cuota / DAILY);
                    }

                    string sqlcIns = "INSERT INTO historia (PRESTAMOID,CL_CODIGO,HI_FECHA,HI_FECPAG,HI_FECVEN,HI_TIPO,HI_DOCUM,HI_BALCAP,HI_BALINT,HI_TIPPRE,HI_CAPITAL,HI_INTERES ) VALUES (@PRESTAMOID,@CL_CODIGO,@HI_FECHA,@HI_FECPAG,@HI_FECVEN,@HI_TIPO,@HI_DOCUM,@HI_BALCAP,@HI_BALINT,@HI_TIPPRE,@HI_CAPITAL,@HI_INTERES)";

                    SqlCommand cmdcIns = new SqlCommand(sqlcIns);
                    cmdcIns.Parameters.AddWithValue("@PRESTAMOID", resultID);
                    cmdcIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdcIns.Parameters.AddWithValue("@HI_FECHA", sDate);
                    cmdcIns.Parameters.AddWithValue("@HI_FECPAG", pfecha);
                    cmdcIns.Parameters.AddWithValue("@HI_FECVEN", pfecha);
                    cmdcIns.Parameters.AddWithValue("@HI_TIPO", "F");
                    cmdcIns.Parameters.AddWithValue("@HI_DOCUM", i +"/" + cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALCAP", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALINT", interes / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_TIPPRE", "1");
                    cmdcIns.Parameters.AddWithValue("@HI_CAPITAL", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_INTERES", interes / cuota); 
                    int cresultID = dbc.query_insert(cmdcIns);


                }
                //update cliente balance same.

                //
            //   dbc.query_insert("UPDATE prestamos SET  CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);
            }

            return resultID;
        }

        public string[] loadReciboPago(int reciboID)
        {

            string[] lines = new string[13];
            string today = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, r.RECIBOID ,r.PRESTAMOID ,CONVERT(VARCHAR(15), r.HE_FECHA, 105)  AS FECHA ,r.CL_CODIGO ,(r.HE_MONTO + r.HE_DESC + r.HE_MORA) As CUOTA ,r.HE_CONCEP FROM  recibos  r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO ) where RECIBOID=" + reciboID);
            if (q.Read())
            {
                lines[0] = "Prestamos Personales Luis Bomba";
                lines[1] = "Mercado de Tenares, R.D. \t\t\t\t\t Fecha: " + q["FECHA"].ToString();
                lines[2] = "Tel.: 809-587-7072, Cel.: 809-223-6854";
                lines[3] = "____________________________________________ ";
                lines[4] = "\t\t\tRecibo De Ingreso ";
                lines[5] = "Recibo No.: " + q["RECIBOID"].ToString() + " Fecha.: " + q["FECHA"].ToString() + " Prestamo.: " + q["PRESTAMOID"].ToString() + " Cliente.: " + q["CL_CODIGO"].ToString();
                lines[6] = "Nombre.......: " + q["CL_NOMBRE"].ToString();
                lines[7] = "Monto Ingreso: LINEA EXTRA, Quitarla";
                lines[8] = "RD$..........: " + q["CUOTA"].ToString();
                lines[9] = "Concepto.....: " + q["HE_CONCEP"].ToString();
                lines[10] = "Valido Si Esta Debidamente Firmado y Cellado\t\t\t____________________";
                lines[11] = "1. Original Cliente / 2. Caja Ingreso / 3. Expediente Cliente";
            }
            q.Close();

            return lines;
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
