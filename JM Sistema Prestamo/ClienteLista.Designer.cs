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
            this.printPreviewbtn = new System.Windows.Forms.Button();
            this.printbtn = new System.Windows.Forms.Button();
            this.pagesetupbtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.listaHoytp = new System.Windows.Forms.TabPage();
            this.m_list = new PrintableListView.PrintableListView();
            this.listaatrasotp = new System.Windows.Forms.TabPage();
            this.m_listaatraso = new PrintableListView.PrintableListView();
            this.inactivotp = new System.Windows.Forms.TabPage();
            this.inactivolistview = new PrintableListView.PrintableListView();
            this.tabControl1.SuspendLayout();
            this.listaHoytp.SuspendLayout();
            this.listaatrasotp.SuspendLayout();
            this.inactivotp.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewbtn
            // 
            this.printPreviewbtn.Location = new System.Drawing.Point(17, 6);
            this.printPreviewbtn.Name = "printPreviewbtn";
            this.printPreviewbtn.Size = new System.Drawing.Size(110, 23);
            this.printPreviewbtn.TabIndex = 0;
            this.printPreviewbtn.Text = "Vista Previa";
            this.printPreviewbtn.UseVisualStyleBackColor = true;
            this.printPreviewbtn.Click += new System.EventHandler(this.printPreviewbtn_Click);
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(214, 6);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 5;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pagesetupbtn
            // 
            this.pagesetupbtn.Location = new System.Drawing.Point(133, 6);
            this.pagesetupbtn.Name = "pagesetupbtn";
            this.pagesetupbtn.Size = new System.Drawing.Size(75, 23);
            this.pagesetupbtn.TabIndex = 6;
            this.pagesetupbtn.Text = "Page Setup";
            this.pagesetupbtn.UseVisualStyleBackColor = true;
            this.pagesetupbtn.Click += new System.EventHandler(this.pagesetupbtn_Click);
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
            this.listaHoytp.Controls.Add(this.m_list);
            this.listaHoytp.Controls.Add(this.printbtn);
            this.listaHoytp.Controls.Add(this.pagesetupbtn);
            this.listaHoytp.Controls.Add(this.printPreviewbtn);
            this.listaHoytp.Location = new System.Drawing.Point(4, 22);
            this.listaHoytp.Name = "listaHoytp";
            this.listaHoytp.Padding = new System.Windows.Forms.Padding(3);
            this.listaHoytp.Size = new System.Drawing.Size(776, 539);
            this.listaHoytp.TabIndex = 0;
            this.listaHoytp.Text = "Lista de Hoy";
            this.listaHoytp.UseVisualStyleBackColor = true;
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
            // listaatrasotp
            // 
            this.listaatrasotp.Controls.Add(this.m_listaatraso);
            this.listaatrasotp.Location = new System.Drawing.Point(4, 22);
            this.listaatrasotp.Name = "listaatrasotp";
            this.listaatrasotp.Padding = new System.Windows.Forms.Padding(3);
            this.listaatrasotp.Size = new System.Drawing.Size(776, 539);
            this.listaatrasotp.TabIndex = 1;
            this.listaatrasotp.Text = "Lista de Atraso";
            this.listaatrasotp.UseVisualStyleBackColor = true;
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
            this.listaatrasotp.ResumeLayout(false);
            this.inactivotp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printPreviewbtn;
        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.Button printbtn;
        private Form1 form1;
        private System.Windows.Forms.Button pagesetupbtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage listaHoytp;
        private System.Windows.Forms.TabPage listaatrasotp;
        private PrintableListView.PrintableListView m_listaatraso;
        private System.Windows.Forms.TabPage inactivotp;
        private PrintableListView.PrintableListView inactivolistview;



    }
}