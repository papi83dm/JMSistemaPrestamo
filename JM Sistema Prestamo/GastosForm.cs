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
    public partial class GastosForm : Form
    {
        private Gastos gasto;

        public GastosForm()
        {
            gasto = new Gastos();
            InitializeComponent();
            fechatext.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        public void LoadGastosForm(string gid)
        {
            gasto.Load(gid); 
            INITLoad();
        }

        private void INITLoad()
        {
            DateTime dateTemp = DateTime.Parse(gasto.FECHA);
            cantidadtext.Text = gasto.CANTIDAD.ToString();
            conceptotext.Text = gasto.CONCEPTO;
            detallestext.Text = gasto.DETALLE;
            fechatext.Text = dateTemp.ToString("dd-MM-yyyy");
            fechacal.SelectionStart = dateTemp;  
        }

        private void startDatebtn_Click(object sender, EventArgs e)
        {
            fechacal.Visible = true;
        }

        private void fechacal_DateSelected(object sender, DateRangeEventArgs e)
        {
            fechatext.Text = e.Start.ToString("dd-MM-yyyy");
            fechacal.Visible = false;
        }

        private void isNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void cantidadtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void anadirbutton_Click(object sender, EventArgs e)
        {
            if (cantidadtext.Text != String.Empty && detallestext.Text != String.Empty && cantidadtext.Text != String.Empty)
            {
                gasto.CANTIDAD = Double.Parse(cantidadtext.Text);
                gasto.CONCEPTO = conceptotext.Text;
                gasto.DETALLE = detallestext.Text;
                gasto.FECHA = fechacal.SelectionStart.ToString("MM-dd-yyyy");
                if (gasto.GASTOID == 0)
                {
                    gasto.Nuevo();
                }
                else
                {
                    gasto.Grabar();
                }

                MessageBox.Show("Gasto fue anadito, Gracias");
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor no dejar nada vacio. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
         
         
    }
}
