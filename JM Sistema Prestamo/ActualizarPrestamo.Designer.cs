namespace JM_Sistema_Prestamo
{
    partial class ActualizarPrestamo
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
            this.m_list = new PrintableListView.PrintableListView();
            this.diarioCheckBox = new System.Windows.Forms.CheckBox();
            this.semanalCheckBox = new System.Windows.Forms.CheckBox();
            this.quincenalCheckBox = new System.Windows.Forms.CheckBox();
            this.mensualCheckBox = new System.Windows.Forms.CheckBox();
            this.diarioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.semanalTexBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.quincenalTexBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mensualTexBox = new System.Windows.Forms.TextBox();
            this.actualizarBackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // reportebtn
            // 
            this.reportebtn.Location = new System.Drawing.Point(667, 5);
            this.reportebtn.Name = "reportebtn";
            this.reportebtn.Size = new System.Drawing.Size(58, 20);
            this.reportebtn.TabIndex = 53;
            this.reportebtn.Text = "Procesar";
            this.reportebtn.UseVisualStyleBackColor = true;
            this.reportebtn.Click += new System.EventHandler(this.reportebtn_Click);
            // 
            // m_list
            // 
            this.m_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_list.FitToPage = false;
            this.m_list.FullRowSelect = true;
            this.m_list.Location = new System.Drawing.Point(19, 126);
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(755, 421);
            this.m_list.TabIndex = 52;
            this.m_list.Title = "";
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.View = System.Windows.Forms.View.Details;
            // 
            // diarioCheckBox
            // 
            this.diarioCheckBox.AutoSize = true;
            this.diarioCheckBox.Checked = true;
            this.diarioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.diarioCheckBox.Location = new System.Drawing.Point(19, 12);
            this.diarioCheckBox.Name = "diarioCheckBox";
            this.diarioCheckBox.Size = new System.Drawing.Size(134, 17);
            this.diarioCheckBox.TabIndex = 54;
            this.diarioCheckBox.Text = "Diario: Mora a Partir de";
            this.diarioCheckBox.UseVisualStyleBackColor = true;
            // 
            // semanalCheckBox
            // 
            this.semanalCheckBox.AutoSize = true;
            this.semanalCheckBox.Checked = true;
            this.semanalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.semanalCheckBox.Location = new System.Drawing.Point(19, 35);
            this.semanalCheckBox.Name = "semanalCheckBox";
            this.semanalCheckBox.Size = new System.Drawing.Size(148, 17);
            this.semanalCheckBox.TabIndex = 55;
            this.semanalCheckBox.Text = "Semanal: Mora a Partir de";
            this.semanalCheckBox.UseVisualStyleBackColor = true;
            // 
            // quincenalCheckBox
            // 
            this.quincenalCheckBox.AutoSize = true;
            this.quincenalCheckBox.Checked = true;
            this.quincenalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quincenalCheckBox.Location = new System.Drawing.Point(19, 58);
            this.quincenalCheckBox.Name = "quincenalCheckBox";
            this.quincenalCheckBox.Size = new System.Drawing.Size(155, 17);
            this.quincenalCheckBox.TabIndex = 56;
            this.quincenalCheckBox.Text = "Quincenal: Mora a Partir de";
            this.quincenalCheckBox.UseVisualStyleBackColor = true;
            // 
            // mensualCheckBox
            // 
            this.mensualCheckBox.AutoSize = true;
            this.mensualCheckBox.Checked = true;
            this.mensualCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mensualCheckBox.Location = new System.Drawing.Point(19, 81);
            this.mensualCheckBox.Name = "mensualCheckBox";
            this.mensualCheckBox.Size = new System.Drawing.Size(147, 17);
            this.mensualCheckBox.TabIndex = 57;
            this.mensualCheckBox.Text = "Mensual: Mora a Partir de";
            this.mensualCheckBox.UseVisualStyleBackColor = true;
            // 
            // diarioTextBox
            // 
            this.diarioTextBox.Location = new System.Drawing.Point(172, 10);
            this.diarioTextBox.Name = "diarioTextBox";
            this.diarioTextBox.Size = new System.Drawing.Size(23, 20);
            this.diarioTextBox.TabIndex = 58;
            this.diarioTextBox.Text = "2";
            this.diarioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.diarioTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "dias en atraso.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "dias en atraso.";
            // 
            // semanalTexBox
            // 
            this.semanalTexBox.Location = new System.Drawing.Point(172, 33);
            this.semanalTexBox.Name = "semanalTexBox";
            this.semanalTexBox.Size = new System.Drawing.Size(23, 20);
            this.semanalTexBox.TabIndex = 60;
            this.semanalTexBox.Text = "2";
            this.semanalTexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.semanalTexBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "dias en atraso.";
            // 
            // quincenalTexBox
            // 
            this.quincenalTexBox.Location = new System.Drawing.Point(172, 57);
            this.quincenalTexBox.Name = "quincenalTexBox";
            this.quincenalTexBox.Size = new System.Drawing.Size(23, 20);
            this.quincenalTexBox.TabIndex = 62;
            this.quincenalTexBox.Text = "2";
            this.quincenalTexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quincenalTexBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "dias  en atraso.";
            // 
            // mensualTexBox
            // 
            this.mensualTexBox.Location = new System.Drawing.Point(172, 80);
            this.mensualTexBox.Name = "mensualTexBox";
            this.mensualTexBox.Size = new System.Drawing.Size(23, 20);
            this.mensualTexBox.TabIndex = 64;
            this.mensualTexBox.Text = "2";
            this.mensualTexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mensualTexBox_KeyPress);
            // 
            // actualizarBackgroundWorker1
            // 
            this.actualizarBackgroundWorker1.WorkerReportsProgress = true;
            this.actualizarBackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.actualizarBackgroundWorker1_DoWork);
            this.actualizarBackgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.actualizarBackgroundWorker1_ProgressChanged);
            this.actualizarBackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.actualizarBackgroundWorker1_RunWorkerCompleted);
            // 
            // ActualizarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mensualTexBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quincenalTexBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.semanalTexBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diarioTextBox);
            this.Controls.Add(this.mensualCheckBox);
            this.Controls.Add(this.quincenalCheckBox);
            this.Controls.Add(this.semanalCheckBox);
            this.Controls.Add(this.diarioCheckBox);
            this.Controls.Add(this.reportebtn);
            this.Controls.Add(this.m_list);
            this.Name = "ActualizarPrestamo";
            this.Text = "ActualizarPrestamo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reportebtn;
        private PrintableListView.PrintableListView m_list;
        private System.Windows.Forms.CheckBox diarioCheckBox;
        private System.Windows.Forms.CheckBox semanalCheckBox;
        private System.Windows.Forms.CheckBox quincenalCheckBox;
        private System.Windows.Forms.CheckBox mensualCheckBox;
        private System.Windows.Forms.TextBox diarioTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox semanalTexBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quincenalTexBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mensualTexBox;
        private System.ComponentModel.BackgroundWorker actualizarBackgroundWorker1;
    }
}