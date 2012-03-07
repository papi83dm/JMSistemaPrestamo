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
        }

        private void loadZona()
        { 
            SqlDataReader zona = cliente1.getZona();
            ArrayList zonalist = new ArrayList();
            int count = 0;
            int selectedzona = -1;
            while (zona.Read())
            {
                if (zona["ZO_CODIGO"].ToString() == cliente1.Z_CODIGO)
                {
                    selectedzona = count;
                }
                zonalist.Add(new AddValue(zona["ZO_NOMBRE"].ToString(), zona["ZO_CODIGO"].ToString()));
                count++;
            }
            zona.Close();
            zonacb.DataSource = zonalist;
            zonacb.DisplayMember = "Display";
            zonacb.ValueMember = "Value";
            zonacb.SelectedIndex = selectedzona;
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
            loadZona();
            capitallb.Text = String.Format("{0:C}", cliente1.CAPITAL);
            actuallb.Text = String.Format("{0:C}", cliente1.ACTUAL);
            interestlb.Text = String.Format("{0:C}", cliente1.INTERES);
            totallb.Text = String.Format("{0:C}", cliente1.CAPITAL + cliente1.INTERES);
            moralb.Text = "$0.00";


            // String.Format("Order Total: {0:C}", moneyvalue);
            foreach (string prestamo in cliente1.Prestamo.Actuales)
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
            bool esInactivo = cliente1.Prestamo.esInactivo(prestamostr);
            loadPrestamopagares(prestamostr);

            inactivoCB.Checked = (esInactivo) ? true : false;
             
            
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
            cplistEx.Columns.Add("B. Mora", 60);
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
                item.SubItems.Add(psql["MORA"].ToString());
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
                pmoralb.Text = String.Format("{0:C}", double.Parse(pinfo["CO_MORA"].ToString()));
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
            
            PagarCuota(false);  
        } 

        private void PagarCuota(bool otroIngreso)
        {
            string cuotastr = "";// cplistEx.SelectedItems[0].SubItems[5].Text;
            string prestamostr = prestamocb.SelectedItem.ToString();
            string conceptostr = conceptodepagotxt.Text;
            int reciboID = 0;
            int debitoID = 0;

            if (conceptostr != "")
            {

                for (int i = 0; i < cplistEx.Items.Count; i++)
                {

                    cuotastr = cplistEx.Items[i].SubItems[0].Text;
                    string ocapitaltmp = cplistEx.Items[i].SubItems[2].Text;
                    string ointerestmp = cplistEx.Items[i].SubItems[3].Text;
                    string capitaltmp = cplistEx.Items[i].SubItems[6].Text;
                    string interestmp = cplistEx.Items[i].SubItems[7].Text;
                    string moratmp = cplistEx.Items[i].SubItems[8].Text;
                    double capitalstr = 0.00;
                    double interesstr = 0.00;
                    double ocapitalstr = 0.00;
                    double ointeresstr = 0.00;
                    double morastr = 0.00;
                    bool iserror = false;
                    if ((capitaltmp != "" || interestmp != ""))
                    {

                        if (capitaltmp != "")
                        {
                            capitalstr = Double.Parse(capitaltmp);
                        }

                        if (interestmp != "")
                        {
                            interesstr = Double.Parse(interestmp);
                        }
                        if (ocapitaltmp != "")
                        {
                            ocapitalstr = Double.Parse(ocapitaltmp);
                        }

                        if (ointerestmp != "")
                        {
                            ointeresstr = Double.Parse(ointerestmp);
                        }
                        if (moratmp != "")
                        {
                            morastr = Double.Parse(moratmp);
                        }

                        //do Debito
                        //check if payment is greather than what is owe.
                        if (capitalstr > ocapitalstr || interesstr > ointeresstr || iserror)
                        {
                            MessageBox.Show("No puedes cobrarle mas al cliente de lo que debes.", "Error de Cuota", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {

                            if (debitocb.Checked)
                            {
                                if (debitoID == 0)
                                {

                                    debitoID = cliente1.Prestamo.Debito(0,prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr);
                                }
                                else if (debitoID > 0)
                                {
                                    debitoID = cliente1.Prestamo.Debito(debitoID, prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr);
                               
                                }
                            }
                            else
                            {

                                if (reciboID == 0)
                                {

                                    reciboID = cliente1.Prestamo.Pagares(0, prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr, otroIngreso);
                                }
                                else if (reciboID > 0)
                                {
                                    reciboID = cliente1.Prestamo.Pagares(reciboID, prestamostr, cuotastr, capitalstr, interesstr, morastr, conceptostr, otroIngreso);

                                    //  cliente1.Prestamo.updatePagares(reciboID, prestamostr, cuotastr, capitalstr, interesstr, morastr);
                                }

                            }
                        }
                    }


                }

                // ask to print if valid reciboID
                if (reciboID > 0)
                {
                    //clear concepto.
                    conceptodepagotxt.Text = "";
                    //refresh datatable
                    loadPrestamopagares(prestamostr);
                    if (MessageBox.Show("Quieres imprimir el Recibo?", "Imprimir Recibo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //lines = cliente1.loadReciboPago(reciboID);
                        PrintDoc pd = new PrintDoc();
                        pd.Recibo(reciboID.ToString());
                        pd = null;
                    }
                }
                else if (debitoID > 0)
                {
                    //clear concepto.
                    conceptodepagotxt.Text = "";
                    //refresh datatable
                    loadPrestamopagares(prestamostr);
                    if (MessageBox.Show("Quieres imprimir el Recibo?", "Imprimir Recibo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //lines = cliente1.loadReciboPago(reciboID);
                        PrintDoc pd = new PrintDoc();
                        pd.Debito(debitoID.ToString());
                        pd = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("No Deje el  Concepto Vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
        private void cplistEx_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        { 
            if (e.SubItem >= 6 && e.SubItem < 9)
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
                cplistEx.Items[indexnum].SubItems[6].Text = cplistEx.Items[indexnum].SubItems[2].Text;
                cplistEx.Items[indexnum].SubItems[7].Text = cplistEx.Items[indexnum].SubItems[3].Text;
                cplistEx.Items[indexnum].SubItems[8].Text = cplistEx.Items[indexnum].SubItems[4].Text; 
                conceptodepagotxt.Text = "Pago Cuota ";
                
                // fill out concepto 
                for(int i =0; i<cplistEx.Items.Count; i++)
                { 
                    if (cplistEx.Items[i].Checked)
                    {
                        conceptodepagotxt.Text += " " + cplistEx.Items[i].SubItems[0].Text;
                    }
                    else if (indexnum == i)
                    {
                        conceptodepagotxt.Text += " " + cplistEx.Items[i].SubItems[0].Text;
                    }
                }

            }
            else
            {
                conceptodepagotxt.Text = "";
                cplistEx.Items[indexnum].SubItems[6].Text = "";
                cplistEx.Items[indexnum].SubItems[7].Text = "";
                cplistEx.Items[indexnum].SubItems[8].Text = "";
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

        private void printRecibobtn_Click(object sender, EventArgs e)
        {
            string reciboID = recibolst.SelectedItems[0].SubItems[0].Text;
            if (reciboID != "")
            {
                PrintDoc pd = new PrintDoc();
                pd.Recibo(reciboID);
                pd = null;
                loadRecibos();
            }
           // MessageBox.Show(reciboID);
        }

        private void ActualizarBtn_Click(object sender, EventArgs e)
        {
            loadRecibos();
        }

        private void imprimirPrestamobtn_Click(object sender, EventArgs e)
        {
            string prestamoID = clientehistoriaprestamolist.SelectedItems[0].SubItems[0].Text;
            if (prestamoID != "")
            {
                PrintDoc pd = new PrintDoc();
                pd.Prestamo(prestamoID);
                pd = null;
            }
        }

         

        private void inactivoCB_Click(object sender, EventArgs e)
        {
            string prestamostr = prestamocb.SelectedItem.ToString();
            if (inactivoCB.Checked)
            {
                //make prestamo inactive
                cliente1.Prestamo.UpdateInactivo(prestamostr, 1);
            }
            else
            {
                //make prestamo active.
                cliente1.Prestamo.UpdateInactivo(prestamostr, 0);
            }
        }

        private void ingresoBoton_Click(object sender, EventArgs e)
        {
            PagarCuota(true);  
        }

        private void GrabarCliente()
        { 
            cliente1.NOMBRE = nombretxt.Text;
            cliente1.DIREC1 = direcciontxt.Text;
            cliente1.TELEF1 = telefonotxt.Text;
            cliente1.TELEF2 = telefono2txt.Text;
            cliente1.RAZON = trabajotxt.Text;
            cliente1.DIREC2 = trabajodirtxt.Text;
            cliente1.Z_CODIGO = zonacb.SelectedValue.ToString();
            cliente1.ModificarCliente();
            
        }

        private void grabarClienteBtn_Click(object sender, EventArgs e)
        {
            GrabarCliente();
            MessageBox.Show("Informacion has sido grabado, Gracias.");
        }

        private void clientehistoriaprestamolist_DoubleClick(object sender, EventArgs e)
        {
            PrestamoNuevo pform = new PrestamoNuevo();
            pform.MdiParent = this.MdiParent;
            string pid = clientehistoriaprestamolist.SelectedItems[0].Text;
            pform.PrestamoNuevoLoad(pid);
            pform.Show();
        }

       
         

       
          
       
    }
}
