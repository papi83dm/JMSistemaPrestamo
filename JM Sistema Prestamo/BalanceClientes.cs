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
    public partial class BalanceClientes : Form
    {
        public BalanceClientes()
        {
            InitializeComponent();
        }

        private void BalanceClientes_Load(object sender, EventArgs e)
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
            DataTable dt = re.BalanceClienteReporte();

            int[] colSize = { 100, 350, 100 };
            LlenarLista listaLLena = new LlenarLista(this.m_list, dt, colSize);

            SqlDataReader ingreso = re.BalanceClienteReporteSUMA();
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

                double capitalstr = 0.00;
                double interesstr = 0.00;
                double bcapitalstr = 0.00;
                double binteresstr = 0.00;

                if (ingreso["Capital"].ToString() != "")
                {
                    capitalstr = Double.Parse(ingreso["Capital"].ToString());
                }
               


                capitallabel.Text = String.Format("{0:C}", capitalstr);
               
            }
            this.m_list.Items.Add(item);
            this.m_list.ResumeLayout();
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

        private void startDatebtn_Click(object sender, EventArgs e)
        {
            mstartcal.Visible = true;
        }

        private void endDatebtn_Click(object sender, EventArgs e)
        {
            mendcal.Visible = true;
        }

        private void reportebtn_Click(object sender, EventArgs e)
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
