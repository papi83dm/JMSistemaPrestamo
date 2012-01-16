namespace JM_Sistema_Prestamo
{
    partial class GastosForm
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
            this.detallestext = new System.Windows.Forms.TextBox();
            this.cantidadtext = new System.Windows.Forms.TextBox();
            this.conceptotext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fechatext = new System.Windows.Forms.TextBox();
            this.startDatebtn = new System.Windows.Forms.Button();
            this.anadirbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fechacal = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // detallestext
            // 
            this.detallestext.Location = new System.Drawing.Point(70, 100);
            this.detallestext.MaxLength = 149;
            this.detallestext.Name = "detallestext";
            this.detallestext.Size = new System.Drawing.Size(300, 20);
            this.detallestext.TabIndex = 2;
            // 
            // cantidadtext
            // 
            this.cantidadtext.Location = new System.Drawing.Point(70, 140);
            this.cantidadtext.Name = "cantidadtext";
            this.cantidadtext.Size = new System.Drawing.Size(100, 20);
            this.cantidadtext.TabIndex = 3;
            this.cantidadtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadtext_KeyPress);
            // 
            // conceptotext
            // 
            this.conceptotext.Location = new System.Drawing.Point(70, 60);
            this.conceptotext.MaxLength = 149;
            this.conceptotext.Name = "conceptotext";
            this.conceptotext.Size = new System.Drawing.Size(300, 20);
            this.conceptotext.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Fecha";
            // 
            // fechatext
            // 
            this.fechatext.Enabled = false;
            this.fechatext.Location = new System.Drawing.Point(70, 20);
            this.fechatext.Name = "fechatext";
            this.fechatext.Size = new System.Drawing.Size(100, 20);
            this.fechatext.TabIndex = 0;
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(180, 20);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 36;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // anadirbutton
            // 
            this.anadirbutton.Location = new System.Drawing.Point(90, 194);
            this.anadirbutton.Name = "anadirbutton";
            this.anadirbutton.Size = new System.Drawing.Size(124, 20);
            this.anadirbutton.TabIndex = 5;
            this.anadirbutton.Text = "Anadir";
            this.anadirbutton.UseVisualStyleBackColor = true;
            this.anadirbutton.Click += new System.EventHandler(this.anadirbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(0, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Concepto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(0, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Detalle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(0, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Cantidad";
            // 
            // fechacal
            // 
            this.fechacal.Location = new System.Drawing.Point(126, 38);
            this.fechacal.Name = "fechacal";
            this.fechacal.TabIndex = 42;
            this.fechacal.Visible = false;
            this.fechacal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.fechacal_DateSelected);
            // 
            // GastosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 263);
            this.Controls.Add(this.fechacal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anadirbutton);
            this.Controls.Add(this.fechatext);
            this.Controls.Add(this.startDatebtn);
            this.Controls.Add(this.detallestext);
            this.Controls.Add(this.cantidadtext);
            this.Controls.Add(this.conceptotext);
            this.Controls.Add(this.label1);
            this.Name = "GastosForm";
            this.Text = "Anadir Gastos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox detallestext;
        private System.Windows.Forms.TextBox cantidadtext;
        private System.Windows.Forms.TextBox conceptotext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fechatext;
        private System.Windows.Forms.Button startDatebtn;
        private System.Windows.Forms.Button anadirbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar fechacal;
    }
}