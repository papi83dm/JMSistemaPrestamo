namespace JM_Sistema_Prestamo
{
    partial class CuotaPendienteReporte
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
            this.m_list = new PrintableListView.PrintableListView();
            this.bintereslabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bcapitallabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.interestlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.capitallabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(313, 20);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(58, 20);
            this.reportebtn.TabIndex = 42;
            this.reportebtn.Text = "Reporte";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click_1);
            // 
            // endDatetxt
            // 
            this.endDatetxt.Enabled = false;
            this.endDatetxt.Location = new System.Drawing.Point(156, 23);
            this.endDatetxt.Name = "endDatetxt";
            this.endDatetxt.Size = new System.Drawing.Size(100, 20);
            this.endDatetxt.TabIndex = 41;
            // 
            // startDatetxt
            // 
            this.startDatetxt.Enabled = false;
            this.startDatetxt.Location = new System.Drawing.Point(19, 21);
            this.startDatetxt.Name = "startDatetxt";
            this.startDatetxt.Size = new System.Drawing.Size(100, 20);
            this.startDatetxt.TabIndex = 40;
            // 
            // mendcal
            // 
            this.mendcal.Location = new System.Drawing.Point(156, 43);
            this.mendcal.Name = "mendcal";
            this.mendcal.TabIndex = 39;
            this.mendcal.Visible = false;
            this.mendcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mendcal_DateChanged);
            // 
            // endDatebtn
            // 
            this.endDatebtn.Location = new System.Drawing.Point(262, 21);
            this.endDatebtn.Name = "endDatebtn";
            this.endDatebtn.Size = new System.Drawing.Size(25, 20);
            this.endDatebtn.TabIndex = 38;
            this.endDatebtn.Text = "...";
            this.endDatebtn.UseVisualStyleBackColor = true;
            this.endDatebtn.Click += new System.EventHandler(this.endDatebtn_Click);
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(125, 21);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 37;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // mstartcal
            // 
            this.mstartcal.Location = new System.Drawing.Point(41, 43);
            this.mstartcal.Name = "mstartcal";
            this.mstartcal.TabIndex = 36;
            this.mstartcal.Visible = false;
            this.mstartcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mstartcal_DateChanged);
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(673, 34);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 35;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(19, 63);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(755, 484);
            this.m_list.TabIndex = 34;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            // 
            // bintereslabel
            // 
            this.bintereslabel.AutoSize = true;
            this.bintereslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bintereslabel.ForeColor = System.Drawing.Color.Black;
            this.bintereslabel.Location = new System.Drawing.Point(600, 550);
            this.bintereslabel.Name = "bintereslabel";
            this.bintereslabel.Size = new System.Drawing.Size(13, 13);
            this.bintereslabel.TabIndex = 50;
            this.bintereslabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(528, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "B. Interes:";
            // 
            // bcapitallabel
            // 
            this.bcapitallabel.AutoSize = true;
            this.bcapitallabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcapitallabel.ForeColor = System.Drawing.Color.Black;
            this.bcapitallabel.Location = new System.Drawing.Point(289, 550);
            this.bcapitallabel.Name = "bcapitallabel";
            this.bcapitallabel.Size = new System.Drawing.Size(13, 13);
            this.bcapitallabel.TabIndex = 48;
            this.bcapitallabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(217, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "B. Capital:";
            // 
            // interestlabel
            // 
            this.interestlabel.AutoSize = true;
            this.interestlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestlabel.ForeColor = System.Drawing.Color.Black;
            this.interestlabel.Location = new System.Drawing.Point(441, 550);
            this.interestlabel.Name = "interestlabel";
            this.interestlabel.Size = new System.Drawing.Size(13, 13);
            this.interestlabel.TabIndex = 46;
            this.interestlabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(391, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Interes:";
            // 
            // capitallabel
            // 
            this.capitallabel.AutoSize = true;
            this.capitallabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitallabel.ForeColor = System.Drawing.Color.Black;
            this.capitallabel.Location = new System.Drawing.Point(119, 550);
            this.capitallabel.Name = "capitallabel";
            this.capitallabel.Size = new System.Drawing.Size(13, 13);
            this.capitallabel.TabIndex = 44;
            this.capitallabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(69, 550);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Capital:";
            // 
            // CuotaPendienteReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.bintereslabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bcapitallabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.interestlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.capitallabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.reportebtn);
            this.Controls.Add(this.endDatetxt);
            this.Controls.Add(this.startDatetxt);
            this.Controls.Add(this.mendcal);
            this.Controls.Add(this.endDatebtn);
            this.Controls.Add(this.startDatebtn);
            this.Controls.Add(this.mstartcal);
            this.Controls.Add(this.m_list);
            this.Controls.Add(this.printbtn);
            this.Name = "CuotaPendienteReporte";
            this.Text = "Cuotas Pendientes";
            this.Load += new System.EventHandler(this.CuotaPendienteReporte_Load);
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
        private System.Windows.Forms.Label bintereslabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bcapitallabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label interestlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label capitallabel;
        private System.Windows.Forms.Label label8;
    }
}