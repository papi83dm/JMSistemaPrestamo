using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace JM_Sistema_Prestamo
{
    public partial class GastosReporte : Form
    {
        public GastosReporte()
        {
            InitializeComponent();
        }

        private void startDatebtn_Click(object sender, EventArgs e)
        {
            mstartcal.Visible = true;
        }

        private void endDatebtn_Click(object sender, EventArgs e)
        {
            mendcal.Visible = true;
        }

        private void mstartcal_DateSelected(object sender, DateRangeEventArgs e)
        {
            mstartcal.Visible = false;
            startDatetxt.Text = e.Start.ToString("dd-MM-yyyy");
        }

        private void mendcal_DateChanged(object sender, DateRangeEventArgs e)
        {
            mendcal.Visible = false;
            endDatetxt.Text = e.Start.ToString("dd-MM-yyyy");
        }

        private void reportebtn_Click(object sender, EventArgs e)
        {
            string sDate = mstartcal.SelectionRange.Start.ToString("MM-dd-yyyy");
            string eDate = mendcal.SelectionRange.Start.ToString("MM-dd-yyyy");
            genReporte(sDate, eDate);
        }

        private void GastosReporte_Load(object sender, EventArgs e)
        {
            // date in SQL FORMAT yyyy-mm-day
            string sDate = DateTime.Now.ToString("MM-01-yyyy");
            string eDate = DateTime.Now.ToString("MM-dd-yyyy");
            //texfield display date on Dominican format
            startDatetxt.Text = DateTime.Now.ToString("01-MM-yyyy");
            endDatetxt.Text = DateTime.Now.ToString("dd-MM-yyyy");
            genReporte(sDate, eDate);
        }

        private void genReporte(string sdate, string edate)
        {
            Reportes re = new Reportes();
            DataTable dt = re.GastosOperacionalesReporte(sdate, edate);

            int[] colSize = { 60, 70, 200, 240,70 };
            FillList(this.m_list, dt, colSize);

            
        }

        private void FillList(ListView lista, DataTable table, int[] ColSize)
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
                        ch.Width = 80;
                    }
                }
                else
                {
                    ch.Width = 80;
                }


                lista.Columns.Add(ch);
                colcounter++;
            }

            // IMPORTE TOTAL COLUMN
            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "IMPORTE";
            ch2.Width = 80;
            lista.Columns.Add(ch2);

            // Rows
            double importetotal = 0;
            foreach (DataRow row in table.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = row[0].ToString();
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                item.SubItems.Add(row[3].ToString());
                item.SubItems.Add(row[4].ToString());
                importetotal += Double.Parse(row[4].ToString());
                item.SubItems.Add(importetotal.ToString());

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

        private void m_list_DoubleClick(object sender, EventArgs e)
        {
            string gid = m_list.SelectedItems[0].Text;
            GastosForm gasto = new GastosForm();
            gasto.LoadGastosForm(gid);
            gasto.MdiParent = this.MdiParent;
            gasto.Show();
        }

        private void exportbuton_Click(object sender, EventArgs e)
        {
             

        }

        private void m_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


      

         
    }
}
