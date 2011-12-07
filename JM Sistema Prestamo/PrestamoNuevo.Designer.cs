namespace JM_Sistema_Prestamo
{
    partial class PrestamoNuevo
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
            this.fechatxt = new System.Windows.Forms.TextBox();
            this.startDatebtn = new System.Windows.Forms.Button();
            this.fechacal = new System.Windows.Forms.MonthCalendar();
            this.codigotxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.capitaltxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.interestxt = new System.Windows.Forms.TextBox();
            this.cuotatxt = new System.Windows.Forms.TextBox();
            this.FormadePagocb = new System.Windows.Forms.ComboBox();
            this.distribucioncb = new System.Windows.Forms.ComboBox();
            this.buscarClientebtn = new System.Windows.Forms.Button();
            this.nombretxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pcuotasilb = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ptotalilb = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pinteresilb = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pcapitalilb = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.brabarPrestamo = new System.Windows.Forms.Button();
            this.m_list = new PrintableListView.PrintableListView();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechatxt
            // 
            this.fechatxt.Enabled = false;
            this.fechatxt.Location = new System.Drawing.Point(0, 15);
            this.fechatxt.Name = "fechatxt";
            this.fechatxt.Size = new System.Drawing.Size(100, 20);
            this.fechatxt.TabIndex = 35;
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(109, 16);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 34;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // fechacal
            // 
            this.fechacal.Location = new System.Drawing.Point(109, 79);
            this.fechacal.Name = "fechacal";
            this.fechacal.TabIndex = 1;
            this.fechacal.Visible = false;
            this.fechacal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.fechacal_DateChanged);
            // 
            // codigotxt
            // 
            this.codigotxt.Enabled = false;
            this.codigotxt.Location = new System.Drawing.Point(0, 58);
            this.codigotxt.Name = "codigotxt";
            this.codigotxt.Size = new System.Drawing.Size(100, 20);
            this.codigotxt.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Cliente";
            // 
            // capitaltxt
            // 
            this.capitaltxt.Location = new System.Drawing.Point(150, 15);
            this.capitaltxt.Name = "capitaltxt";
            this.capitaltxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.capitaltxt.Size = new System.Drawing.Size(70, 20);
            this.capitaltxt.TabIndex = 39;
            this.capitaltxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.capitaltxt_KeyPress);
            this.capitaltxt.Leave += new System.EventHandler(this.capitaltxt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(150, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Capital";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(230, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Taza de Interes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(330, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Cantidad de Cuotas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(575, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Garante";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(450, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Tipo De Garantia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(450, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Forma De Pago";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(550, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Distribucion";
            // 
            // interestxt
            // 
            this.interestxt.Location = new System.Drawing.Point(230, 15);
            this.interestxt.Name = "interestxt";
            this.interestxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.interestxt.Size = new System.Drawing.Size(93, 20);
            this.interestxt.TabIndex = 49;
            this.interestxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.interestxt_KeyPress);
            this.interestxt.Leave += new System.EventHandler(this.interestxt_Leave);
            // 
            // cuotatxt
            // 
            this.cuotatxt.Location = new System.Drawing.Point(330, 15);
            this.cuotatxt.Name = "cuotatxt";
            this.cuotatxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cuotatxt.Size = new System.Drawing.Size(114, 20);
            this.cuotatxt.TabIndex = 50;
            this.cuotatxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuotatxt_KeyPress);
            this.cuotatxt.Leave += new System.EventHandler(this.cuotatxt_Leave);
            // 
            // FormadePagocb
            // 
            this.FormadePagocb.DisplayMember = "0";
            this.FormadePagocb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormadePagocb.FormattingEnabled = true;
            this.FormadePagocb.Location = new System.Drawing.Point(452, 16);
            this.FormadePagocb.Name = "FormadePagocb";
            this.FormadePagocb.Size = new System.Drawing.Size(92, 21);
            this.FormadePagocb.TabIndex = 53;
            this.FormadePagocb.ValueMember = "0";
            this.FormadePagocb.SelectedValueChanged += new System.EventHandler(this.FormadePagocb_SelectedValueChanged);
            // 
            // distribucioncb
            // 
            this.distribucioncb.DisplayMember = "0";
            this.distribucioncb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distribucioncb.FormattingEnabled = true;
            this.distribucioncb.Location = new System.Drawing.Point(553, 15);
            this.distribucioncb.Name = "distribucioncb";
            this.distribucioncb.Size = new System.Drawing.Size(92, 21);
            this.distribucioncb.TabIndex = 54;
            this.distribucioncb.ValueMember = "0";
            // 
            // buscarClientebtn
            // 
            this.buscarClientebtn.Location = new System.Drawing.Point(110, 58);
            this.buscarClientebtn.Name = "buscarClientebtn";
            this.buscarClientebtn.Size = new System.Drawing.Size(25, 20);
            this.buscarClientebtn.TabIndex = 55;
            this.buscarClientebtn.Text = "...";
            this.buscarClientebtn.UseVisualStyleBackColor = true;
            this.buscarClientebtn.Click += new System.EventHandler(this.buscarClientebtn_Click);
            // 
            // nombretxt
            // 
            this.nombretxt.Enabled = false;
            this.nombretxt.Location = new System.Drawing.Point(147, 58);
            this.nombretxt.Name = "nombretxt";
            this.nombretxt.Size = new System.Drawing.Size(150, 20);
            this.nombretxt.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(147, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Nombre";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pcuotasilb);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.ptotalilb);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.pinteresilb);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.pcapitalilb);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(412, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 121);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detalles";
            // 
            // pcuotasilb
            // 
            this.pcuotasilb.AutoSize = true;
            this.pcuotasilb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcuotasilb.ForeColor = System.Drawing.Color.Black;
            this.pcuotasilb.Location = new System.Drawing.Point(70, 60);
            this.pcuotasilb.Name = "pcuotasilb";
            this.pcuotasilb.Size = new System.Drawing.Size(13, 13);
            this.pcuotasilb.TabIndex = 33;
            this.pcuotasilb.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(6, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Cuotas..:";
            // 
            // ptotalilb
            // 
            this.ptotalilb.AutoSize = true;
            this.ptotalilb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptotalilb.ForeColor = System.Drawing.Color.Black;
            this.ptotalilb.Location = new System.Drawing.Point(70, 80);
            this.ptotalilb.Name = "ptotalilb";
            this.ptotalilb.Size = new System.Drawing.Size(13, 13);
            this.ptotalilb.TabIndex = 31;
            this.ptotalilb.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Navy;
            this.label24.Location = new System.Drawing.Point(6, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Total.....:";
            // 
            // pinteresilb
            // 
            this.pinteresilb.AutoSize = true;
            this.pinteresilb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinteresilb.ForeColor = System.Drawing.Color.Black;
            this.pinteresilb.Location = new System.Drawing.Point(70, 40);
            this.pinteresilb.Name = "pinteresilb";
            this.pinteresilb.Size = new System.Drawing.Size(13, 13);
            this.pinteresilb.TabIndex = 27;
            this.pinteresilb.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(6, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Interes..:";
            // 
            // pcapitalilb
            // 
            this.pcapitalilb.AutoSize = true;
            this.pcapitalilb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcapitalilb.ForeColor = System.Drawing.Color.Black;
            this.pcapitalilb.Location = new System.Drawing.Point(70, 20);
            this.pcapitalilb.Name = "pcapitalilb";
            this.pcapitalilb.Size = new System.Drawing.Size(13, 13);
            this.pcapitalilb.TabIndex = 25;
            this.pcapitalilb.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(6, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Capital..:";
            // 
            // brabarPrestamo
            // 
            this.brabarPrestamo.Location = new System.Drawing.Point(412, 241);
            this.brabarPrestamo.Name = "brabarPrestamo";
            this.brabarPrestamo.Size = new System.Drawing.Size(115, 24);
            this.brabarPrestamo.TabIndex = 59;
            this.brabarPrestamo.Text = "Grabar Prestamo";
            this.brabarPrestamo.UseVisualStyleBackColor = true;
            this.brabarPrestamo.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(3, 95);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(403, 253);
            this.m_list.TabIndex = 32;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            // 
            // PrestamoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.brabarPrestamo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.nombretxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buscarClientebtn);
            this.Controls.Add(this.distribucioncb);
            this.Controls.Add(this.FormadePagocb);
            this.Controls.Add(this.cuotatxt);
            this.Controls.Add(this.interestxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.capitaltxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codigotxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechatxt);
            this.Controls.Add(this.startDatebtn);
            this.Controls.Add(this.fechacal);
            this.Controls.Add(this.m_list);
            this.Name = "PrestamoNuevo";
            this.Text = "Prestamo Nuevo";
            this.Load += new System.EventHandler(this.PrestamoNuevo_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fechatxt;
        private System.Windows.Forms.Button startDatebtn;
        private System.Windows.Forms.MonthCalendar fechacal;
        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.TextBox codigotxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox capitaltxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox interestxt;
        private System.Windows.Forms.TextBox cuotatxt;
        private System.Windows.Forms.ComboBox FormadePagocb;
        private System.Windows.Forms.ComboBox distribucioncb;
        private System.Windows.Forms.Button buscarClientebtn;
        private System.Windows.Forms.TextBox nombretxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label pcuotasilb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label ptotalilb;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label pinteresilb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label pcapitalilb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button brabarPrestamo;
    }
}