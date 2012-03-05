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
    public partial class ActualizarPrestamo : Form
    {
        public ActualizarPrestamo()
        {
            InitializeComponent();
        }

        private void isNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void actualizarBackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Reportes re = new Reportes();

            //set all capven and intven to 0
            re.UpdateAllPrestamoCapVen();

            // procesar semanales primero.
            if ( semanalTexBox.Text != "")
            {
                double dia = -1 * Double.Parse(semanalTexBox.Text);
                DateTime hoy = DateTime.Now.AddDays(dia);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = re.getPrestamoMoraList(hoy.ToString("yyyy-MM-dd"), "S");
                adapter.Fill(ds);
                
                int counter = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                { 
                    ProcesarCuotas(row["PRESTAMO"].ToString(),hoy.ToString("yyyy-MM-dd"),semanalCheckBox.Checked);
                    
                    
                    counter++;
                }

            }

            if (diarioTextBox.Text != "")
            {
                double dia = -1 * Double.Parse(diarioTextBox.Text);
                DateTime hoy = DateTime.Now.AddDays(dia);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = re.getPrestamoMoraList(hoy.ToString("yyyy-MM-dd"), "D");
                adapter.Fill(ds);

                int counter = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ProcesarCuotas(row["PRESTAMO"].ToString(), hoy.ToString("yyyy-MM-dd"),diarioCheckBox.Checked);


                    counter++;
                }

            }

            if (quincenalTexBox.Text != "")
            {
                double dia = -1 * Double.Parse(quincenalTexBox.Text);
                DateTime hoy = DateTime.Now.AddDays(dia);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = re.getPrestamoMoraList(hoy.ToString("yyyy-MM-dd"), "Q");
                adapter.Fill(ds);

                int counter = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ProcesarCuotas(row["PRESTAMO"].ToString(), hoy.ToString("yyyy-MM-dd"), quincenalCheckBox.Checked);


                    counter++;
                }

            }

            if (mensualTexBox.Text != "")
            {
                int dia = -1 * int.Parse(mensualTexBox.Text);
                DateTime hoy = DateTime.Now.AddDays(dia);
                DataSet ds = new DataSet(); 
                SqlDataAdapter adapter = re.getPrestamoMoraList(hoy.ToString("yyyy-MM-dd"), "M");
                adapter.Fill(ds);

                int counter = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ProcesarCuotas(row["PRESTAMO"].ToString(), hoy.ToString("yyyy-MM-dd"), mensualCheckBox.Checked);
                    


                    counter++;
                }

            }

        }

        private void actualizarBackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.UserState;
            m_list.Items.Add(item);
            
        }

        private void actualizarBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            m_list.ResumeLayout();
            reportebtn.Enabled = true;
            MessageBox.Show("Prestamos han sido actualizados");
        }

        private void reportebtn_Click(object sender, EventArgs e)
        {
            reportebtn.Enabled = false;

            m_list.SuspendLayout();

            // Clear list
            m_list.Items.Clear();
            m_list.Columns.Clear();

            // load list column
            // Prestamos Columns
            m_list.Columns.Add("ID", 60);
            m_list.Columns.Add("Prestamo", 70);
            m_list.Columns.Add("Cuotas", 60);
            m_list.Columns.Add("Codigo", 90);
            m_list.Columns.Add("Nombre", 300);
            m_list.Columns.Add("Capital", 70);
            m_list.Columns.Add("Mora", 70);
            actualizarBackgroundWorker1.RunWorkerAsync();
        }

    
        public void ProcesarCuotas(string pid, string fecha,bool domora)
        {
            Reportes re = new Reportes();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = re.getPrestamoMoraCuotas(fecha, pid);
            adapter.Fill(ds);
            
            double totalmora = 0;
            double capven = 0;
            double intven = 0; 
            int counter = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            { 
                ListViewItem item = new ListViewItem();
                item.Text = row["HISTORIAID"].ToString();
                item.SubItems.Add(row["PRESTAMOID"].ToString());
                item.SubItems.Add(row["Cuota"].ToString());
                item.SubItems.Add(row["CL_CODIGO"].ToString());
                item.SubItems.Add(row["CL_NOMBRE"].ToString());
                item.SubItems.Add(row["Capital"].ToString());
                double mora = 0;
                double interes = 0;
                
                if (Double.TryParse(row["Capital"].ToString(), out mora))
                {
                    capven += mora;
                    mora = Math.Floor(mora * 0.05);
                    totalmora += mora;

                    item.SubItems.Add(mora.ToString());

                }

                if (Double.TryParse(row["Interes"].ToString(), out interes))
                {
                    intven += interes;
                     
                }

                if (domora)
                {
                   
                     re.setUpdateCuotaMora(row["HISTORIAID"].ToString(), mora);
                    actualizarBackgroundWorker1.ReportProgress(counter, item);
                   

                }
                counter++;
            }

            if (domora)
            {
               
                re.setUpdatePrestamoMora(pid, totalmora);
            }

            re.setUpdatePrestamoCapVen(pid, capven, intven);


        }

         


        private void diarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void semanalTexBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void quincenalTexBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void mensualTexBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }



    }
}
