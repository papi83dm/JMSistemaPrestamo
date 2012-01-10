using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;  
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{ 
    class PrintDoc
    {
        private DBConnection dbc; 
        string[] rlines = new string[13];
        string[] plines = new string[17];
        List<string> pcuotas = null;


        private readonly double WEEKLY = 4.3;
        private readonly double SEMIMONTHLY = 2.0;
        private readonly double MONTHLY = 1.0;
        private readonly double DAILY = 30.0; 


        public PrintDoc()
        {
           dbc = new DBConnection();  
        }

        
        public void Recibo(string reciboID)
        {

          
            string today = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, r.RECIBOID ,r.PRESTAMOID ,CONVERT(VARCHAR(15), r.HE_FECHA, 105)  AS FECHA ,r.CL_CODIGO ,(r.HE_MONTO + r.HE_DESC + r.HE_MORA) As CUOTA ,r.HE_CONCEP FROM  recibos  r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO ) where RECIBOID=" + reciboID);
            if (q.Read())
            {
                rlines[0] = "Prestamos Personales Luis Bomba";
                rlines[1] = "Mercado de Tenares, R.D. \t\t\t\t\t Fecha: " + q["FECHA"].ToString();
                rlines[2] = "Tel.: 809-587-7072, Cel.: 809-223-6854";
                rlines[3] = "____________________________________________ ";
                rlines[4] = "\t\t\tRecibo De Ingreso ";
                rlines[5] = "Recibo No.: " + q["RECIBOID"].ToString() + " Fecha.: " + q["FECHA"].ToString() + " Prestamo.: " + q["PRESTAMOID"].ToString() + " Cliente.: " + q["CL_CODIGO"].ToString();
                rlines[6] = "Nombre.......: " + q["CL_NOMBRE"].ToString();
                string[] cuotastr = q["CUOTA"].ToString().Split('.'); // split the quota into whole amount and cents
                long monto = long.Parse(cuotastr[0]);
                string montocent = cuotastr[1]; 
                rlines[7] = String.Format("Monto Ingreso: {0}Pesos Con {1}/100", Number2Word(monto),montocent).ToUpper();
                rlines[8] = "RD$..........: " + q["CUOTA"].ToString();
                rlines[9] = "Concepto.....: " + q["HE_CONCEP"].ToString();
                rlines[10] = "Valido Si Esta Debidamente Firmado y Cellado\t\t\t____________________";
                rlines[11] = "1. Original Cliente / 2. Caja Ingreso / 3. Expediente Cliente";


                /// print data
                  PrintDocument pd = new PrintDocument();
                  // set printing document margins
                  pd.DefaultPageSettings.Margins.Top = 25;
                  pd.DefaultPageSettings.Margins.Left = 25;
                  pd.DefaultPageSettings.Margins.Right = 25;
                pd.PrintPage += new PrintPageEventHandler(Recibo_PrintPage);
                // Print the document.
                pd.Print();
                pd.Dispose();
            }
            q.Close();

          //  return lines;
           
        }


        public void Debito(string debitoID)
        {


            string today = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, r.DEBITOID ,r.PRESTAMOID ,CONVERT(VARCHAR(15), r.HE_FECHA, 105)  AS FECHA ,r.CL_CODIGO ,(r.HE_MONTO + r.HE_DESC + r.HE_MORA) As CUOTA ,r.HE_OBSERV FROM  debitos  r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO ) where DEBITOID=" + debitoID);
            if (q.Read())
            {
                rlines[0] = "Prestamos Personales Luis Bomba";
                rlines[1] = "Mercado de Tenares, R.D. \t\t\t\t\t Fecha: " + q["FECHA"].ToString();
                rlines[2] = "Tel.: 809-587-7072, Cel.: 809-223-6854";
                rlines[3] = "____________________________________________ ";
                rlines[4] = "\t\t\tRecibo De Debito ";
                rlines[5] = "Recibo No.: " + q["DEBITOID"].ToString() + " Fecha.: " + q["FECHA"].ToString() + " Prestamo.: " + q["PRESTAMOID"].ToString() + " Cliente.: " + q["CL_CODIGO"].ToString();
                rlines[6] = "Nombre.......: " + q["CL_NOMBRE"].ToString();
                string[] cuotastr = q["CUOTA"].ToString().Split('.'); // split the quota into whole amount and cents
                long monto = long.Parse(cuotastr[0]);
                string montocent = cuotastr[1];
                rlines[7] = String.Format("Monto Ingreso: {0}Pesos Con {1}/100", Number2Word(monto), montocent).ToUpper();
                rlines[8] = "RD$..........: " + q["CUOTA"].ToString();
                rlines[9] = "Concepto.....: " + q["HE_CONCEP"].ToString();
                rlines[10] = "Valido Si Esta Debidamente Firmado y Cellado\t\t\t____________________";
                rlines[11] = "1. Original Cliente / 2. Caja Ingreso / 3. Expediente Cliente";


                /// print data
                PrintDocument pd = new PrintDocument();
                // set printing document margins
                pd.DefaultPageSettings.Margins.Top = 25;
                pd.DefaultPageSettings.Margins.Left = 25;
                pd.DefaultPageSettings.Margins.Right = 25;
                pd.PrintPage += new PrintPageEventHandler(Recibo_PrintPage);
                // Print the document.
                pd.Print();
                pd.Dispose();
            }
            q.Close();

            //  return lines;

        }

        private string getTypo(string t)
        {
            string result = "";
            switch (t)
            {
                case "Q":
                    result = "Quincenal";
                    break;
                case "M":
                    result = "Mensual";
                    break;
                case "S":
                    result = "Semanal";
                    break;
                case "D":
                    result = "Diario";
                    break;
            }

            return result;
        }

        public void Prestamo(string prestamoID)
        {


            string today = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, p.PRESTAMOID ,CONVERT(VARCHAR(15), p.CO_FECHA, 105)  AS FECHA ,p.CL_CODIGO,p.CO_CAPITAL, p.CO_INTERES,p.CO_CANPAG, p.CO_TIPPAG  FROM  prestamos  p inner join clientes c on (c.CL_CODIGO=p.CL_CODIGO ) where p.PRESTAMOID=" + prestamoID);
            if (q.Read())
            {
                double cuotafija = GenPrestamoCuotas(q["CO_CAPITAL"].ToString(), q["CO_INTERES"].ToString(), q["CO_CANPAG"].ToString(), q["CO_TIPPAG"].ToString(), q["FECHA"].ToString());
                plines[0] = String.Format("Prestamos Personales Luis Bomba");
                plines[1] = String.Format("Mercado de Tenares, R.D. \t\t\t\t\t Fecha: " + q["FECHA"].ToString());
                plines[2] = String.Format("Tel.: 809-587-7072, Cel.: 809-223-6854");
                plines[3] = String.Format("____________________________________________ ");
                plines[4] = String.Format("\t\t\tTABLA DE AMORTIZACION ");
                plines[5] = String.Format("Numero De Prestamo..: {0}", q["PRESTAMOID"].ToString());
                plines[6] = String.Format("Codigo Cliente......: {0}\t{1}",q["CL_CODIGO"].ToString(),q["CL_NOMBRE"].ToString());
                plines[7] = String.Format("Fecha...............: {0}", q["FECHA"].ToString());
                plines[8] = String.Format("Capital.............: {0:N}", Double.Parse(q["CO_CAPITAL"].ToString()));
                plines[9] = String.Format("Taza De Interes.....: {0} %", q["CO_INTERES"].ToString());
                plines[10] = String.Format("Cantidad De Cuotas.: {0:F0}", Double.Parse(q["CO_CANPAG"].ToString()));
                plines[11] = String.Format("Forma De Pago......: {0}",getTypo(q["CO_TIPPAG"].ToString()));
                plines[12] = String.Format("Gasto Legales %....:  ");
                plines[13] = String.Format("Cuota Fija.........: {0:N}", cuotafija);
                plines[14] = String.Format("FECHA {0,12}{1,15}{2,10}{3,14}{4,10}", "No.Cuota", "Capital", "Interes", "Total Cuota", "Balance");
                plines[15] = String.Format("__________ __________ ______________ ___________ ______________ ____________");


               
                /// print data
                PrintDocument pd = new PrintDocument();
                // set printing document margins
                pd.DefaultPageSettings.Margins.Top = 25;
                pd.DefaultPageSettings.Margins.Left = 25;
                pd.DefaultPageSettings.Margins.Right = 25;
                pd.PrintPage += new PrintPageEventHandler(Prestamo_PrintPage);
                // Print the document.
                pd.Print();
                pd.Dispose();
            }
            q.Close();

            //  return lines;

        }
        // OnPrintPage

        private double GenPrestamoCuotas(string cap, string taz, string cuo, string formadepago, string fecha)
        {
            string[] fechaval = fecha.Split('-');
            DateTime sDate = new DateTime(int.Parse(fechaval[2]), int.Parse(fechaval[1]), int.Parse(fechaval[0]));
            pcuotas = new List<string>();
            double capital = Double.Parse(cap);
            double taza = Double.Parse(taz);
            double cancuota = Double.Parse(cuo);
            double interes = 0.00;
            double cuotafija = 0;
            double balance = 0;

            for (int i = 1; i <= cancuota; i++)
            {

                if (formadepago == "S")
                {
                    sDate = sDate.AddDays(7);
                    interes = (capital * taza / 100) * (cancuota / WEEKLY);
                }
                else if (formadepago == "Q")
                {
                    sDate = sDate.AddDays(15);
                    interes = (capital * taza / 100) * (cancuota / SEMIMONTHLY);
                }
                else if (formadepago == "M")
                {
                    sDate = sDate.AddMonths(1);
                    interes = (capital * taza / 100) * (cancuota / MONTHLY);
                }
                else if (formadepago == "D")
                {
                    sDate = sDate.AddDays(1);
                    interes = (capital * taza / 100) * (cancuota / DAILY);
                }
                string tdate = sDate.ToString("dd-MM-yyyy");
                string tcuota = String.Format("{0}/{1:F0}", i, cancuota);
                cuotafija = (capital / cancuota) + (interes / cancuota);
                balance = (capital / cancuota) * cancuota - ((capital / cancuota) * i);
                string line = String.Format("{0} {1,9}{2,15:N}{3,12:N}{4,13:N}{5,14:N}", tdate, tcuota, (capital / cancuota), (interes / cancuota), cuotafija, balance);
                pcuotas.Add(line);

            }

            string lastline = String.Format("__________ __________ ______________ ___________ ______________ ____________");
            pcuotas.Add(lastline);
            lastline = String.Format("{0,35:N} {1,11:N}{2,13:N}{3,14:N}", ((capital / cancuota) * cancuota), (interes), (cuotafija * cancuota), "0.00");
            pcuotas.Add(lastline);
            return cuotafija;
        }

        private void Recibo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(System.Drawing.Color.Black);
            Font f = new System.Drawing.Font("Courier New", 22, FontStyle.Bold);
            e.Graphics.DrawString(rlines[0], f, brush, x, y);
            y += 30;
            f = new System.Drawing.Font("Courier New", 12);
            e.Graphics.DrawString(rlines[1], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(rlines[2], f, brush, x, y);
            // line to end header.
            f = new System.Drawing.Font("Courier New", 20, FontStyle.Bold);
            e.Graphics.DrawString(rlines[3], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 16, FontStyle.Bold);
            e.Graphics.DrawString(rlines[4], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 11);
            e.Graphics.DrawString(rlines[5], f, brush, x, y);
            y += 60;
            e.Graphics.DrawString(rlines[6], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(rlines[7], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(rlines[8], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(rlines[9], f, brush, x, y);
            y += 80;
            e.Graphics.DrawString(rlines[10], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(rlines[11], f, brush, x, y);
            y += 20; 
            e.HasMorePages = false;
        }


        private void Prestamo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(System.Drawing.Color.Black);
            Font f = new System.Drawing.Font("Courier New", 22, FontStyle.Bold);
            e.Graphics.DrawString(plines[0], f, brush, x, y);
            y += 30;
            f = new System.Drawing.Font("Courier New", 12);
            e.Graphics.DrawString(plines[1], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[2], f, brush, x, y);
            // line to end header.
            f = new System.Drawing.Font("Courier New", 20, FontStyle.Bold);
            e.Graphics.DrawString(plines[3], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 16, FontStyle.Bold);
            e.Graphics.DrawString(plines[4], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 11);
            e.Graphics.DrawString(plines[5], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[6], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[7], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[8], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[9], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[10], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[11], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[12], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(plines[13], f, brush, x, y);
            y += 30;
            f = new System.Drawing.Font("Courier New", 12,FontStyle.Bold);
            e.Graphics.DrawString(plines[14], f, brush, x, y);
            y += 10;
            f = new System.Drawing.Font("Courier New", 11);
            e.Graphics.DrawString(plines[15], f, brush, x, y);
            y += 20; 
            foreach (string l in pcuotas)
            {
                
                e.Graphics.DrawString(l, f, brush, x, y);
                y += 20;
            }

            e.HasMorePages = false;
        }

        public  string Number2Word(long lNumber)
        {
            string[] ones = {"Uno ","Dos ","Tres ","Cuatro ","Cinco ","Seis ","Siete ","Ocho ","Nueve ","Dies ",
                              "Once ","Doce ","Trece ","Catorce ","Quince ","Diesciseis ","Diescisiete ","Diesciocho ","Diescinueve "
                            };
            string[] tens = { "Veinte ", "Treinta ", "Cuarenta ", "Cincuenta ", "Secenta ", "Setenta ", "Ochenta ", "Noventa " };
            string[] hundreds = { "Ciento ", "Doscientos ", "Trescientos ", "Cuatrocientos ", "Quinientos ", "Seiscientos ", "Setecientos ", "Ochocientos ", "Novecientos " };

            if (lNumber == 0)
                return ("");
            if (lNumber < 0)
            {

                lNumber *= -1;
            }
            if (lNumber < 20)
            {
                return ones[lNumber - 1];
            }
            if (lNumber <= 99)
            {
                // find if reminder to append Y
                if ((lNumber % 10) == 0)
                {
                    return tens[(lNumber / 10) - 2] + Number2Word(lNumber % 10);
                }
                else
                {
                    return tens[(lNumber / 10) - 2] + "Y " + Number2Word(lNumber % 10);
                }
            }
            //if (lNumber < 1000)
            //{
            //    return Number2Word(lNumber / 100) + "Ciento " + Number2Word(lNumber % 100);
            //}
            if (lNumber < 1000)
            {
                if (lNumber == 100 )
                {
                    return "Cien " ;
                }
                else
                {
                    return hundreds[(lNumber / 100) - 1] + Number2Word(lNumber % 100);
                }
            }
            if (lNumber < 1000000)
            {
                if (lNumber >999 && lNumber < 2000)
                {
                    return  "Mil " + Number2Word(lNumber % 1000);
                }
                else
                {
                    return Number2Word(lNumber / 1000) + "Mil " + Number2Word(lNumber % 1000);
                }
            }
            if (lNumber < 10000000)
            {
                return Number2Word(lNumber / 100000) + "Millon " + Number2Word(lNumber % 100000);
            }
            if (lNumber < 1000000000)
            {
                return Number2Word(lNumber / 10000000) + "Crore " + Number2Word(lNumber % 10000000);
            }
            return "";
        }
        
    }
}
