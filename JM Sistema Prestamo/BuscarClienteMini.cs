using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{
    public partial class BuscarClienteMini : Form
    {
        private string cliente = null;
        public BuscarClienteMini()
        {
            InitializeComponent();
        }

        private void bcnombretxt_TextChanged(object sender, EventArgs e)
        {
            int count = bcnombretxt.TextLength;
            if (count >= 3)
            {
                string buscar = bcnombretxt.Text;
                Cliente c = new Cliente();
                DataTable dt = c.ClienteBuscarMini(buscar, "CL_NOMBRE");
                // clienteListalv. = dt; 

                FillList(this.m_buscarcliente_list, dt);

            }
        }

        private void bccodigotxt_TextChanged(object sender, EventArgs e)
        {
            int count = bccodigotxt.TextLength;
            if (count >= 4)
            {
                string buscar = bccodigotxt.Text;
                Cliente c = new Cliente();
                DataTable dt = c.ClienteBuscarMini(buscar, "CL_CODIGO");
                // clienteListalv. = dt; 

                FillList(this.m_buscarcliente_list, dt);

            }
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
                    ch.Width = 200;
                }
                else if (colcounter == 1)
                {
                    ch.Width = 80;
                }
                else if (colcounter == 3)
                {
                    ch.Width = 150;
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

        private void m_buscarcliente_list_DoubleClick(object sender, EventArgs e)
        {
            this.cliente = m_buscarcliente_list.SelectedItems[0].SubItems[0].Text;
            this.Close();
        }

        public override string ToString()
        {
            return cliente;
        }

        
    }
}
