using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;


namespace JM_Sistema_Prestamo
{
    public partial class ClienteInfo : Form
    {

        
        private string[] lines;

        public ClienteInfo()
        {
            InitializeComponent();
            // set printing document margins
            printDocument1.DefaultPageSettings.Margins.Top = 25;
            printDocument1.DefaultPageSettings.Margins.Left = 25;
            printDocument1.DefaultPageSettings.Margins.Right = 25;


        }
         
        public void loadClienteInfo(string codigo)
        {
            cliente1 = new Cliente(codigo);

            //cli.loadClienteInfo(c);
            char[] myChar = { ' ' };
            string[] nombre = cliente1.NOMBRE.Split(myChar);
            this.Text += nombre[0];

            codigotxt.Text = cliente1.CODIGO;
            nombretxt.Text = cliente1.NOMBRE;
            direcciontxt.Text = cliente1.DIREC1;
            telefonotxt.Text = cliente1.TELEF1;
            capitallb.Text = String.Format("{0:C}",cliente1.CAPITAL);
            actuallb.Text = String.Format("{0:C}",cliente1.ACTUAL);
            interestlb.Text = String.Format("{0:C}", cliente1.INTERES);
            totallb.Text = String.Format("{0:C}",cliente1.CAPITAL + cliente1.INTERES);
            moralb.Text = "$0.00";
           // String.Format("Order Total: {0:C}", moneyvalue);
            foreach (string prestamo in cliente1.PRESTAMO)
            {
                prestamocb.Items.Add(prestamo);
            }

            // only select if person has prestamo.
            if (prestamocb.Items.Count > 0)
            {
                prestamocb.SelectedIndex = 0;
            }

            // load historia de prestamo de cliente
            DataTable dt = cliente1.prestamoListaHistoria();
             
            FillList(this.clientehistoriaprestamolist, dt);
            
        }

        private void prestamocb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prestamostr = prestamocb.SelectedItem.ToString();
            loadPrestamopagares(prestamostr);
            
        }

        private void loadPrestamopagares(string pstr)
        {

            DataTable dt = cliente1.prestamoHistoria(pstr);
            // clienteListalv. = dt; 
            FillList(this.clienteprestamo_list, dt);

            //hide pago fields
            cpcapitallb.Visible = false;
            cpcapitaltxt.Visible = false;
            cpintereslb.Visible = false;
            cpinterestxt.Visible = false;
            cpmoralb.Visible = false;
            cpmoratxt.Visible = false;
            cpgrabarbtn.Visible = false;
            conceptodepagolb.Visible = false;
            conceptodepagotxt.Visible = false;

            //Prestamo Balance INFO.

            SqlDataReader pinfo = cliente1.prestamoBalanceInfo(pstr);

            if (pinfo.Read())
            {
                pcapitallb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_ACTUAL"].ToString()));
                pcapvenlb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_CAVEN"].ToString()));
                pintereslb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_BALI"].ToString()));
                ptotallb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_CAVEN"].ToString()) + double.Parse(pinfo["CO_BALI"].ToString()));
                pfupagolb.Text = pinfo["CO_FECPAG"].ToString();
                pmoralb.Text = "$0.00";
                pcapitalilb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_CAPITAL"].ToString()));
                pinteresilb.Text = pinfo["CO_INTERES"].ToString();
                pformailb.Text = pinfo["CO_TIPPAG"].ToString();
                // ptotalilb.Text = String.Format("{0:C}", (double.Parse(pinfo["CO_CAPITAL"].ToString()) / double.Parse(pinfo["CO_CANPAG"].ToString())) * (double.Parse(pinfo["CO_INTERES"].ToString()) /10.00));
                pfechailb.Text = pinfo["FECHA"].ToString();
            }

            pinfo.Close(); 

        }


        private void FillList(ListView list, DataTable table)
        {
            list.SuspendLayout();

            // Clear list
            list.Items.Clear();
            list.Columns.Clear();

            int colcounter = 1;
            // Columns
            foreach (DataColumn col in table.Columns)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = col.Caption;
                if (IsNumeric(col.DataType))
                    ch.TextAlign = HorizontalAlignment.Right;

                // if 2nd column set width to 150
                if (colcounter == 2)
                {
                    ch.Width = 70;
                }
                else if (colcounter == 1)
                {
                    ch.Width = 60;
                }
                else
                {
                    ch.Width = 70;
                }
                list.Columns.Add(ch);
                colcounter++;
            }

