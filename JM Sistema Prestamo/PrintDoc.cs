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
                rlines[7] = "Monto Ingreso: LINEA EXTRA, Quitarla";
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

            SqlDataReader q = dbc.query_single("SELECT  c.CL_NOMBRE, r.RECIBOID ,r.PRESTAMOID ,CONVERT(VARCHAR(15), r.HE_FECHA, 105)  AS FECHA ,r.CL_CODIGO ,(r.HE_MONTO + r.HE_DESC + r.HE_MORA) As CUOTA ,r.HE_OBSERV FROM  debitos  r inner join clientes c on (c.CL_CODIGO=r.CL_CODIGO ) where DEBITOID=" + debitoID);
            if (q.Read())
            {
                rlines[0] = "Prestamos Personales Luis Bomba";
                rlines[1] = "Mercado de Tenares, R.D. \t\t\t\t\t Fecha: " + q["FECHA"].ToString();
                rlines[2] = "Tel.: 809-587-7072, Cel.: 809-223-6854";
                rlines[3] = "____________________________________________ ";
                rlines[4] = "\t\t\tRecibo De Debito ";
                rlines[5] = "Recibo No.: " + q["RECIBOID"].ToString() + " Fecha.: " + q["FECHA"].ToString() + " Prestamo.: " + q["PRESTAMOID"].ToString() + " Cliente.: " + q["CL_CODIGO"].ToString();
                rlines[6] = "Nombre.......: " + q["CL_NOMBRE"].ToString();
                rlines[7] = "Monto Ingreso: LINEA EXTRA, Quitarla";
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
        // OnPrintPage
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

        
    }
}
