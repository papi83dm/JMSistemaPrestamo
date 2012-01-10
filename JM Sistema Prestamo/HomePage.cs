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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void loadIngresoHoy()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.IngresoMensualSuma(today, today);
            //populate total
          
            if (ingreso.Read())
            { 
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
                hoycapitallb.Text = String.Format("{0:N}", capitalstr);
                hoyintereslb.Text = String.Format("{0:N}", interesstr);
                hoymoralb.Text = String.Format("{0:N}", morastr);
                 
                t = capitalstr + interesstr + morastr;
                hoytotallb.Text = String.Format("{0:N}", t);
            }
            ingreso.Close();  
        }

        private void loadIngresoMes()
        {
            string todaymes = DateTime.Now.ToString("yyyy-MM-01");
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.IngresoMensualSuma(todaymes, today);
            //populate total

            if (ingreso.Read())
            {
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
                mescapitallb.Text = String.Format("{0:N}", capitalstr);
                mesintereslb.Text = String.Format("{0:N}", interesstr);
                mesmoralb.Text = String.Format("{0:N}", morastr);

                t = capitalstr + interesstr + morastr;
                mestotallb.Text = String.Format("{0:N}", t);
            }
            ingreso.Close();
        }

        private void loadIngresoAno()
        {
            string todaymes = DateTime.Now.ToString("yyyy-01-01");
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.IngresoMensualSuma(todaymes, today);
            //populate total

            if (ingreso.Read())
            {
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
                anocapitallb.Text = String.Format("{0:N}", capitalstr);
                anointereslb.Text = String.Format("{0:N}", interesstr);
                anomoralb.Text = String.Format("{0:N}", morastr);

                t = capitalstr + interesstr + morastr;
                anototallb.Text = String.Format("{0:N}", t);
            }
            ingreso.Close();
        }

        private void loadPrestamoHoy()
        {
             
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.PrestamoMensualSuma(today, today);
            //populate total

            if (ingreso.Read())
            {
                double totalsum = 0.00;

                if (ingreso["totalsum"].ToString() != "")
                {
                    totalsum = Double.Parse(ingreso["totalsum"].ToString());
                }

                phoyCantidadlb.Text = String.Format("{0:N}", totalsum);
                phoyCuentalb.Text = String.Format("{0:N}", ingreso["totalcount"].ToString());

            }
            ingreso.Close();
        }

        private void loadPrestamoMes()
        {
            string todaymes = DateTime.Now.ToString("yyyy-MM-01");
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.PrestamoMensualSuma(todaymes, today);
            //populate total

            if (ingreso.Read())
            {
                double totalsum = 0.00; 

                if (ingreso["totalsum"].ToString() != "")
                {
                    totalsum = Double.Parse(ingreso["totalsum"].ToString());
                }

                pmesCantidadlb.Text = String.Format("{0:N}", totalsum);
                pmesCuentalb.Text = String.Format("{0:N}", ingreso["totalcount"].ToString()); 

            }
            ingreso.Close();
        }

        private void loadPrestamoAno()
        {
            string todaymes = DateTime.Now.ToString("yyyy-01-01");
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            Cliente c = new Cliente();

            SqlDataReader ingreso = c.PrestamoMensualSuma(todaymes, today);
            //populate total

            if (ingreso.Read())
            {
                double totalsum = 0.00;

                if (ingreso["totalsum"].ToString() != "")
                {
                    totalsum = Double.Parse(ingreso["totalsum"].ToString());
                }

                panoCantidadlb.Text = String.Format("{0:N}", totalsum);
                panoCuentalb.Text = String.Format("{0:N}", ingreso["totalcount"].ToString());

            }

            ingreso.Close();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            loadPrestamoMes();
            loadPrestamoHoy();
            loadPrestamoAno();
            loadIngresoHoy();
            loadIngresoMes();
            loadIngresoAno();
        }

        private void actualizarBtn_Click(object sender, EventArgs e)
        {
            loadPrestamoMes();
            loadPrestamoHoy();
            loadPrestamoAno();
            loadIngresoHoy();
            loadIngresoMes();
            loadIngresoAno();
        }
    }
}