            // Rows
            foreach (DataRow row in table.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = row[0].ToString();

                for (int i = 1; i < table.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                list.Items.Add(item);
            }

            list.ResumeLayout();
        }

        private bool IsNumeric(Type dataType)
        {
            switch (Type.GetTypeCode(dataType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        
        private void cpgrabarbtn_Click(object sender, EventArgs e)
        { 
            string cuotastr = clienteprestamo_list.SelectedItems[0].SubItems[0].Text;
            string prestamostr = prestamocb.SelectedItem.ToString();
            string conceptostr = conceptodepagotxt.Text;
            double capitalstr = 0.00;
            double interesstr = 0.00;
            double morastr = 0.00;

            try
            {
                //check if capitaltxt is not empy
                if (cpcapitaltxt.Text != "")
                {
                    capitalstr = double.Parse(cpcapitaltxt.Text);
                }

                //check if field is not empy
                if (cpinterestxt.Text != "")
                {
                    interesstr = double.Parse(cpinterestxt.Text);
                }

                //check if field is not empty;
                if (cpmoratxt.Text != "")
                {
                    morastr = double.Parse(cpmoratxt.Text);
                }

                // check if none of the text field are empty.
                if (capitalstr == 0.00 && interesstr ==0.00 && morastr ==0.00)
                {
                    MessageBox.Show("Por Favor no lo deje vacio.", "Capital, Interes oh Mora. \r\n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                   int reciboID= cliente1.hacerPago(prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr); 
                    
                    if (MessageBox.Show("Quieres imprimir el Recibo?", "Imprimir Recibo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lines = cliente1.loadReciboPago(reciboID);
                        
                        //print document
                        printDocument1.Print();
                    }

                    //refresh datatable

                    loadPrestamopagares(prestamostr);
                    
                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Numero Solamente. \r\n",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
            
        } 
        // OnPrintPage
        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(System.Drawing.Color.Black);
            Font f = new System.Drawing.Font("Courier New", 22, FontStyle.Bold); 
            e.Graphics.DrawString(lines[0], f, brush, x, y);
            y += 30;
            f = new System.Drawing.Font("Courier New", 12);
            e.Graphics.DrawString(lines[1], f, brush, x, y);
            y += 20;  
            e.Graphics.DrawString(lines[2], f, brush, x, y); 
            // line to end header.
            f = new System.Drawing.Font("Courier New", 20, FontStyle.Bold);
            e.Graphics.DrawString(lines[3], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 16,FontStyle.Bold);
            e.Graphics.DrawString(lines[4], f, brush, x, y);
            y += 40;
            f = new System.Drawing.Font("Courier New", 11);
            e.Graphics.DrawString(lines[5], f, brush, x, y);
            y += 60; 
            e.Graphics.DrawString(lines[6], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(lines[7], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(lines[8], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(lines[9], f, brush, x, y);
            y += 80;
            e.Graphics.DrawString(lines[10], f, brush, x, y);
            y += 20;
            e.Graphics.DrawString(lines[11], f, brush, x, y);
            y += 20;


            e.HasMorePages = false;
        }

        private void clienteprestamo_list_MouseClick(object sender, MouseEventArgs e)
        {
            cpcapitallb.Visible = true;
            cpcapitaltxt.Visible = true;
            cpintereslb.Visible = true;
            cpinterestxt.Visible = true;
            cpmoralb.Visible = true;
            cpmoratxt.Visible = true;
            cpgrabarbtn.Visible = true;
            conceptodepagolb.Visible = true;
            conceptodepagotxt.Visible = true;

            //Pre-set payment
            string cuota = clienteprestamo_list.SelectedItems[0].SubItems[0].Text;
            string pago = clienteprestamo_list.SelectedItems[0].SubItems[2].Text;
            string intereses = clienteprestamo_list.SelectedItems[0].SubItems[3].Text;
            string mora = clienteprestamo_list.SelectedItems[0].SubItems[4].Text;
            conceptodepagotxt.Text = "Pago Cuota " + cuota;
            cpcapitaltxt.Text = pago;
            cpinterestxt.Text = intereses;
           // cpmoratxt.Text = mora;
 

        }
          
       
    }
}
