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
    public partial class CuotaPendienteReporte : Form
    {
        public CuotaPendienteReporte()
        {
            InitializeComponent();
        }

        private void CuotaPendienteReporte_Load(object sender, EventArgs e)
        {
            // date in SQL FORMAT yyyy-mm-day
            string sDate = DateTime.Now.ToString("MM-01-yyyy");
            string eDate = DateTime.Now.ToString("MM-dd-yyyy");
            //texfield display date on Dominican format
            startDatetxt.Text = DateTime.Now.ToString("01-MM-yyyy");
            endDatetxt.Text = DateTime.Now.ToString("dd-MM-yyyy"); 
            genReporte(sDate, eDate);

        }

        private void reportebtn_Click(object sender, EventArgs e)
        {
            string sDate = mstartcal.SelectionRange.Start.Year + "-" + mstartcal.SelectionRange.Start.Month + "-" + mstartcal.SelectionRange.Start.Day;
            string eDate = mendcal.SelectionRange.Start.Year + "-" + mendcal.SelectionRange.Start.Month + "-" + mendcal.SelectionRange.Start.Day;
            //title = "Listado de Ingreso " + sDate + " a " + eDate;
            genReporte(sDate, eDate);

        }

        private void genReporte(string sdate, string edate)
        { 
            Reportes re = new Reportes();
            DataTable dt = re.CuotasPendientesReporte(sdate, edate); 

            int[] colSize = {80,180,70,60};
            LlenarLista listaLLena = new LlenarLista(this.m_list,dt,colSize);

            SqlDataReader ingreso = re.CuotasPendientesReporteSUMA(sdate, edate);
            ////populate total
            this.m_list.SuspendLayout();
            ListViewItem item = new ListViewItem();
            item.Text = "TOTAL";
            item.SubItems.Add("-");
            item.SubItems.Add("-");
            item.SubItems.Add("-");

            if (ingreso.Read())
            {
                item.SubItems.Add(ingreso["Capital"].ToString()); //capital  
                item.SubItems.Add(ingreso["BCAPITAL"].ToString()); //mora
                item.SubItems.Add(ingreso["Interes"].ToString()); //interes
                item.SubItems.Add(ingreso["BInteres"].ToString()); //interes

                double capitalstr = 0.00;
                double interesstr = 0.00;
                double bcapitalstr = 0.00;
                double binteresstr = 0.00;

                if (ingreso["Capital"].ToString() != "")
                {
                    capitalstr = Double.Parse(ingreso["Capital"].ToString());
                }
                if (ingreso["BCapital"].ToString() != "")
                {
                    bcapitalstr = Double.Parse(ingreso["BCapital"].ToString());
                }
                if (ingreso["Interes"].ToString() != "")
                {
                    interesstr = Double.Parse(ingreso["Interes"].ToString());
                }
                if (ingreso["BInteres"].ToString() != "")
                {
                    binteresstr = Double.Parse(ingreso["BInteres"].ToString());
                }
               

                capitallabel.Text = String.Format("{0:C}", capitalstr);
                bcapitallabel.Text = String.Format("{0:C}", bcapitalstr);
                interestlabel.Text = String.Format("{0:C}", interesstr); 
                bintereslabel.Text = String.Format("{0:C}", binteresstr);
            }
            this.m_list.Items.Add(item);
            this.m_list.ResumeLayout();
        }

        private void startDatebtn_Click(object sender, EventArgs e)
        {
            mstartcal.Visible = true;
        }

        private void endDatebtn_Click(object sender, EventArgs e)
        {
            mendcal.Visible = true;
        }

        private void mstartcal_DateChanged(object sender, DateRangeEventArgs e)
        {
            mstartcal.Visible = false;
            startDatetxt.Text = e.Start.ToString("dd-MM-yyyy");
        }

        private void mendcal_DateChanged(object sender, DateRangeEventArgs e)
        {
            mendcal.Visible = false;
            endDatetxt.Text = e.Start.ToString("dd-MM-yyyy");
        }

        private void reportebtn_Click_1(object sender, EventArgs e)
        {
            string sDate = mstartcal.SelectionRange.Start.ToString("MM-dd-yyyy");
            string eDate = mendcal.SelectionRange.Start.ToString("MM-dd-yyyy"); 
            genReporte(sDate, eDate);
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            Font tFont = m_list.Font;
            m_list.Font = new System.Drawing.Font("Courier New", 7);
            m_list.Title = this.Text; 
            m_list.FitToPage = true;
            m_list.Print();
            m_list.Font = tFont;
        } 
    }
}
