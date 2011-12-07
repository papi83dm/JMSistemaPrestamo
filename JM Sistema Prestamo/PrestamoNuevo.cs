using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JM_Sistema_Prestamo
{
    public partial class PrestamoNuevo : Form
    {
        private readonly double WEEKLY = 4.3;
        private readonly double SEMIMONTHLY = 2.0;
        private readonly double MONTHLY = 1.0;
        private readonly double DAILY = 30.0; 

        public PrestamoNuevo()
        {
            InitializeComponent();
        }

        private void startDatebtn_Click(object sender, EventArgs e)
        {
            fechacal.Visible = true;
        }

        private void fechacal_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechacal.Visible = false;
            fechatxt.Text = e.Start.Day + "-" + e.Start.Month + "-" + e.Start.Year; 
        }

        private void PrestamoNuevo_Load(object sender, EventArgs e)
        { 
            string todaystr = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            fechatxt.Text = todaystr;
            ArrayList fplist = new ArrayList();
            ArrayList dlist = new ArrayList();

            //load Forma de Pago values
            fplist.Add(new AddValue("Diario", "D"));
            fplist.Add(new AddValue("Semanal", "S"));
            fplist.Add(new AddValue("Quincenal", "Q"));
            fplist.Add(new AddValue("Mensual", "M"));
            FormadePagocb.DataSource = fplist;
            FormadePagocb.DisplayMember = "Display";
            FormadePagocb.ValueMember = "Value";

            //load Distribucion values
            dlist.Add(new AddValue("Fija", "S"));
            dlist.Add(new AddValue("Insoluta", "I"));
            dlist.Add(new AddValue("S. Insoluto", "F"));
            dlist.Add(new AddValue("No Dist", "N"));
            distribucioncb.DataSource = dlist;
            distribucioncb.DisplayMember = "Display";
            distribucioncb.ValueMember = "Value";
        }

        private void capitaltxt_Leave(object sender, EventArgs e)
        {
            GeneratePrestamo();
        }

        private void interestxt_Leave(object sender, EventArgs e)
        {
            GeneratePrestamo();
        }

        private void cuotatxt_Leave(object sender, EventArgs e)
        {
            GeneratePrestamo();
        }

        private void FormadePagocb_SelectedValueChanged(object sender, EventArgs e)
        {
            GeneratePrestamo();
        }

        private void GeneratePrestamo()
        {
            if (capitaltxt.Text != "" && interestxt.Text != "" && cuotatxt.Text != ""  && FormadePagocb.SelectedItem != null )
            {
                loadPrestamoCuotas(Double.Parse(capitaltxt.Text), Double.Parse(interestxt.Text), int.Parse(cuotatxt.Text), FormadePagocb.SelectedValue.ToString());
                 
            }
        }


        private void loadPrestamoCuotas(double capital, double taza, int cuota, string formadepago)
        {
            m_list.SuspendLayout();

            // Clear list
            m_list.Items.Clear();
            m_list.Columns.Clear();

            DateTime sDate = new DateTime(fechacal.SelectionRange.Start.Year, fechacal.SelectionRange.Start.Month, fechacal.SelectionRange.Start.Day);
            double interes = 0.00;

            // load list column

            m_list.Columns.Add("Cuota",50);
            m_list.Columns.Add("Fecha", 70);
            m_list.Columns.Add("Capital",90);
            m_list.Columns.Add("Interes",90);
            m_list.Columns.Add("Cuotas",90);


            for (int i = 1; i <= cuota; i++)
            {

                if (formadepago == "S")
                {
                    sDate = sDate.AddDays(7);
                    interes =  (capital * taza / 100) * (cuota / WEEKLY) ;
                }
                else if (formadepago == "Q")
                {
                    sDate = sDate.AddDays(15);
                    interes =  (capital * taza / 100) * (cuota / SEMIMONTHLY) ;
                }
                else if (formadepago == "M")
                {
                    sDate = sDate.AddMonths(1);
                    interes =  (capital * taza / 100) * (cuota / MONTHLY) ;
                }
                else if (formadepago == "D")
                {
                    sDate = sDate.AddDays(1);
                    interes =  (capital * taza / 100) * (cuota / DAILY) ;
                }


                ListViewItem item = new ListViewItem();
                item.Text = i + "/" + cuota;
                item.SubItems.Add(sDate.Day + "-" + sDate.Month + "-" + sDate.Year);
                item.SubItems.Add(String.Format("{0:C}", capital / cuota));
                item.SubItems.Add(String.Format("{0:C}", interes /cuota) );
                item.SubItems.Add(String.Format("{0:C}", (capital / cuota) + (interes / cuota)));
                m_list.Items.Add(item);
            }

            m_list.ResumeLayout();
            pcapitalilb.Text = String.Format("{0:C}", capital);
            pinteresilb.Text = String.Format("{0:C}", interes);
            pcuotasilb.Text = String.Format("{0:C}", (capital / cuota) + (interes / cuota));
            ptotalilb.Text = String.Format("{0:C}", (capital + interes));



        }

        private void capitaltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);

        }

        private void interestxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }
         
        private void cuotatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void isNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void buscarClientebtn_Click(object sender, EventArgs e)
        {
           
            BuscarClienteMini bcm = new BuscarClienteMini();
            bcm.ShowDialog(this);
            string c1 = bcm.ToString();
            bcm = null;
            if (c1 != null)
            {
                Cliente cl1 = new Cliente(c1);
                codigotxt.Text = cl1.CODIGO;
                nombretxt.Text = cl1.NOMBRE;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (capitaltxt.Text != "" && interestxt.Text != "" && cuotatxt.Text != "" && codigotxt.Text!="")
            {
                Cliente cli = new Cliente(codigotxt.Text);
                DateTime sDate = new DateTime(fechacal.SelectionRange.Start.Year, fechacal.SelectionRange.Start.Month, fechacal.SelectionRange.Start.Day);

                int cuotastr = int.Parse(cuotatxt.Text);
                double capitalstr = Double.Parse(capitaltxt.Text);
                double interesstr = Double.Parse(interestxt.Text);
                string formadepagostr = FormadePagocb.SelectedValue.ToString();
                string distribucionstr = distribucioncb.SelectedValue.ToString();
                int prestamoID = cli.HacerPrestamo(sDate, capitalstr, interesstr, cuotastr, formadepagostr, distribucionstr);

                MessageBox.Show("Presamo has sido Grabado.");
                // vaciar todo la field del formulario
                cuotatxt.Text = "";
                capitaltxt.Text = "";
                interestxt.Text = "";
                pcuotasilb.Text = "";
                codigotxt.Text = "";
                nombretxt.Text = "";
                pcapitalilb.Text = "";
                pinteresilb.Text = "";
                ptotalilb.Text = "";
                //clear list cuota
                m_list.Items.Clear();
                m_list.Columns.Clear();


            }
            else
            {
                MessageBox.Show("Por Favor no lo deje vacio.", "Capital, Interes, Taza oh Cliente. \r\n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

       
          
    }
}
