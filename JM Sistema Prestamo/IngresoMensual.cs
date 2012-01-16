using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JM_Sistema_Prestamo
{
    public partial class IngresoMensual : Form
    {
        private string typo;
        private string title;
        public IngresoMensual(string t)
        {
            InitializeComponent();
            typo = t;
        }

        private void IngresoMensual_Load(object sender, EventArgs e)
        {
            // date in SQL FORMAT yyyy-mm-day
            string sDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            string eDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;

            //texfield display date on Dominican format
            startDatetxt.Text = "01" + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            endDatetxt.Text = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

            if (typo == "mensual")
            {
                genReporte(sDate, eDate);
                this.Text = "Ingreso Mensuales";
                title = "Listado de Ingreso " + startDatetxt.Text + " a " + endDatetxt.Text;
            }
            else if (typo == "hoy")
            {
                genReporte(eDate, eDate);
                startDatebtn.Visible = false;
                startDatetxt.Visible = false;
                endDatebtn.Visible = false;
                endDatetxt.Visible = false;
                reportebtn.Visible = false;
                this.Text = "Ingreso de Hoy";
                title = "Listado de Ingreso de Hoy " + eDate;
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
                if (colcounter == 3)
                {
                    ch.Width = 270;
                }
                else if (colcounter == 4)
                {
                    ch.Width = 60;
                }
                else if (colcounter == 2)
                {
                    ch.Width = 60;
                }
                
                else
                {
                    ch.Width = 80;
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

        
        private void startDatebtn_Click(object sender, EventArgs e)
        {
            mstartcal.Visible = true;
        }

        private void mcalen1_DateSelected(object sender, DateRangeEventArgs e)
        {
            mstartcal.Visible = false;
            startDatetxt.Text = e.Start.Day +"-"+ e.Start.Month +"-" + e.Start.Year; 
        }

        private void endDatebtn_Click(object sender, EventArgs e)
        {
            mendcal.Visible = true;
        }

        private void mendcal_DateSelected(object sender, DateRangeEventArgs e)
        {
            mendcal.Visible = false;
            endDatetxt.Text = e.Start.Day + "-" + e.Start.Month + "-" + e.Start.Year; 
        }

        private void reportebtn_Click(object sender, EventArgs e)
        {
            string sDate = mstartcal.SelectionRange.Start.Year +"-" +mstartcal.SelectionRange.Start.Month + "-" + mstartcal.SelectionRange.Start.Day;
            string eDate = mendcal.SelectionRange.Start.Year + "-" + mendcal.SelectionRange.Start.Month + "-" + mendcal.SelectionRange.Start.Day;
            title = "Listado de Ingreso " + sDate + " a " + eDate;
            genReporte(sDate,eDate);
            
        }

        private void genReporte(string sdate, string edate)
        {
            Cliente c = new Cliente();
            DataTable dt = c.IngresoMensual(sdate, edate);
            // clienteListalv. = dt; 
            int[] colsize = {90,70,250,60,90,90,90 };
            LlenarLista llenar = new LlenarLista(this.m_list, dt,colsize);
            //FillList(this.m_list, dt);

            SqlDataReader ingreso = c.IngresoMensualSuma(sdate, edate);
            //populate total
            ListViewItem item = new ListViewItem();
            item.Text = "TOTAL"; 
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            if (ingreso.Read())
            {
                item.SubItems.Add(ingreso["Capital"].ToString()); //capital 
                item.SubItems.Add(ingreso["Interes"].ToString()); //interes
               // item.SubItems.Add(ingreso["Mora"].ToString()); //mora place holder
                item.SubItems.Add(ingreso["Monto"].ToString());
               
                double capitalstr = 0.00;
                double interesstr = 0.00;
                double morastr = 0.00;
                double t = 0.00;

                if (ingreso["Capital"].ToString() != "")
                {
                    capitalstr = Double.Parse(ingreso["Capital"].ToString());
                }
                if (ingreso["Interes"].ToString() != "")
                {
                    interesstr = Double.Parse(ingreso["Interes"].ToString());
                }
                if (ingreso["Mora"].ToString() != "")
                {
                    morastr = Double.Parse(ingreso["Mora"].ToString());
                }

                capitallb.Text = String.Format("{0:C}", capitalstr);
                interestlb.Text = String.Format("{0:C}", interesstr);
                moralb.Text = String.Format("{0:C}", morastr);
                t = capitalstr + interesstr + morastr; 
                totallb.Text = String.Format("{0:C}", t);
            }
            this.m_list.Items.Add(item); 
            this.m_list.ResumeLayout();
        }


        private void printbtn_Click(object sender, EventArgs e)
        {

            m_list.Title = title;
            m_list.Font = new System.Drawing.Font("Courier New", 9);
            m_list.FitToPage = true; 
            m_list.Print();
        }

        private void startDatetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void mstartcal_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void m_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
