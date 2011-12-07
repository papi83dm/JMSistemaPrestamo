namespace JM_Sistema_Prestamo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabForms = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.edicionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.garanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacerPrestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasYReportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDeHoyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoDelMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(784, 20);
            this.tabForms.TabIndex = 1;
            this.tabForms.Visible = false;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edicionesToolStripMenuItem,
            this.transaccionesToolStripMenuItem,
            this.consultasYReportesToolStripMenuItem,
            this.utilitariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // edicionesToolStripMenuItem
            // 
            this.edicionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.zonasToolStripMenuItem,
            this.garanteToolStripMenuItem});
            this.edicionesToolStripMenuItem.Name = "edicionesToolStripMenuItem";
            this.edicionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.edicionesToolStripMenuItem.Text = "Ediciones";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // zonasToolStripMenuItem
            // 
            this.zonasToolStripMenuItem.Name = "zonasToolStripMenuItem";
            this.zonasToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.zonasToolStripMenuItem.Text = "Zonas";
            // 
            // garanteToolStripMenuItem
            // 
            this.garanteToolStripMenuItem.Name = "garanteToolStripMenuItem";
            this.garanteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.garanteToolStripMenuItem.Text = "Garante";
            // 
            // transaccionesToolStripMenuItem
            // 
            this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hacerPrestamoToolStripMenuItem});
            this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
            this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.transaccionesToolStripMenuItem.Text = "Transacciones";
            // 
            // hacerPrestamoToolStripMenuItem
            // 
            this.hacerPrestamoToolStripMenuItem.Name = "hacerPrestamoToolStripMenuItem";
            this.hacerPrestamoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hacerPrestamoToolStripMenuItem.Text = "Prestamos";
            this.hacerPrestamoToolStripMenuItem.Click += new System.EventHandler(this.hacerPrestamoToolStripMenuItem_Click);
            // 
            // consultasYReportesToolStripMenuItem
            // 
            this.consultasYReportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeClientesToolStripMenuItem,
            this.buscarClienteToolStripMenuItem,
            this.ingresoDeHoyToolStripMenuItem,
            this.ingresoDelMesToolStripMenuItem});
            this.consultasYReportesToolStripMenuItem.Name = "consultasYReportesToolStripMenuItem";
            this.consultasYReportesToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.consultasYReportesToolStripMenuItem.Text = "Consultas Y Reportes";
            // 
            // listaDeClientesToolStripMenuItem
            // 
            this.listaDeClientesToolStripMenuItem.Name = "listaDeClientesToolStripMenuItem";
            this.listaDeClientesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.listaDeClientesToolStripMenuItem.Text = "Lista de Clientes";
            this.listaDeClientesToolStripMenuItem.Click += new System.EventHandler(this.listaDeClientesToolStripMenuItem_Click);
            // 
            // buscarClienteToolStripMenuItem
            // 
            this.buscarClienteToolStripMenuItem.Name = "buscarClienteToolStripMenuItem";
            this.buscarClienteToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.buscarClienteToolStripMenuItem.Text = "Buscar Cliente";
            this.buscarClienteToolStripMenuItem.Click += new System.EventHandler(this.buscarClienteToolStripMenuItem_Click);
            // 
            // ingresoDeHoyToolStripMenuItem
            // 
            this.ingresoDeHoyToolStripMenuItem.Name = "ingresoDeHoyToolStripMenuItem";
            this.ingresoDeHoyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ingresoDeHoyToolStripMenuItem.Text = "Ingreso de Hoy";
            this.ingresoDeHoyToolStripMenuItem.Click += new System.EventHandler(this.ingresoDeHoyToolStripMenuItem_Click);
            // 
            // ingresoDelMesToolStripMenuItem
            // 
            this.ingresoDelMesToolStripMenuItem.Name = "ingresoDelMesToolStripMenuItem";
            this.ingresoDelMesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ingresoDelMesToolStripMenuItem.Text = "Ingreso Del Mes";
            this.ingresoDelMesToolStripMenuItem.Click += new System.EventHandler(this.ingresoDelMesToolStripMenuItem_Click);
            // 
            // utilitariosToolStripMenuItem
            // 
            this.utilitariosToolStripMenuItem.Name = "utilitariosToolStripMenuItem";
            this.utilitariosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitariosToolStripMenuItem.Text = "Utilitarios";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 612);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "JM Sistema Prestamo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.Form1_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem edicionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem garanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasYReportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoDeHoyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoDelMesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hacerPrestamoToolStripMenuItem;

    }
}

