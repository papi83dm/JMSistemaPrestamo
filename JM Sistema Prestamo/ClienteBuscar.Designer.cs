namespace JM_Sistema_Prestamo
{
    partial class ClienteBuscar
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
            this.bcnombretxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bccodigotxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_buscarcliente_list = new PrintableListView.PrintableListView();
            this.SuspendLayout();
            // 
            // bcnombretxt
            // 
            this.bcnombretxt.Location = new System.Drawing.Point(183, 25);
            this.bcnombretxt.Name = "bcnombretxt";
            this.bcnombretxt.Size = new System.Drawing.Size(250, 20);
            this.bcnombretxt.TabIndex = 0;
            this.bcnombretxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bcnombretxt_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            // 
            // bccodigotxt
            // 
            this.bccodigotxt.Location = new System.Drawing.Point(15, 25);
            this.bccodigotxt.Name = "bccodigotxt";
            this.bccodigotxt.Size = new System.Drawing.Size(150, 20);
            this.bccodigotxt.TabIndex = 1;
            this.bccodigotxt.TextChanged += new System.EventHandler(this.bccodigotxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cedula";
            // 
            // m_buscarcliente_list
            // 
            this.m_buscarcliente_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buscarcliente_list.FitToPage = false;
            this.m_buscarcliente_list.FullRowSelect = true;
            this.m_buscarcliente_list.Location = new System.Drawing.Point(15, 62);
            this.m_buscarcliente_list.Name = "m_buscarcliente_list";
            this.m_buscarcliente_list.Size = new System.Drawing.Size(708, 488);
            this.m_buscarcliente_list.TabIndex = 8;
            this.m_buscarcliente_list.Title = "";
            this.m_buscarcliente_list.UseCompatibleStateImageBehavior = false;
            this.m_buscarcliente_list.View = System.Windows.Forms.View.Details;
            this.m_buscarcliente_list.DoubleClick += new System.EventHandler(this.m_buscarcliente_list_DoubleClick);
            // 
            // ClienteBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.m_buscarcliente_list);
            this.Controls.Add(this.bcnombretxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bccodigotxt);
            this.Controls.Add(this.label1);
            this.Name = "ClienteBuscar";
            this.Text = "Buscar Clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bcnombretxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bccodigotxt;
        private System.Windows.Forms.Label label1;
        private PrintableListView.PrintableListView m_buscarcliente_list;
        private Form1 form1;
    }
}