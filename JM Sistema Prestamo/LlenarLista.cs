using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{
    class LlenarLista
    {
        private ListView lista;
        private DataTable table;
        private int[] ColSize;
        private int colDefaultsize = 80;

        public LlenarLista(ListView list, DataTable tab)
        {
            this.lista = list;
            this.table = tab;
            FillList();
        }

        public LlenarLista(ListView list, DataTable tab, int[] col)
        {
            this.lista = list;
            this.table = tab;
            this.ColSize = col;
            FillList();
        }

        private void FillList()
        {
            lista.SuspendLayout();

            // Clear list
            lista.Items.Clear();
            lista.Columns.Clear();

            int colcounter = 0;
            // Columns
            foreach (DataColumn col in table.Columns)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = col.Caption;
                if (IsNumeric(col.DataType))
                    ch.TextAlign = HorizontalAlignment.Right;

                if (ColSize != null)
                {
                    if (colcounter < ColSize.Length)
                    {
                        ch.Width = ColSize[colcounter];
                    }
                    else
                    {
                        ch.Width = colDefaultsize;
                    }
                }
                else
                {
                    ch.Width = colDefaultsize;
                }

                
                lista.Columns.Add(ch);
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
                lista.Items.Add(item);
            }

            //  list.ResumeLayout();
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
    }
}
