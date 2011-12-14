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
        private Control[] Editors;
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
            SqlDataReader psql = cl.loadReciboHistoria(ReciboID);
            m_recibo_list.SuspendLayout();
            // Clear list
            m_recibo_list.Items.Clear();
            m_recibo_list.Columns.Clear();

            // load list column
            // Prestamos Columns
            m_recibo_list.Columns.Add("Cuota", 60); 
            m_recibo_list.Columns.Add("Prestamo", 65);
            m_recibo_list.Columns.Add("Fecha", 70);
            m_recibo_list.Columns.Add("Capital", 65);
            m_recibo_list.Columns.Add("Interes", 65); 

            while (psql.Read())
            {
                // load list data
                ListViewItem item = new ListViewItem();

                item.Text = psql["Cuota"].ToString();
                item.SubItems.Add(psql["Prestamo"].ToString());
                item.SubItems.Add(psql["Fecha"].ToString());
                item.SubItems.Add(psql["Capital"].ToString());
                item.SubItems.Add(psql["Interes"].ToString()); 
                m_recibo_list.Items.Add(item);
            }
            psql.Close();

            m_recibo_list.ResumeLayout();
        }

        private void m_recibo_list_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            if (e.SubItem >= 3 && e.SubItem <= 4)
            {
                m_recibo_list.StartEditing(Editors[0], e.Item, e.SubItem);
            }
        }
    }
}
