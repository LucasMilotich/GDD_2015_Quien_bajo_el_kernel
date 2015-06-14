namespace PagoElectronico
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoDeCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoEstadisticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearNuevoRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.accionesToolStripMenuItem,
            this.transaccionesToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarSaldoDeCuentaToolStripMenuItem,
            this.listadoEstadisticoToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // consultarSaldoDeCuentaToolStripMenuItem
            // 
            this.consultarSaldoDeCuentaToolStripMenuItem.Name = "consultarSaldoDeCuentaToolStripMenuItem";
            this.consultarSaldoDeCuentaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.consultarSaldoDeCuentaToolStripMenuItem.Text = "Consultar saldo de cuenta";
            this.consultarSaldoDeCuentaToolStripMenuItem.Click += new System.EventHandler(this.consultarSaldoDeCuentaToolStripMenuItem_Click);
            // 
            // listadoEstadisticoToolStripMenuItem
            // 
            this.listadoEstadisticoToolStripMenuItem.Name = "listadoEstadisticoToolStripMenuItem";
            this.listadoEstadisticoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.listadoEstadisticoToolStripMenuItem.Text = "Listado estadistico";
            this.listadoEstadisticoToolStripMenuItem.Click += new System.EventHandler(this.listadoEstadisticoToolStripMenuItem_Click);
            // 
            // transaccionesToolStripMenuItem
            // 
            this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferenciasToolStripMenuItem});
            this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
            this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.transaccionesToolStripMenuItem.Text = "Transacciones";
            // 
            // transferenciasToolStripMenuItem
            // 
            this.transferenciasToolStripMenuItem.Name = "transferenciasToolStripMenuItem";
            this.transferenciasToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.transferenciasToolStripMenuItem.Text = "Transferencias";
            this.transferenciasToolStripMenuItem.Click += new System.EventHandler(this.transferenciasToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNuevoRolToolStripMenuItem,
            this.buscarRolesToolStripMenuItem,
            this.modificarRolToolStripMenuItem});
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // crearNuevoRolToolStripMenuItem
            // 
            this.crearNuevoRolToolStripMenuItem.Name = "crearNuevoRolToolStripMenuItem";
            this.crearNuevoRolToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.crearNuevoRolToolStripMenuItem.Text = "Crear nuevo rol";
            this.crearNuevoRolToolStripMenuItem.Click += new System.EventHandler(this.crearNuevoRolToolStripMenuItem_Click);
            // 
            // buscarRolesToolStripMenuItem
            // 
            this.buscarRolesToolStripMenuItem.Name = "buscarRolesToolStripMenuItem";
            this.buscarRolesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.buscarRolesToolStripMenuItem.Text = "Buscar roles";
            this.buscarRolesToolStripMenuItem.Click += new System.EventHandler(this.buscarRolesToolStripMenuItem_Click);
            // 
            // modificarRolToolStripMenuItem
            // 
            this.modificarRolToolStripMenuItem.Name = "modificarRolToolStripMenuItem";
            this.modificarRolToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.modificarRolToolStripMenuItem.Text = "Modificar rol";
            this.modificarRolToolStripMenuItem.Click += new System.EventHandler(this.modificarRolToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 437);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSaldoDeCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoEstadisticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearNuevoRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarRolToolStripMenuItem;
    }
}

