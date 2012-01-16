namespace JM_Sistema_Prestamo
{
    partial class GastosReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportebtn = new System.Windows.Forms.Button();
            this.endDatetxt = new System.Windows.Forms.TextBox();
            this.startDatetxt = new System.Windows.Forms.TextBox();
            this.mendcal = new System.Windows.Forms.MonthCalendar();
            this.endDatebtn = new System.Windows.Forms.Button();
            this.startDatebtn = new System.Windows.Forms.Button();
            this.mstartcal = new System.Windows.Forms.MonthCalendar();
            this.printbtn = new System.Windows.Forms.Button();
            this.exportbuton = new System.Windows.Forms.Button();
            this.m_list = new PrintableListView.PrintableListView();
            this.SuspendLayout();
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(307, 5);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(58, 26);
            this.reportebtn.TabIndex = 51;
            this.reportebtn.Text = "Reporte";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click);
            // 
            // endDatetxt
            // 
            this.endDatetxt.Enabled = false;
            this.endDatetxt.Location = new System.Drawing.Point(150, 5);
            this.endDatetxt.Name = "endDatetxt";
            this.endDatetxt.Size = new System.Drawing.Size(100, 20);
            this.endDatetxt.TabIndex = 50;
            // 
            // startDatetxt
            // 
            this.startDatetxt.Enabled = false;
            this.startDatetxt.Location = new System.Drawing.Point(13, 5);
            this.startDatetxt.Name = "startDatetxt";
            this.startDatetxt.Size = new System.Drawing.Size(100, 20);
            this.startDatetxt.TabIndex = 49;
            // 
            // mendcal
            // 
            this.mendcal.Location = new System.Drawing.Point(150, 29);
            this.mendcal.Name = "mendcal";
            this.mendcal.TabIndex = 48;
            this.mendcal.Visible = false;
            this.mendcal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mendcal_DateChanged);
            // 
            // endDatebtn
            // 
            this.endDatebtn.Location = new System.Drawing.Point(256, 5);
            this.endDatebtn.Name = "endDatebtn";
            this.endDatebtn.Size = new System.Drawing.Size(25, 20);
            this.endDatebtn.TabIndex = 47;
            this.endDatebtn.Text = "...";
            this.endDatebtn.UseVisualStyleBackColor = true;
            this.endDatebtn.Click += new System.EventHandler(this.endDatebtn_Click);
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(119, 5);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 46;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // mstartcal
            // 
            this.mstartcal.Location = new System.Drawing.Point(35, 29);
            this.mstartcal.Name = "mstartcal";
            this.mstartcal.TabIndex = 45;
            this.mstartcal.Visible = false;
            this.mstartcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mstartcal_DateSelected);
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(699, 5);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 26);
            this.printbtn.TabIndex = 44;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            // 
            // exportbuton
            // 
            this.exportbuton.Location = new System.Drawing.Point(699, 36);
            this.exportbuton.Name = "exportbuton";
            this.exportbuton.Size = new System.Drawing.Size(75, 26);
            this.exportbuton.TabIndex = 52;
            this.exportbuton.Text = "Exportacion";
            this.exportbuton.UseVisualStyleBackColor = true;
            this.exportbuton.Click += new System.EventHandler(this.exportbuton_Click);
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(19, 68);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(755, 495);
            this.m_list.TabIndex = 43;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            this.m_list.DoubleClick += new System.EventHandler(this.m_list_DoubleClick);
            // 
            // GastosReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.exportbuton);
            this.Controls.Add(this.reportebtn);
            this.Controls.Add(this.endDatetxt);
            this.Controls.Add(this.startDatetxt);
            this.Controls.Add(this.mendcal);
            this.Controls.Add(this.endDatebtn);
            this.Controls.Add(this.startDatebtn);
            this.Controls.Add(this.mstartcal);
            this.Controls.Add(this.m_list);
            this.Controls.Add(this.printbtn);
            this.Name = "GastosReporte";
            this.Text = "Gastos Operacionales";
            this.Load += new System.EventHandler(this.GastosReporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reportebtn;
        private System.Windows.Forms.TextBox endDatetxt;
        private System.Windows.Forms.TextBox startDatetxt;
        private System.Windows.Forms.MonthCalendar mendcal;
        private System.Windows.Forms.Button endDatebtn;
        private System.Windows.Forms.Button startDatebtn;
        private System.Windows.Forms.MonthCalendar mstartcal;
        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.Button printbtn;
        private System.Windows.Forms.Button exportbuton;
    }
}