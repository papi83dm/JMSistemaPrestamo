﻿namespace JM_Sistema_Prestamo
{
    partial class IngresoMensual
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
            this.m_list = new PrintableListView.PrintableListView();
            this.printbtn = new System.Windows.Forms.Button();
            this.mstartcal = new System.Windows.Forms.MonthCalendar();
            this.startDatebtn = new System.Windows.Forms.Button();
            this.endDatebtn = new System.Windows.Forms.Button();
            this.interestlb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.moralb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mendcal = new System.Windows.Forms.MonthCalendar();
            this.startDatetxt = new System.Windows.Forms.TextBox();
            this.endDatetxt = new System.Windows.Forms.TextBox();
            this.reportebtn = new System.Windows.Forms.Button();
            this.capitallb = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.totallb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(17, 52);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(755, 484);
            this.m_list.TabIndex = 8;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            this.m_list.SelectedIndexChanged += new System.EventHandler(this.m_list_SelectedIndexChanged);
            // 
            // printbtn
            // 
            this.printbtn.Location = new System.Drawing.Point(671, 23);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 9;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // mstartcal
            // 
            this.mstartcal.Location = new System.Drawing.Point(38, 47);
            this.mstartcal.Name = "mstartcal";
            this.mstartcal.TabIndex = 10;
            this.mstartcal.Visible = false;
            this.mstartcal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mstartcal_DateChanged);
            this.mstartcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcalen1_DateSelected);
            // 
            // startDatebtn
            // 
            this.startDatebtn.Location = new System.Drawing.Point(123, 10);
            this.startDatebtn.Name = "startDatebtn";
            this.startDatebtn.Size = new System.Drawing.Size(25, 20);
            this.startDatebtn.TabIndex = 11;
            this.startDatebtn.Text = "...";
            this.startDatebtn.UseVisualStyleBackColor = true;
            this.startDatebtn.Click += new System.EventHandler(this.startDatebtn_Click);
            // 
            // endDatebtn
            // 
            this.endDatebtn.Location = new System.Drawing.Point(260, 10);
            this.endDatebtn.Name = "endDatebtn";
            this.endDatebtn.Size = new System.Drawing.Size(25, 20);
            this.endDatebtn.TabIndex = 12;
            this.endDatebtn.Text = "...";
            this.endDatebtn.UseVisualStyleBackColor = true;
            this.endDatebtn.Click += new System.EventHandler(this.endDatebtn_Click);
            // 
            // interestlb
            // 
            this.interestlb.AutoSize = true;
            this.interestlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestlb.ForeColor = System.Drawing.Color.Black;
            this.interestlb.Location = new System.Drawing.Point(250, 539);
            this.interestlb.Name = "interestlb";
            this.interestlb.Size = new System.Drawing.Size(13, 13);
            this.interestlb.TabIndex = 27;
            this.interestlb.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(200, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Interes:";
            // 
            // moralb
            // 
            this.moralb.AutoSize = true;
            this.moralb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moralb.ForeColor = System.Drawing.Color.Black;
            this.moralb.Location = new System.Drawing.Point(390, 540);
            this.moralb.Name = "moralb";
            this.moralb.Size = new System.Drawing.Size(13, 13);
            this.moralb.TabIndex = 29;
            this.moralb.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(350, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Mora:";
            // 
            // mendcal
            // 
            this.mendcal.Location = new System.Drawing.Point(119, 47);
            this.mendcal.Name = "mendcal";
            this.mendcal.TabIndex = 30;
            this.mendcal.Visible = false;
            this.mendcal.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mendcal_DateSelected);
            // 
            // startDatetxt
            // 
            this.startDatetxt.Enabled = false;
            this.startDatetxt.Location = new System.Drawing.Point(17, 10);
            this.startDatetxt.Name = "startDatetxt";
            this.startDatetxt.Size = new System.Drawing.Size(100, 20);
            this.startDatetxt.TabIndex = 31;
            this.startDatetxt.TextChanged += new System.EventHandler(this.startDatetxt_TextChanged);
            // 
            // endDatetxt
            // 
            this.endDatetxt.Enabled = false;
            this.endDatetxt.Location = new System.Drawing.Point(154, 12);
            this.endDatetxt.Name = "endDatetxt";
            this.endDatetxt.Size = new System.Drawing.Size(100, 20);
            this.endDatetxt.TabIndex = 32;
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(311, 9);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(58, 20);
            this.reportebtn.TabIndex = 33;
            this.reportebtn.Text = "Reporte";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click);
            // 
            // capitallb
            // 
            this.capitallb.AutoSize = true;
            this.capitallb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitallb.ForeColor = System.Drawing.Color.Black;
            this.capitallb.Location = new System.Drawing.Point(100, 540);
            this.capitallb.Name = "capitallb";
            this.capitallb.Size = new System.Drawing.Size(13, 13);
            this.capitallb.TabIndex = 25;
            this.capitallb.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(50, 540);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Capital:";
            // 
            // totallb
            // 
            this.totallb.AutoSize = true;
            this.totallb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totallb.ForeColor = System.Drawing.Color.Black;
            this.totallb.Location = new System.Drawing.Point(540, 540);
            this.totallb.Name = "totallb";
            this.totallb.Size = new System.Drawing.Size(13, 13);
            this.totallb.TabIndex = 35;
            this.totallb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(500, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Total:";
            // 
            // IngresoMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.totallb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportebtn);
            this.Controls.Add(this.endDatetxt);
            this.Controls.Add(this.startDatetxt);
            this.Controls.Add(this.mendcal);
            this.Controls.Add(this.moralb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.interestlb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.capitallb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.endDatebtn);
            this.Controls.Add(this.startDatebtn);
            this.Controls.Add(this.mstartcal);
            this.Controls.Add(this.m_list);
            this.Controls.Add(this.printbtn);
            this.Name = "IngresoMensual";
            this.Text = "Ingreso Mensuales";
            this.Load += new System.EventHandler(this.IngresoMensual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.Button printbtn;
        private System.Windows.Forms.MonthCalendar mstartcal;
        private System.Windows.Forms.Button startDatebtn;
        private System.Windows.Forms.Button endDatebtn;
        private System.Windows.Forms.Label interestlb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label moralb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar mendcal;
        private System.Windows.Forms.TextBox startDatetxt;
        private System.Windows.Forms.TextBox endDatetxt;
        private System.Windows.Forms.Button reportebtn;
        private System.Windows.Forms.Label capitallb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totallb;
        private System.Windows.Forms.Label label3;
    }
}