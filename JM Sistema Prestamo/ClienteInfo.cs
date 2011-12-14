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
        private Control[] Editors;

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
            telefono2txt.Text = cliente1.TELEF2;
            trabajotxt.Text = cliente1.RAZON;
            trabajodirtxt.Text = cliente1.DIREC2;

            capitallb.Text = String.Format("{0:C}", cliente1.CAPITAL);
            actuallb.Text = String.Format("{0:C}", cliente1.ACTUAL);
            interestlb.Text = String.Format("{0:C}", cliente1.INTERES);
            totallb.Text = String.Format("{0:C}", cliente1.CAPITAL + cliente1.INTERES);
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

            // load cliente recibos
            loadRecibos();

        }

        private void prestamocb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prestamostr = prestamocb.SelectedItem.ToString();
            loadPrestamopagares(prestamostr);
            
        }

        private void loadRecibos()
        {
            SqlDataReader psql = cliente1.loadRecibos();
            recibolst.SuspendLayout();
            // Clear list
            recibolst.Items.Clear();
            recibolst.Columns.Clear();

            // load list column
            // Prestamos Columns
            recibolst.Columns.Add("Recibo", 60);
            recibolst.Columns.Add("Fecha", 70);
            recibolst.Columns.Add("Prestamo", 65); 
            recibolst.Columns.Add("Capital", 65);
            recibolst.Columns.Add("Interes", 65);
            recibolst.Columns.Add("Mora", 65);

            while (psql.Read())
            {
                // load list data
                ListViewItem item = new ListViewItem();

                item.Text = psql["Recibo"].ToString();
                item.SubItems.Add(psql["FECHA"].ToString());
                item.SubItems.Add(psql["Prestamo"].ToString());
                item.SubItems.Add(psql["Capital"].ToString());
                item.SubItems.Add(psql["Interes"].ToString());
                item.SubItems.Add(psql["Mora"].ToString());
                recibolst.Items.Add(item);
            }
            psql.Close();

            recibolst.ResumeLayout();

        }

        private void loadPrestamopagares(string pstr)
        {

            SqlDataReader psql = cliente1.prestamoHistoria(pstr);
            // clienteListalv. = dt; 
            // FillList(this.clienteprestamo_list, dt);
            Editors = new Control[] { cpcapitaltxt };
            cplistEx.SuspendLayout();

            // Clear list
            cplistEx.Items.Clear();
            cplistEx.Columns.Clear();

            // load list column
            // Prestamos Columns
            cplistEx.Columns.Add("Cuotas", 60);
            cplistEx.Columns.Add("Fecha", 70);
            cplistEx.Columns.Add("Capital", 65);
            cplistEx.Columns.Add("Interes", 65);
            cplistEx.Columns.Add("Cuota", 65);
            cplistEx.Columns.Add("Capital", 65);
            cplistEx.Columns.Add("Interes", 65);
            cplistEx.Columns.Add("Mora", 65);

            while (psql.Read())
            {
                // load list data
                ListViewItem item = new ListViewItem();

                item.Text = psql["CUOTA"].ToString();
                item.SubItems.Add(psql["FECHA"].ToString());
                item.SubItems.Add(psql["CAPITAL"].ToString());
                item.SubItems.Add(psql["INTERES"].ToString());
                item.SubItems.Add(psql["TOTAL"].ToString());
                item.SubItems.Add(""); // place holder for capital textfield
                item.SubItems.Add(""); // place holder for interes textfield
                item.SubItems.Add(""); // place holder mora textfield
                cplistEx.Items.Add(item);
            }
            psql.Close();

            cplistEx.ResumeLayout();
 

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
            string cuotastr = "";// cplistEx.SelectedItems[0].SubItems[5].Text;
            string prestamostr = prestamocb.SelectedItem.ToString();
            string conceptostr = conceptodepagotxt.Text;
            int reciboID = 0; 

            for (int i = 0; i < cplistEx.Items.Count; i++)
            {

                cuotastr = cplistEx.Items[i].SubItems[0].Text;
                string capitaltmp = cplistEx.Items[i].SubItems[5].Text;
                string interestmp = cplistEx.Items[i].SubItems[6].Text;
                string moratmp = cplistEx.Items[i].SubItems[7].Text;
                double capitalstr = 0.00;
                double interesstr = 0.00;
                double morastr = 0.00;

                if (capitaltmp != "" || interestmp != "" && conceptodepagotxt.Text != "")
                {
                    if (capitaltmp != "")
                    {
                        capitalstr = Double.Parse(capitaltmp);
                    }

                    if (interestmp != "")
                    {
                        interesstr = Double.Parse(interestmp);
                    }
                    if (moratmp != "")
                    {
                        morastr = Double.Parse(moratmp);
                    }

                    if (i == 0)
                    {
                        reciboID = cliente1.hacerPago(prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr);
                    }
                    else if (reciboID > 0)
                    {
                        cliente1.updateHacerPago(reciboID, prestamostr, cuotastr, capitalstr, interesstr, morastr);
                    }
                }
                //else
                //{
                //    MessageBox.Show("No Deje el  Concepto Vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

            }

            // ask to print if valid reciboID
            if (reciboID > 0)
            {
                if (MessageBox.Show("Quieres imprimir el Recibo?", "Imprimir Recibo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lines = cliente1.loadReciboPago(reciboID);

                    //print document
                    printDocument1.Print();
                }
            }
            //refresh datatable
            loadPrestamopagares(prestamostr);
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

  
        private void cplistEx_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        { 
            if (e.SubItem >= 5 && e.SubItem < 8)
            {
                cplistEx.StartEditing(Editors[0], e.Item, e.SubItem);
            } 
        }

        private void isNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void cpcapitaltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void saldoPrestamocb_CheckedChanged(object sender, EventArgs e)
        {
            //filled out all payments
            if (saldoPrestamocb.Checked)
            {
                for (int i = 0; i < cplistEx.Items.Count; i++)
                {
                    cplistEx.Items[i].Checked = true;
                }
                conceptodepagotxt.Text = "Saldo Prestamo";
            }
            else
            {
                //empty form.
                for (int i = 0; i < cplistEx.Items.Count; i++)
                {
                    cplistEx.Items[i].Checked = false;
                }
            }
        }

        private void cplistEx_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int indexnum = e.Index;

            if (e.NewValue == CheckState.Checked)
            {

                cplistEx.Items[indexnum].SubItems[5].Text = cplistEx.Items[indexnum].SubItems[2].Text;
                cplistEx.Items[indexnum].SubItems[6].Text = cplistEx.Items[indexnum].SubItems[3].Text; 
                conceptodepagotxt.Text = "Pago Cuota " + cplistEx.Items[indexnum].SubItems[0].Text;
                
                // fill out concepto 
                foreach (ListViewItem listItem in cplistEx.CheckedItems)
                {  
                    conceptodepagotxt.Text += " " + listItem.SubItems[0].Text; 
                }

            }
            else
            {
                conceptodepagotxt.Text = "";
                cplistEx.Items[indexnum].SubItems[5].Text = "";
                cplistEx.Items[indexnum].SubItems[6].Text = "";
            }
            
        }

        private void recibolst_DoubleClick(object sender, EventArgs e)
        {
            string reciboID = recibolst.SelectedItems[0].SubItems[0].Text;
            ReciboMini recmin = new ReciboMini(reciboID);
            recmin.ShowDialog(this);
            //string c1 = recmin.ToString();
            //bcm = null;
            //if (c1 != null)
            //{
            //    Cliente cl1 = new Cliente(c1);
            //    codigotxt.Text = cl1.CODIGO;
            //    nombretxt.Text = cl1.NOMBRE;
            //}
        }

       
          
       
    }
}
