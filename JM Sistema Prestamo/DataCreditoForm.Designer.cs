namespace JM_Sistema_Prestamo
{
    partial class DataCreditoForm
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
            this.exportbuton = new System.Windows.Forms.Button();
            this.reportebtn = new System.Windows.Forms.Button();
            this.dc_list = new PrintableListView.PrintableListView();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exportbuton
            // 
            this.exportbuton.Location = new System.Drawing.Point(206, 12);
            this.exportbuton.Name = "exportbuton";
            this.exportbuton.Size = new System.Drawing.Size(153, 26);
            this.exportbuton.TabIndex = 55;
            this.exportbuton.Text = "Exportacion a Excel";
            this.exportbuton.UseVisualStyleBackColor = true;
            this.exportbuton.Click += new System.EventHandler(this.exportbuton_Click);
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(12, 12);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(150, 26);
            this.reportebtn.TabIndex = 54;
            this.reportebtn.Text = "General Reporte";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click);
            // 
            // dc_list
            // 
            this.dc_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dc_list.CheckBoxes = true;
            this.dc_list.FitToPage = false;
            this.dc_list.FullRowSelect = true;
            this.dc_list.Location = new System.Drawing.Point(4, 57);
            this.dc_list.Name = "dc_list";
            this.dc_list.Size = new System.Drawing.Size(784, 505);
            this.dc_list.TabIndex = 53;
            this.dc_list.Title = "";
            this.dc_list.UseCompatibleStateImageBehavior = false;
            this.dc_list.View = System.Windows.Forms.View.Details;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(365, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(364, 13);
            this.label16.TabIndex = 56;
            this.label16.Text = "Este proceso se toma de 2 a 5 minutos, por favor ser paciente.";
            // 
            // DataCreditoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.exportbuton);
            this.Controls.Add(this.reportebtn);
            this.Controls.Add(this.dc_list);
            this.Name = "DataCreditoForm";
            this.Text = "Reporte Para DataCredito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportbuton;
        private System.Windows.Forms.Button reportebtn;
        private PrintableListView.PrintableListView dc_list;
        private System.Windows.Forms.Label label16;
    }
}