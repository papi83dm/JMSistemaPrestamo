namespace JM_Sistema_Prestamo
{
    partial class ClienteLista
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
            this.printbtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.listaHoytp = new System.Windows.Forms.TabPage();
            this.listaatrasotp = new System.Windows.Forms.TabPage();
            this.atrasoImprimirButton = new System.Windows.Forms.Button();
            this.inactivotp = new System.Windows.Forms.TabPage();
            this.reportebtn = new System.Windows.Forms.Button();
            this.fechatxt = new System.Windows.Forms.TextBox();
            this.startDatebtn = new System.Windows.Forms.Button();
            this.fechacal = new System.Windows.Forms.MonthCalendar();
            this.m_list = new PrintableListView.PrintableListView();
            this.m_listaatraso = new PrintableListView.PrintableListView();
            this.inactivolistview = new PrintableListView.PrintableListView();
            this.tabControl1.SuspendLayout();
            this.listaHoytp.SuspendLayout();
            this.listaatrasotp.SuspendLayout();
            this.inactivotp.SuspendLayout();
            this.SuspendLayout();
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(621, 6);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 5;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.listaHoytp);
            this.tabControl1.Controls.Add(this.listaatrasotp);
            this.tabControl1.Controls.Add(this.inactivotp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 565);
            this.tabControl1.TabIndex = 7;
            // 
            // listaHoytp
            // 
            this.listaHoytp.Controls.Add(this.reportebtn);
            this.listaHoytp.Controls.Add(this.fechatxt);
            this.listaHoytp.Controls.Add(this.startDatebtn);
            this.listaHoytp.Controls.Add(this.fechacal);
            this.listaHoytp.Controls.Add(this.m_list);
            this.listaHoytp.Controls.Add(this.printbtn);
            this.listaHoytp.Location = new System.Drawing.Point(4, 22);
            this.listaHoytp.Name = "listaHoytp";
            this.listaHoytp.Padding = new System.Windows.Forms.Padding(3);
            this.listaHoytp.Size = new System.Drawing.Size(776, 539);
            this.listaHoytp.TabIndex = 0;
            this.listaHoytp.Text = "Lista de Hoy";
            this.listaHoytp.UseVisualStyleBackColor = true;
            // 
            // listaatrasotp
            // 
            this.listaatrasotp.Controls.Add(this.atrasoImprimirButton);
            this.listaatrasotp.Controls.Add(this.m_listaatraso);
            this.listaatrasotp.Location = new System.Drawing.Point(4, 22);
            this.listaatrasotp.Name = "listaatrasotp";
            this.listaatrasotp.Padding = new System.Windows.Forms.Padding(3);
            this.listaatrasotp.Size = new System.Drawing.Size(776, 539);
            this.listaatrasotp.TabIndex = 1;
            this.listaatrasotp.Text = "Lista de Atraso";
            this.listaatrasotp.UseVisualStyleBackColor = true;
            // 
            // atrasoImprimirButton
            // 
            this.atrasoImprimirButton.Location = new System.Drawing.Point(276, 3);
            this.atrasoImprimirButton.Name = "atrasoImprimirButton";
            this.atrasoImprimirButton.Size = new System.Drawing.Size(75, 23);
            this.atrasoImprimirButton.TabIndex = 6;
            this.atrasoImprimirButton.Text = "Imprimir";
            this.atrasoImprimirButton.UseVisualStyleBackColor = true;
            this.atrasoImprimirButton.Click += new System.EventHandler(this.atrasoImprimirButton_Click);
            // 
            // inactivotp
            // 
            this.inactivotp.Controls.Add(this.inactivolistview);
            this.inactivotp.Location = new System.Drawing.Point(4, 22);
            this.inactivotp.Name = "inactivotp";
            this.inactivotp.Padding = new System.Windows.Forms.Padding(3);
            this.inactivotp.Size = new System.Drawing.Size(776, 539);
            this.inactivotp.TabIndex = 2;
            this.inactivotp.Text = "Inactivo";
            this.inactivotp.UseVisualStyleBackColor = true;
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(143, 6);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(58, 20);
            this.reportebtn.TabIndex = 55;
            this.reportebtn.Text = "Reporte";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click);
            // 
            // fechatxt
            // 
            this.fechatxt.Enabled = false;
            this.fechatxt.Location = new System.Drawing.Point(6, 6);
            this.fechatxt.Name = "fechatxt";
            this.fechatxt.Size = new System.Drawing.Size(100, 20);
            this.fechatxt.TabIndex = 54;
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(112, 6);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 53;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // fechacal
            // 
            this.fechacal.Location = new System.Drawing.Point(28, 28);
            this.fechacal.Name = "fechacal";
            this.fechacal.TabIndex = 52;
            this.fechacal.Visible = false;
            this.fechacal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.fechacal_DateChanged);
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(6, 35);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(708, 488);
            this.m_list.TabIndex = 4;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            this.m_list.DoubleClick += new System.EventHandler(this.m_list_DoubleClick);
            // 
            // m_listaatraso
            // 
            this.m_listaatraso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listaatraso.FitToPage = false;
            this.m_listaatraso.FullRowSelect = true;
            this.m_listaatraso.Location = new System.Drawing.Point(8, 30);
            this.m_listaatraso.Name = "m_listaatraso";
            this.m_listaatraso.Size = new System.Drawing.Size(739, 488);
            this.m_listaatraso.TabIndex = 5;
            this.m_listaatraso.Title = "";
            this.m_listaatraso.UseCompatibleStateImageBehavior = false;
            this.m_listaatraso.View = System.Windows.Forms.View.Details;
            this.m_listaatraso.DoubleClick += new System.EventHandler(this.m_listaatraso_DoubleClick);
            // 
            // inactivolistview
            // 
            this.inactivolistview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inactivolistview.FitToPage = false;
            this.inactivolistview.FullRowSelect = true;
            this.inactivolistview.Location = new System.Drawing.Point(19, 25);
            this.inactivolistview.Name = "inactivolistview";
            this.inactivolistview.Size = new System.Drawing.Size(739, 488);
            this.inactivolistview.TabIndex = 6;
            this.inactivolistview.Title = "";
            this.inactivolistview.UseCompatibleStateImageBehavior = false;
            this.inactivolistview.View = System.Windows.Forms.View.Details;
            this.inactivolistview.DoubleClick += new System.EventHandler(this.inactivolistview_DoubleClick);
            // 
            // ClienteLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "ClienteLista";
            this.Text = "Listado De Cliente";
            this.Load += new System.EventHandler(this.ClienteLista_Load);
            this.tabControl1.ResumeLayout(false);
            this.listaHoytp.ResumeLayout(false);
            this.listaHoytp.PerformLayout();
            this.listaatrasotp.ResumeLayout(false);
            this.inactivotp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.Button printbtn;
        private Form1 form1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage listaHoytp;
        private System.Windows.Forms.TabPage listaatrasotp;
        private PrintableListView.PrintableListView m_listaatraso;
        private System.Windows.Forms.TabPage inactivotp;
        private PrintableListView.PrintableListView inactivolistview;
        private System.Windows.Forms.Button atrasoImprimirButton;
        private System.Windows.Forms.Button reportebtn;
        private System.Windows.Forms.TextBox fechatxt;
        private System.Windows.Forms.Button startDatebtn;
        private System.Windows.Forms.MonthCalendar fechacal;



    }
}