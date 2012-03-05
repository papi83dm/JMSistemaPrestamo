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
        private string RowChecked;

        public LlenarLista(ListView list, DataTable tab)
        {
            this.lista = list;
            this.table = tab; 
            RowChecked = "";
            FillList();
        }

        public LlenarLista(ListView list, DataTable tab, int[] col)
        {
            this.lista = list;
            this.table = tab;
            this.ColSize = col; 
            RowChecked = "";
            FillList();
        }

        public LlenarLista(ListView list, DataTable tab, int[] col,string rowC)
        {
            this.lista = list;
            this.table = tab;
            this.ColSize = col;
            this.RowChecked = rowC;
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

                //skip column to be checked.
                if (ch.Text != RowChecked)
                {
                    lista.Columns.Add(ch);
                    colcounter++;
                }
            }

            // Rows
            foreach (DataRow row in table.Rows)
            {
                ListViewItem item = new ListViewItem();
                int rownum = 1;

              
                if (RowChecked.Length>0)
                { 
                      rownum = 2;

                    //if row checked.
                    if (row[0].ToString() == "1")
                    {
                        item.Checked = true; 
                    }

                    item.Text = row[1].ToString();
                    
                }
                else
                {
                    item.Text = row[0].ToString();
                }

                for (int i = rownum; i < table.Columns.Count; i++)
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
