using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace JM_Sistema_Prestamo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MdiChildActivate(object sender,
                                      EventArgs e)
        {

          
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            // If no any child form, hide tabControl 

            else
            {
                this.ActiveMdiChild.WindowState =
                FormWindowState.Maximized;
                // Child form always maximized 


                // If child form is new and no has tabPage, 

                // create new tabPage 

                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 

                    // form caption 

                    TabPage tp = new TabPage(this.ActiveMdiChild
                                             .Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(
                                        ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;

            }
        }

        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_SelectedIndexChanged(object sender,
                                           EventArgs e)
        {
            
            if ((tabForms.SelectedTab != null) &&
                (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientenuevoForm cnf = new clientenuevoForm();
            cnf.MdiParent = this;
            cnf.Show();
        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ClienteLista clf = new ClienteLista(this);
            clf.MdiParent = this;
            clf.Show();
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            HomePage home = new HomePage();
            home.MdiParent = this;
            home.Show();
        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            ClienteBuscar clb = new ClienteBuscar(this);
            clb.MdiParent = this;
            clb.Show();
        }

        private void ingresoDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoMensual im = new IngresoMensual("mensual");
            im.MdiParent = this;
            im.Show();
        }

        private void ingresoDeHoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoMensual im = new IngresoMensual("hoy");
            im.MdiParent = this;
            im.Show();
        }

        private void hacerPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrestamoNuevo pnf = new PrestamoNuevo();
            pnf.MdiParent = this;
            pnf.Show();
        }

        private void cuotasPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuotaPendienteReporte cuotaPen = new CuotaPendienteReporte();
            cuotaPen.MdiParent = this;
            cuotaPen.Show();
        }

        private void anadirGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GastosForm gastoF = new GastosForm();
            gastoF.Show();
        }

        private void gastosOperacionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GastosReporte gr = new GastosReporte();
            gr.MdiParent =  this;
            gr.Show();
        }

        private void cuentaPorClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceClientes balCliente = new BalanceClientes();
            balCliente.MdiParent = this;
            balCliente.Show();
        }

        private void actualizarPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarPrestamo ap = new ActualizarPrestamo();
            ap.MdiParent = this;
            ap.Show();
        }

        

       
    }
}
