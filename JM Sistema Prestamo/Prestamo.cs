using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{
    class Prestamo
    {
        private readonly double WEEKLY = 4.3;
        private readonly double SEMIMONTHLY = 2.0;
        private readonly double MONTHLY = 1.0;
        private readonly double DAILY = 30.0; 
        private string CODIGO;
        public List<string> Actuales = new List<string>();
        private DBConnection dbc;
        string hoyfecha = DateTime.Now.ToString("yyyy-MM-dd");

        public Prestamo(DBConnection db)
        { 
            this.dbc = db; 
        }

        public Prestamo(string codigo, DBConnection db)
        {
            this.CODIGO = codigo;
            this.dbc = db;
            this.loadPrestamoList();
        }
        public SqlDataReader Info(string pid)
        {
            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, p.PRESTAMOID , p.CO_FECHA  AS FECHA ,p.CL_CODIGO,p.CO_CAPITAL, p.CO_INTERES,p.CO_CANPAG, p.CO_TIPPAG  FROM  prestamos  p inner join clientes c on (c.CL_CODIGO=p.CL_CODIGO ) where p.PRESTAMOID=" + pid);
            return q;
        }

        public int Nuevo(DateTime pfecha, double capital, double taza, double cuota, string formadepago, string distribution)
        {
            int resultID = 0;

            string sqlIns = "INSERT INTO prestamos (CL_CODIGO,CO_FECHA, CO_CAPITAL,CO_INTERES, CO_CANPAG,CO_TIPPAG,CO_DISTRI,CO_ACTUAL,CO_REAL,CO_CAPI,CO_BALI,CO_CAVEN ) VALUES (@CL_CODIGO,@CO_FECHA, @CO_CAPITAL,@CO_INTERES, @CO_CANPAG,@CO_TIPPAG,@CO_DISTRI,@CO_ACTUAL,@CO_REAL,@CO_CAPI,@CO_BALI,@CO_CAVEN)";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@CO_FECHA", pfecha);
            cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
            cmdIns.Parameters.AddWithValue("@CO_CAPITAL", capital);
            cmdIns.Parameters.AddWithValue("@CO_ACTUAL", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_REAL", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_CAPI", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_BALI", "0.00");
            cmdIns.Parameters.AddWithValue("@CO_CAVEN", "0.00");
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
                    cmdcIns.Parameters.AddWithValue("@HI_DOCUM", i + "/" + cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALCAP", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALINT", interes / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_TIPPRE", "1");
                    cmdcIns.Parameters.AddWithValue("@HI_CAPITAL", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_INTERES", interes / cuota);
                    int cresultID = dbc.query_insert(cmdcIns);


                }
                //update cliente balance same.
                
                dbc.query_insert(String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL + {0}, CL_CAPITAL=CL_CAPITAL + {0},CL_INTERES=CL_INTERES + {1} where CL_CODIGO='{2}'",((capital /cuota ) * cuota),interes,CODIGO));
                //
                //   dbc.query_insert("UPDATE prestamos SET  CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);
            }

            return resultID;
        }

       

        public int Update(string PrestamoID,DateTime pfecha, double capital, double taza, double cuota, string formadepago, string distribution,double capitalviejo,double interesviejo)
        { 

            string sqlIns = "UPDATE prestamos set CO_FECHA=@CO_FECHA, CO_CAPITAL=@CO_CAPITAL,CO_INTERES=@CO_INTERES, CO_CANPAG=@CO_CANPAG,CO_TIPPAG=@CO_TIPPAG,CO_DISTRI=@CO_DISTRI,CO_ACTUAL=@CO_ACTUAL,CO_REAL=@CO_REAL,CO_CAPI=@CO_CAPI,CO_BALI=@CO_BALI,CO_CAVEN=@CO_CAVEN  WHERE PRESTAMOID=@PRESTAMOID";

            SqlCommand cmdIns = new SqlCommand(sqlIns);
            cmdIns.Parameters.AddWithValue("@CO_FECHA", pfecha);
            cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
            cmdIns.Parameters.AddWithValue("@CO_CAPITAL", capital);
            cmdIns.Parameters.AddWithValue("@CO_ACTUAL", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_REAL", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_CAPI", Math.Round((capital / cuota), 2, MidpointRounding.AwayFromZero) * cuota);
            cmdIns.Parameters.AddWithValue("@CO_BALI", "0.00");
            cmdIns.Parameters.AddWithValue("@CO_CAVEN", "0.00");
            cmdIns.Parameters.AddWithValue("@CO_INTERES", taza);
            cmdIns.Parameters.AddWithValue("@CO_CANPAG", cuota);
            cmdIns.Parameters.AddWithValue("@CO_TIPPAG", formadepago);
            cmdIns.Parameters.AddWithValue("@CO_DISTRI", distribution);
            cmdIns.Parameters.AddWithValue("@PRESTAMOID", PrestamoID); 
           
            dbc.query(cmdIns);
            dbc.query_insert(String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL - {0}, CL_CAPITAL=CL_CAPITAL - {0},CL_INTERES=CL_INTERES - {1} where CL_CODIGO='{2}'",capitalviejo,interesviejo, CODIGO));
            dbc.query_insert(String.Format("DELETE FROM historia where PRESTAMOID={0}", PrestamoID));
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
                    cmdcIns.Parameters.AddWithValue("@PRESTAMOID", PrestamoID);
                    cmdcIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdcIns.Parameters.AddWithValue("@HI_FECHA", sDate);
                    cmdcIns.Parameters.AddWithValue("@HI_FECPAG", pfecha);
                    cmdcIns.Parameters.AddWithValue("@HI_FECVEN", pfecha);
                    cmdcIns.Parameters.AddWithValue("@HI_TIPO", "F");
                    cmdcIns.Parameters.AddWithValue("@HI_DOCUM", i + "/" + cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALCAP", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_BALINT", interes / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_TIPPRE", "1");
                    cmdcIns.Parameters.AddWithValue("@HI_CAPITAL", capital / cuota);
                    cmdcIns.Parameters.AddWithValue("@HI_INTERES", interes / cuota);
                    int cresultID = dbc.query_insert(cmdcIns);


                }
                //update cliente balance same.

                dbc.query_insert(String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL + {0}, CL_CAPITAL=CL_CAPITAL + {0},CL_INTERES=CL_INTERES + {1} where CL_CODIGO='{2}'", ((capital / cuota) * cuota), interes, CODIGO));
                
             
            return int.Parse(PrestamoID);
             
        }

        private void loadPrestamoList()
        {
            SqlDataReader prest = dbc.query_single("SELECT  PRESTAMOID FROM prestamos where CL_CODIGO='" + CODIGO + "' and CO_ACTUAL >0");

            while (prest.Read())
            {
                Actuales.Add(prest["PRESTAMOID"].ToString());
            }
            prest.Close();
        }


        private void setCuotaDate(string prestamoID, string cuota)
        {
            DateTime dateTemp;
            DateTime nDate = DateTime.Now.AddMonths(1);
            DateTime fDate;
            string sql = string.Format("SELECT HI_FECHA,HISTORIAID FROM historia where HI_TIPO='F' and HI_DOCUM='{0}'", cuota, prestamoID);

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = dbc.dt_query(sql);
            adapter.Fill(ds); 

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                dateTemp = DateTime.Parse(row["HI_FECHA"].ToString());
                fDate = new DateTime(nDate.Year, nDate.Month, dateTemp.Day);
                dbc.query_insert(String.Format("UPDATE  historia set HI_FECHA='{1}' WHERE HISTORIAID={0}",row["HISTORIAID"],fDate.ToString("yyyy-MM-dd")));
            }
        }
       
        public int Pagares(string prestamo, string pagare, double capital, double interes, double mora, string concepto,bool OtroIngreso)
        {
            int resultID = 0;
            if (OtroIngreso)
            {
                //interes only
                string sqlIns = "INSERT INTO recibos (HE_FECHA, CL_CODIGO, HE_MONTO,HE_DESC, HE_MORA, PRESTAMOID, HE_CONCEP) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO,@HE_DESC, @HE_MORA, @PRESTAMOID, @HE_CONCEP)";

                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", hoyfecha);
                cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdIns.Parameters.AddWithValue("@HE_DESC", interes);
                cmdIns.Parameters.AddWithValue("@HE_MONTO", 0.00);
                cmdIns.Parameters.AddWithValue("@HE_MORA", mora);
                cmdIns.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdIns.Parameters.AddWithValue("@HE_CONCEP", concepto);
                resultID = dbc.query_insert(cmdIns);
                if (resultID > 0)
                {
                    
                    //update the date of last payment, keep balance the same.
                    dbc.query_insert("UPDATE prestamos SET  CO_BALI=0, CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);
                    //set the date to next month
                    setCuotaDate(prestamo, pagare);
                }
            }
            else
            {
                string sqlIns = "INSERT INTO recibos (HE_FECHA, CL_CODIGO, HE_MONTO, HE_DESC, HE_MORA, PRESTAMOID, HE_CONCEP) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO, @HE_DESC, @HE_MORA, @PRESTAMOID, @HE_CONCEP)";
                 
                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", hoyfecha);
                cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdIns.Parameters.AddWithValue("@HE_MONTO", capital);
                cmdIns.Parameters.AddWithValue("@HE_DESC", interes);
                cmdIns.Parameters.AddWithValue("@HE_MORA", mora);
                cmdIns.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdIns.Parameters.AddWithValue("@HE_CONCEP", concepto);
                resultID = dbc.query_insert(cmdIns);

                if (resultID > 0)
                {
                    string updatepsql = String.Format("UPDATE prestamos set CO_CAPI=CO_CAPI -{0}, CO_ACTUAL=CO_ACTUAL - {0}, CO_FECPAG='{2}', CO_CAVEN=CO_CAVEN -{0},CO_BALI=CO_BALI-{1} ,CO_MORA=CO_MORA-{4} where PRESTAMOID={3}", capital, interes, hoyfecha, prestamo,mora);
                    dbc.query_insert(updatepsql);


                    //insert capital payment
                    string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                    SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                    cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
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
                    cmdInspayi.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "R");
                    cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    int iID = dbc.query_insert(cmdInspayi);
                    //update Mora
                    SqlCommand cmdInspaym = new SqlCommand(sqlInspay);
                    cmdInspaym.Parameters.AddWithValue("@HI_MONTO", mora);
                    cmdInspaym.Parameters.AddWithValue("@HI_TIPPAG", "M");
                    cmdInspaym.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspaym.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspaym.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspaym.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                    cmdInspaym.Parameters.AddWithValue("@HI_TIPO", "R");
                    cmdInspaym.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspaym.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    int mID = dbc.query_insert(cmdInspaym);

                    string cuotastr = String.Format("UPDATE historia set HI_BALCAP=HI_BALCAP -{0}, HI_BALINT=HI_BALINT -{1}, HI_MORA=HI_MORA -{2},HI_FECFIN='{3}' , HI_FECPAG='{3}' where PRESTAMOID={4} and HI_DOCUM='{5}' ", capital, interes, mora, hoyfecha, prestamo, pagare);
                    dbc.query_insert(cuotastr);
                    string clientestr = String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL - {0}, CL_CAPITAL=CL_CAPITAL - {0},CL_INTERES=CL_INTERES - {1}  where CL_CODIGO='{2}'",capital,interes,CODIGO);
                    dbc.query_insert(clientestr);

                }
            }

            return resultID;
        }

        public void UpdateInactivo(string prestamo, int status)
        {
            dbc.query_insert(String.Format("UPDATE prestamos set INACTIVO={0} where PRESTAMOID={1}",status, prestamo)); 
        }

        public bool esInactivo(string prestamo)
        {
            bool result = false;
            SqlDataReader prest = dbc.query_single(String.Format("SELECT  INACTIVO FROM prestamos where PRESTAMOID={0}",prestamo));

            if (prest.Read())
            {
                if (prest["INACTIVO"].ToString() == "1")
                {
                    result = true;
                } 
            }
            prest.Close();

            return result;
        }

        public void updatePagares(int ReciboID, string prestamo, string pagare, double capital, double interes, double mora)
        {
            // int resultID = 0;
            if (ReciboID > 0)
            {
                //update for Multiple Payments.
                dbc.query_insert("UPDATE recibos SET  HE_MONTO= HE_MONTO + " + capital + ", HE_DESC=HE_DESC + " + interes + ", HE_MORA=HE_MORA + " + mora + " where RECIBOID=" + ReciboID);

                string updatepsql = String.Format("UPDATE prestamos set CO_CAPI=CO_CAPI -{0}, CO_ACTUAL=CO_ACTUAL - {0}, CO_FECPAG='{2}', CO_CAVEN=CO_CAVEN -{0},CO_BALI=CO_BALI-{1},CO_MORA=CO_MORA-{4} where PRESTAMOID={3}", capital, interes, hoyfecha, prestamo,mora);
                dbc.query_insert(updatepsql);


                //insert capital payment
                string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdInspayc.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
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
                cmdInspayi.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "R");
                cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", ReciboID);
                cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                int iID = dbc.query_insert(cmdInspayi);

                dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + hoyfecha + "' , HI_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + pagare + "' ");
                dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");


            }
        }

        public void modificarPagares(string ReciboID,string prestamo, string cuota, double capital, double interes, double mora)
        {
            //undo recidoID to Prestamo.
            dbc.query_insert("UPDATE t1 SET t1.CO_CAPI = t1.CO_CAPI + t2.HE_MONTO, t1.CO_ACTUAL = t1.CO_ACTUAL + t2.HE_MONTO FROM prestamos t1  INNER JOIN recibos t2 ON  t1.PRESTAMOID = t2.PRESTAMOID where t2.RECIBOID="+ ReciboID);
            dbc.query_insert("UPDATE t1 set t1.CL_ACTUAL=t1.CL_ACTUAL + t2.HE_MONTO, t1.CL_CAPITAL=t1.CL_CAPITAL + t2.HE_MONTO, t1.CL_INTERES=t1.CL_INTERES + t2.HE_DESC FROM clientes t1 INNER JOIN recibos t2 on t2.RECIBOID="+ ReciboID+"  where t1.CL_CODIGO='" + CODIGO + "'");
            dbc.query_insert("UPDATE t1 SET t1.HI_BALCAP = t1.HI_BALCAP + t2.HI_MONTO  FROM historia t1  INNER JOIN historia t2 ON  (t1.PRESTAMOID = t2.PRESTAMOID and t1.HI_DOCUM=t2.HI_FACAFEC and t2.HI_TIPPAG='C') where t2.HI_DOCUM='" + ReciboID + "'");
            dbc.query_insert("UPDATE t1 SET t1.HI_BALINT = t1.HI_BALINT + t2.HI_MONTO  FROM historia t1  INNER JOIN historia t2 ON  (t1.PRESTAMOID = t2.PRESTAMOID and t1.HI_DOCUM=t2.HI_FACAFEC and t2.HI_TIPPAG='I') where t2.HI_DOCUM='" + ReciboID + "'");  
            ////make payment with new info 
            dbc.query_insert("UPDATE recibos set HE_MONTO =" + capital + ",HE_DESC=" + interes + ",HE_MORA =" + mora + " WHERE RECIBOID = " + ReciboID);
            dbc.query_insert("UPDATE historia SET HI_MONTO = " +capital+" WHERE HI_DOCUM='"+ReciboID+"' and HI_FACAFEC='"+ cuota+"' and HI_TIPPAG='C'"); 
            dbc.query_insert("UPDATE historia SET HI_MONTO = " +interes+" WHERE HI_DOCUM='"+ReciboID+"' and HI_FACAFEC='"+ cuota+"' and HI_TIPPAG='I'");
            dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + "  where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + cuota + "' ");
            dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");
            dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);         
        }

        public void modificarPagaresUpdate(string ReciboID, string prestamo, string cuota, double capital, double interes, double mora)
        {
            ////make payment with new info 
            dbc.query_insert("UPDATE recibos set HE_MONTO = HE_MONTO + " + capital + ",HE_DESC= HE_DESC +" + interes + ",HE_MORA = HE_MORA + " + mora + " WHERE RECIBOID = " + ReciboID);
            dbc.query_insert("UPDATE historia SET HI_MONTO = " + capital + " WHERE HI_DOCUM='" + ReciboID + "' and HI_FACAFEC='" + cuota + "' and HI_TIPPAG='C'");
            dbc.query_insert("UPDATE historia SET HI_MONTO = " + interes + " WHERE HI_DOCUM='" + ReciboID + "' and HI_FACAFEC='" + cuota + "' and HI_TIPPAG='I'");
            dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + hoyfecha + "' , HI_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + cuota + "' ");
            dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");
            dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);
        }


        public int Debito(string prestamo, string pagare, double capital, double interes, double mora, string concepto)
        {
            int resultID = 0;

            string sqlIns = "INSERT INTO debitos (HE_FECHA, CL_CODIGO, HE_MONTO, HE_DESC, HE_MORA, PRESTAMOID, HE_OBSERV) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO, @HE_DESC, @HE_MORA, @PRESTAMOID, @HE_OBSERV)";

                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", hoyfecha);
                cmdIns.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdIns.Parameters.AddWithValue("@HE_MONTO", capital);
                cmdIns.Parameters.AddWithValue("@HE_DESC", interes);
                cmdIns.Parameters.AddWithValue("@HE_MORA", mora);
                cmdIns.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdIns.Parameters.AddWithValue("@HE_OBSERV", concepto);
                resultID = dbc.query_insert(cmdIns);

                if (resultID > 0)
                {
                    dbc.query_insert(String.Format("UPDATE prestamos set CO_CAPI=CO_CAPI -{0}, CO_ACTUAL=CO_ACTUAL - {0}, CO_FECPAG='{2}', CO_CAVEN=CO_CAVEN -{0},CO_BALI=CO_BALI-{1},CO_MORA=CO_MORA-{4} where PRESTAMOID={3}", capital, interes, hoyfecha, prestamo,mora));


                    //insert capital payment
                    string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                    SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                    cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                    cmdInspayc.Parameters.AddWithValue("@HI_TIPO", "C");
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
                    cmdInspayi.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                    cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "C");
                    cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    int iID = dbc.query_insert(cmdInspayi);

                    //update Mora
                    SqlCommand cmdInspaym = new SqlCommand(sqlInspay);
                    cmdInspaym.Parameters.AddWithValue("@HI_MONTO", mora);
                    cmdInspaym.Parameters.AddWithValue("@HI_TIPPAG", "M");
                    cmdInspaym.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                    cmdInspaym.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                    cmdInspaym.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                    cmdInspaym.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                    cmdInspaym.Parameters.AddWithValue("@HI_TIPO", "R");
                    cmdInspaym.Parameters.AddWithValue("@HI_DOCUM", resultID);
                    cmdInspaym.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                    int mID = dbc.query_insert(cmdInspaym);

                    string cuotastr = String.Format("UPDATE historia set HI_BALCAP=HI_BALCAP -{0}, HI_BALINT=HI_BALINT -{1}, HI_MORA=HI_MORA -{2},HI_FECFIN='{3}' , HI_FECPAG='{3}' where PRESTAMOID={4} and HI_DOCUM='{5}' ", capital, interes, mora, hoyfecha, prestamo, pagare);
                    dbc.query_insert(cuotastr);
                    string clientestr = String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL - {0}, CL_CAPITAL=CL_CAPITAL - {0},CL_INTERES=CL_INTERES - {1}  where CL_CODIGO='{2}'", capital, interes, CODIGO);
                    dbc.query_insert(clientestr);

                 
            }

            return resultID;
        }

        public void updateDebito(int ReciboID, string prestamo, string pagare, double capital, double interes, double mora)
        {
            // int resultID = 0;
            if (ReciboID > 0)
            {
                //update for Multiple Payments.
                dbc.query_insert("UPDATE debitos SET  HE_MONTO= HE_MONTO + " + capital + ", HE_DESC=HE_DESC + " + interes + ", HE_MORA=HE_MORA + " + mora + " where DEBITOID=" + ReciboID);
                dbc.query_insert(String.Format("UPDATE prestamos set CO_CAPI=CO_CAPI -{0}, CO_ACTUAL=CO_ACTUAL - {0}, CO_FECPAG='{2}', CO_CAVEN=CO_CAVEN -{0},CO_BALI=CO_BALI-{1},CO_MORA=CO_MORA-{4} where PRESTAMOID={3}", capital, interes, hoyfecha, prestamo,mora));


                //insert capital payment
                string sqlInspay = "INSERT INTO historia ( CL_CODIGO, PRESTAMOID, HI_FECHA,HI_FECFIN, HI_TIPO, HI_DOCUM, HI_FACAFEC, HI_MONTO, HI_TIPPAG) VALUES ( @CL_CODIGO, @PRESTAMOID, @HI_FECHA, @HI_FECFIN, @HI_TIPO, @HI_DOCUM, @HI_FACAFEC, @HI_MONTO, @HI_TIPPAG)";
                SqlCommand cmdInspayc = new SqlCommand(sqlInspay);
                cmdInspayc.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdInspayc.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdInspayc.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                cmdInspayc.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
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
                cmdInspayi.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                cmdInspayi.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                cmdInspayi.Parameters.AddWithValue("@HI_TIPO", "R");
                cmdInspayi.Parameters.AddWithValue("@HI_DOCUM", ReciboID);
                cmdInspayi.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                int iID = dbc.query_insert(cmdInspayi);

                //update Mora
                SqlCommand cmdInspaym = new SqlCommand(sqlInspay);
                cmdInspaym.Parameters.AddWithValue("@HI_MONTO", mora);
                cmdInspaym.Parameters.AddWithValue("@HI_TIPPAG", "M");
                cmdInspaym.Parameters.AddWithValue("@CL_CODIGO", CODIGO);
                cmdInspaym.Parameters.AddWithValue("@PRESTAMOID", prestamo);
                cmdInspaym.Parameters.AddWithValue("@HI_FECHA", hoyfecha);
                cmdInspaym.Parameters.AddWithValue("@HI_FECFIN", hoyfecha);
                cmdInspaym.Parameters.AddWithValue("@HI_TIPO", "R");
                cmdInspaym.Parameters.AddWithValue("@HI_DOCUM", ReciboID);
                cmdInspaym.Parameters.AddWithValue("@HI_FACAFEC", pagare);
                int mID = dbc.query_insert(cmdInspaym);

                string cuotastr = String.Format("UPDATE historia set HI_BALCAP=HI_BALCAP -{0}, HI_BALINT=HI_BALINT -{1}, HI_MORA=HI_MORA -{2},HI_FECFIN='{3}' , HI_FECPAG='{3}' where PRESTAMOID={4} and HI_DOCUM='{5}' ", capital, interes, mora, hoyfecha, prestamo, pagare);
                dbc.query_insert(cuotastr);
                string clientestr = String.Format("UPDATE clientes set CL_ACTUAL=CL_ACTUAL - {0}, CL_CAPITAL=CL_CAPITAL - {0},CL_INTERES=CL_INTERES - {1}  where CL_CODIGO='{2}'", capital, interes, CODIGO);
                dbc.query_insert(clientestr);


            }
        }

       

    }
}
