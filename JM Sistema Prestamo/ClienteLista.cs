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
    public partial class ClienteLista : Form
    {
       
        public ClienteLista(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;

        }

        private void ClienteLista_Load(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            DataTable dt = c.ClienteListaHoy();
           // clienteListalv. = dt; 
            FillList(this.m_list, dt);
            dt = c.ClienteListaAtraso("0");
            FillList(this.m_listaatraso, dt);

            //load inactivo
            dt = c.ClienteListaAtraso("1");
            FillList(this.inactivolistview, dt);
             
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
                    ch.Width = 270;
                }
                else if (colcounter ==1)
                {
                    ch.Width = 90;
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

        private void printPreviewbtn_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            m_list.Title = today.Day + " " + meses(today.Month) + today.Year + " Listado de Clientes a pagar hoy.";
           
            m_list.FitToPage = true;
            m_list.Size = new System.Drawing.Size(600, 250);
            m_list.PrintPreview();
        }

        private void m_list_DoubleClick(object sender, EventArgs e)
        {

            
           
            string ccodigo = m_list.SelectedItems[0].SubItems[0].Text;
           
            ClienteInfo cli = new ClienteInfo();
            cli.loadClienteInfo(ccodigo);
             
            cli.MdiParent = form1;
            cli.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            m_list.Title =  today.Day + " " + meses(today.Month) + today.Year +" Listado de Clientes a pagar hoy.";
           
            m_list.FitToPage = true;
            m_list.Print();
        }

        private void pagesetupbtn_Click(object sender, EventArgs e)
        {
            m_list.PageSetup();
             
        }

        private void m_listaatraso_DoubleClick(object sender, EventArgs e)
        {
            string ccodigo = m_listaatraso.SelectedItems[0].SubItems[0].Text;

            ClienteInfo cli = new ClienteInfo();
            cli.loadClienteInfo(ccodigo);

            cli.MdiParent = form1;
            cli.Show();
        }

        private string meses(int month)
        {
            string result = null;

            switch (month)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break; 
            }
            return result;

        }

        private void inactivolistview_DoubleClick(object sender, EventArgs e)
        {
            string ccodigo = inactivolistview.SelectedItems[0].SubItems[0].Text;

            ClienteInfo cli = new ClienteInfo();
            cli.loadClienteInfo(ccodigo);

            cli.MdiParent = form1;
            cli.Show();
        }

    }
}
