using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;

namespace JM_Sistema_Prestamo
{
    public partial class clientenuevoForm : Form
    {
        public clientenuevoForm()
        {
            InitializeComponent();
            loadZona();
        }

        private void clientenuevoForm_Load(object sender, EventArgs e)
        {

        }

        public void loadZona()
        {
            Cliente c = new Cliente(); 
            SqlDataReader zona = c.getZona();
            ArrayList zonalist = new ArrayList();
            while (zona.Read())
            {   
                zonalist.Add(new AddValue(zona["ZO_NOMBRE"].ToString(),zona["ZO_CODIGO"].ToString()));
            }
            zona.Close();
            zonacb.DataSource = zonalist;
            zonacb.DisplayMember = "Display";
            zonacb.ValueMember = "Value" ;
        }

           
        private void cl_grabarbtn_Click(object sender, EventArgs e)
        {

            if (cl_nombretxt.Text != "" && cl_codigotxt.Text != "")
            {
                Cliente c = new Cliente();
                c.CODIGO = cl_codigotxt.Text;
                c.NOMBRE = cl_nombretxt.Text.ToUpper();
                c.DIREC1 = cl_direccion.Text.ToUpper();
                c.TELEF1 = cl_telefonotxt.Text;
                c.RAZON = cl_trabajotxt.Text.ToUpper();
                c.DIREC2 = cl_trabajo_dirtxt.Text.ToUpper();
                c.TELEF2 = cl_trabajo_teltxt.Text; 
                c.Z_CODIGO = zonacb.SelectedValue.ToString();
                c.CEDULA = cl_cedulatxt.Text;
                //no. pasaporto.
                c.TIPO = cl_tipotxt.Text;

                c.createClienteNuevo();
                MessageBox.Show("Cliente Grabado");
                //clear form after it was successfully saved to database
                cl_codigotxt.Text = "";
                cl_nombretxt.Text = "";
                cl_direccion.Text = "";
                cl_telefonotxt.Text = "";
                cl_trabajotxt.Text = "";
                cl_trabajo_dirtxt.Text = "";
                cl_trabajo_teltxt.Text = "";
                
                cl_cedulatxt.Text = "";
            }
            else
            {
                MessageBox.Show("Favor de entrar nombre del cliente y  codigo.",
		                        "Error ",
		                        MessageBoxButtons.OK,
		                        MessageBoxIcon.Error);
            }

        }

       

      
    }
}
