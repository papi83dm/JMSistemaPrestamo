using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection; 

namespace JM_Sistema_Prestamo
{
    public partial class DataCreditoForm : Form
    {
        public DataCreditoForm()
        {
            InitializeComponent();
        }

        private void reportebtn_Click(object sender, EventArgs e)
        {
            Reportes re = new Reportes();
            DataTable dt = re.DataCreditoReporte();
            
            int[] colSize = { 80,80,200, 150, 80,80 };
            LlenarLista listaLLena = new LlenarLista(this.dc_list, dt, colSize);
        }

        private void exportbuton_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet; 

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                int hcounter = 1;
                //Add table headers going cell by cell.
                foreach (ColumnHeader colh in dc_list.Columns)
                {
                    oSheet.Cells[1, hcounter] = colh.Text;
                    hcounter++;
                }
                oSheet.Cells[1, hcounter] = "TIPO PRESTAMO";
                oSheet.Cells[1, hcounter + 1] = "DESCRIPCION";


                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "O1").Font.Bold = true;
                oSheet.get_Range("A1", "O1").Interior.ColorIndex = 33;
                oSheet.get_Range("A1", "O1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "O1").EntireColumn.NumberFormat = "@";



                // Create an array to multiple values at once.
                int lastrow = dc_list.Items.Count;
                string[,] saNames = new string[lastrow, dc_list.Items[0].SubItems.Count];

                
                int rcounter = 0;
                foreach (ListViewItem item in dc_list.Items)
                {
                    
                    //skip checked items
                    if (!item.Checked)
                    {
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            //oSheet.Cells[rcounter,i+1] = item.SubItems[i].Text.ToString();  
                            saNames[rcounter, i] = item.SubItems[i].Text.ToString(); 
                        }
                        rcounter++;
                    }
                }
             

                //Fill A2:B6 
                //Fill A2:B6 with an array of values (First and Last Names).
                string str = "M"+ lastrow;
                oSheet.get_Range("A2", str).Value2 = saNames;
                oSheet.get_Range("A1", "O1").EntireColumn.AutoFit();

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.StackTrace);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
