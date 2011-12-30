namespace JM_Sistema_Prestamo
{
    partial class ReciboMini
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
            this.textfieldtxt = new System.Windows.Forms.TextBox();
            this.m_recibo_list = new ListViewEx.ListViewEx();
            this.grabarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textfieldtxt
            // 
            this.textfieldtxt.Location = new System.Drawing.Point(5, 315);
            this.textfieldtxt.Name = "textfieldtxt";
            this.textfieldtxt.Size = new System.Drawing.Size(99, 20);
            this.textfieldtxt.TabIndex = 15;
            this.textfieldtxt.Visible = false;
            // 
            // m_recibo_list
            // 
            this.m_recibo_list.AllowColumnReorder = true;
            this.m_recibo_list.DoubleClickActivation = false;
            this.m_recibo_list.FullRowSelect = true;
            this.m_recibo_list.Location = new System.Drawing.Point(5, 12);
            this.m_recibo_list.Name = "m_recibo_list";
            this.m_recibo_list.Size = new System.Drawing.Size(385, 297);
            this.m_recibo_list.TabIndex = 18;
            this.m_recibo_list.UseCompatibleStateImageBehavior = false;
            this.m_recibo_list.View = System.Windows.Forms.View.Details;
            this.m_recibo_list.SubItemClicked += new ListViewEx.SubItemEventHandler(this.m_recibo_list_SubItemClicked);
            // 
            // grabarBtn
            // 
            this.grabarBtn.Enabled = false;
            this.grabarBtn.Location = new System.Drawing.Point(285, 334);
            this.grabarBtn.Name = "grabarBtn";
            this.grabarBtn.Size = new System.Drawing.Size(75, 23);
            this.grabarBtn.TabIndex = 19;
            this.grabarBtn.Text = "Grabar";
            this.grabarBtn.UseVisualStyleBackColor = true;
            this.grabarBtn.Click += new System.EventHandler(this.grabarBtn_Click);
            // 
            // ReciboMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 362);
            this.Controls.Add(this.grabarBtn);
            this.Controls.Add(this.m_recibo_list);
            this.Controls.Add(this.textfieldtxt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReciboMini";
            this.Text = "Recibo";
            this.Load += new System.EventHandler(this.ReciboMini_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textfieldtxt;
        private ListViewEx.ListViewEx m_recibo_list;
        private System.Windows.Forms.Button grabarBtn;
    }
}