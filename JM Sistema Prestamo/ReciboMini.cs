using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JM_Sistema_Prestamo
{
    public partial class ReciboMini : Form
    {
        string ReciboID = null;
        string PrestamoID = null;
        private bool isReciboToday = false;
        private Control[] Editors;
        private Cliente cl;
        private string Codigo;


        public ReciboMini(string recibo)
        {
            InitializeComponent();
            ReciboID = recibo;
        } 

        private void ReciboMini_Load(object sender, EventArgs e)
        {
            
            this.Text = "Recibo ["+ReciboID+"]";
            loadHistoria();

        }

        private void loadHistoria()
        {
            Cliente cl = new Cliente();
            Editors = new Control[] { textfieldtxt };
            isReciboToday = cl.isReciboToday(ReciboID);
            if (isReciboToday)
            {
                grabarBtn.Enabled = true;
            }

            SqlDataReader psql = cl.loadReciboHistoria(ReciboID);
            m_recibo_list.SuspendLayout();
            // Clear list
            m_recibo_list.Items.Clear();
            m_recibo_list.Columns.Clear();

            

            // load list column
            // Prestamos Columns
            m_recibo_list.Columns.Add("Cuota", 50); 
            m_recibo_list.Columns.Add("Prestamo", 65);
            m_recibo_list.Columns.Add("Fecha", 70);
            m_recibo_list.Columns.Add("Capital", 65);
            m_recibo_list.Columns.Add("Interes", 65);
            m_recibo_list.Columns.Add("Mora", 65); 

            while (psql.Read())
            {
                // load list data
                ListViewItem item = new ListViewItem();
                Codigo = psql["CL_CODIGO"].ToString();
                PrestamoID = psql["Prestamo"].ToString();
                item.Text = psql["Cuota"].ToString();
                item.SubItems.Add(psql["Prestamo"].ToString());
                item.SubItems.Add(psql["Fecha"].ToString());
                item.SubItems.Add(psql["Capital"].ToString());
                item.SubItems.Add(psql["Interes"].ToString());
                item.SubItems.Add(psql["Mora"].ToString()); 
                m_recibo_list.Items.Add(item);
            }
            psql.Close();

            m_recibo_list.ResumeLayout();
        }

        private void m_recibo_list_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
               
            if (e.SubItem >= 3 && e.SubItem <= 5 && isReciboToday)
            {
                m_recibo_list.StartEditing(Editors[0], e.Item, e.SubItem);
            }
        }

        private void grabarBtn_Click(object sender, EventArgs e)
        {
            cl = new Cliente(Codigo);
            string cuotastr = "";// cplistEx.SelectedItems[0].SubItems[5].Text; 
            

            for (int i = 0; i < m_recibo_list.Items.Count; i++)
            {
                cuotastr = m_recibo_list.Items[i].SubItems[0].Text;
                string capitaltmp = m_recibo_list.Items[i].SubItems[3].Text;
                string interestmp = m_recibo_list.Items[i].SubItems[4].Text;
                string moratmp = m_recibo_list.Items[i].SubItems[5].Text;
                double capitalstr = 0.00;
                double interesstr = 0.00;
                double morastr = 0.00;

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
                    cl.Prestamo.modificarPagares(ReciboID, PrestamoID, cuotastr, capitalstr, interesstr, morastr);
                }
                else 
                {
                    // add the 2nd pagare
                   cl.Prestamo.modificarPagaresUpdate(ReciboID, PrestamoID, cuotastr, capitalstr, interesstr, morastr);
                }
                this.Close();
             
            }

        }
    }
}
