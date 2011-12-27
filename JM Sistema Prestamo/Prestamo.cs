using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

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
        string hoyfecha = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;

        public Prestamo(string codigo, DBConnection db)
        {
            this.CODIGO = codigo;
            this.dbc = db;
            this.loadPrestamoList();
        }


        public int Nuevo(DateTime pfecha, double capital, double taza, int cuota, string formadepago, string distribution)
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

                //
                //   dbc.query_insert("UPDATE prestamos SET  CO_FECPAG='" + fecha + "' where PRESTAMOID=" + prestamo);
            }

            return resultID;
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

        public int Pagares(string prestamo, string pagare, double capital, double interes, double mora, string concepto)
        {
            int resultID = 0;
            if (capital == 0.00 && interes != 0.00)
            {
                //interes only
                string sqlIns = "INSERT INTO recibos (HE_FECHA, CL_CODIGO, HE_MONTO,HE_DESC, HE_MORA, PRESTAMOID, HE_CONCEP) VALUES (@HE_FECHA, @CL_CODIGO, @HE_MONTO,@HE_DESC, @HE_MORA, @PRESTAMOID, @HE_CONCEP)";

                SqlCommand cmdIns = new SqlCommand(sqlIns);
                cmdIns.Parameters.AddWithValue("@HE_FECHA", hoyfecha);
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
                    dbc.query_insert("UPDATE prestamos SET  CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);
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
                    dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);


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

                    dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + hoyfecha + "' , HI_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + pagare + "' ");
                    dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");

                }
            }

            return resultID;
        }

        public void updatePagares(int ReciboID, string prestamo, string pagare, double capital, double interes, double mora)
        {
            // int resultID = 0;
            if (ReciboID > 0)
            {
                //update for Multiple Payments.
                dbc.query_insert("UPDATE recibos SET  HE_MONTO= HE_MONTO + " + capital + ", HE_DESC=HE_DESC + " + interes + ", HE_MORA=HE_MORA + " + mora + " where RECIBOID=" + ReciboID);

                dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);


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
                    dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);


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

                    dbc.query_insert("UPDATE historia set HI_BALCAP=HI_BALCAP -" + capital + ", HI_BALINT=HI_BALINT - " + interes + ", HI_FECFIN='" + hoyfecha + "' , HI_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo + " and HI_DOCUM='" + pagare + "' ");
                    dbc.query_insert("UPDATE clientes set CL_ACTUAL=CL_ACTUAL -" + capital + ", CL_CAPITAL=CL_CAPITAL - " + capital + ",CL_INTERES=CL_INTERES - " + interes + "  where CL_CODIGO='" + CODIGO + "'");

                 
            }

            return resultID;
        }

        public void updateDebito(int ReciboID, string prestamo, string pagare, double capital, double interes, double mora)
        {
            // int resultID = 0;
            if (ReciboID > 0)
            {
                //update for Multiple Payments.
                dbc.query_insert("UPDATE debitos SET  HE_MONTO= HE_MONTO + " + capital + ", HE_DESC=HE_DESC + " + interes + ", HE_MORA=HE_MORA + " + mora + " where RECIBOID=" + ReciboID);

                dbc.query_insert("UPDATE prestamos set CO_CAPI=CO_CAPI -" + capital + ", CO_ACTUAL=CO_ACTUAL - " + capital + ", CO_FECPAG='" + hoyfecha + "' where PRESTAMOID=" + prestamo);


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


    }
}
