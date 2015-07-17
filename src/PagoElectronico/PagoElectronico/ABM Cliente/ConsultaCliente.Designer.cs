namespace PagoElectronico.ABM_Cliente
{
    partial class ConsultaCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.edicion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.habilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AdministrarTarjetas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dom_calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dom_nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dom_piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dom_dpto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.lblDni);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.dgvClientes);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 477);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultas clientes";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DisplayMember = "descripcion";
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(33, 133);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(231, 21);
            this.cmbTipoDoc.TabIndex = 4;
            this.cmbTipoDoc.ValueMember = "codigo";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(33, 92);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(231, 20);
            this.txtMail.TabIndex = 3;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(30, 75);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 35;
            this.lblMail.Text = "Mail";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(270, 118);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(66, 13);
            this.lblDni.TabIndex = 32;
            this.lblDni.Text = "Numero DNI";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(30, 115);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(49, 13);
            this.lblTipoDoc.TabIndex = 30;
            this.lblTipoDoc.Text = "Tipo doc";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(270, 134);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(213, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(33, 53);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(231, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(30, 37);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 26;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Snow;
            this.txtNombre.Location = new System.Drawing.Point(270, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(213, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(267, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 24;
            this.lblNombre.Text = "Nombre";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToOrderColumns = true;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edicion,
            this.habilitar,
            this.AdministrarTarjetas,
            this.Habilitado,
            this.tipoDocumento,
            this.numeroDocumento,
            this.pais,
            this.nombre,
            this.apellido,
            this.dom_calle,
            this.dom_nro,
            this.dom_piso,
            this.dom_dpto,
            this.fecha_nacimiento,
            this.mail,
            this.localidad,
            this.username});
            this.dgvClientes.Location = new System.Drawing.Point(31, 176);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(646, 295);
            this.dgvClientes.TabIndex = 22;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(523, 92);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(154, 69);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(585, 46);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(92, 26);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // edicion
            // 
            this.edicion.HeaderText = "Editar";
            this.edicion.Name = "edicion";
            this.edicion.ReadOnly = true;
            this.edicion.Text = "Editar";
            this.edicion.UseColumnTextForButtonValue = true;
            this.edicion.Width = 50;
            // 
            // habilitar
            // 
            this.habilitar.DataPropertyName = "habilitar";
            this.habilitar.HeaderText = "Habilitar";
            this.habilitar.Name = "habilitar";
            this.habilitar.ReadOnly = true;
            this.habilitar.Text = "Habilitar / Inhabilitar";
            this.habilitar.UseColumnTextForButtonValue = true;
            this.habilitar.Width = 110;
            // 
            // AdministrarTarjetas
            // 
            this.AdministrarTarjetas.DataPropertyName = "AdministrarTarjetas";
            this.AdministrarTarjetas.HeaderText = "AdministrarTarjetas";
            this.AdministrarTarjetas.Name = "AdministrarTarjetas";
            this.AdministrarTarjetas.ReadOnly = true;
            this.AdministrarTarjetas.Text = "Administrar";
            this.AdministrarTarjetas.UseColumnTextForButtonValue = true;
            // 
            // Habilitado
            // 
            this.Habilitado.DataPropertyName = "habilitado";
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Width = 55;
            // 
            // tipoDocumento
            // 
            this.tipoDocumento.DataPropertyName = "TipoDocumento";
            this.tipoDocumento.HeaderText = "Tipo Documento";
            this.tipoDocumento.Name = "tipoDocumento";
            this.tipoDocumento.ReadOnly = true;
            // 
            // numeroDocumento
            // 
            this.numeroDocumento.DataPropertyName = "numeroDocumento";
            this.numeroDocumento.HeaderText = "Nro. Documento";
            this.numeroDocumento.Name = "numeroDocumento";
            this.numeroDocumento.ReadOnly = true;
            // 
            // pais
            // 
            this.pais.DataPropertyName = "paisCodigo";
            this.pais.HeaderText = "País";
            this.pais.Name = "pais";
            this.pais.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // dom_calle
            // 
            this.dom_calle.DataPropertyName = "domCalle";
            this.dom_calle.HeaderText = "dom_calle";
            this.dom_calle.Name = "dom_calle";
            this.dom_calle.ReadOnly = true;
            // 
            // dom_nro
            // 
            this.dom_nro.DataPropertyName = "domNro";
            this.dom_nro.HeaderText = "dom_nro";
            this.dom_nro.Name = "dom_nro";
            this.dom_nro.ReadOnly = true;
            // 
            // dom_piso
            // 
            this.dom_piso.DataPropertyName = "domPiso";
            this.dom_piso.HeaderText = "dom_piso";
            this.dom_piso.Name = "dom_piso";
            this.dom_piso.ReadOnly = true;
            // 
            // dom_dpto
            // 
            this.dom_dpto.DataPropertyName = "domDpto";
            this.dom_dpto.HeaderText = "dom_dpto";
            this.dom_dpto.Name = "dom_dpto";
            this.dom_dpto.ReadOnly = true;
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.DataPropertyName = "fechaNacimiento";
            this.fecha_nacimiento.HeaderText = "fecha_nacimiento";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            // 
            // mail
            // 
            this.mail.DataPropertyName = "mail";
            this.mail.HeaderText = "mail";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            // 
            // localidad
            // 
            this.localidad.DataPropertyName = "localidad";
            this.localidad.HeaderText = "localidad";
            this.localidad.Name = "localidad";
            this.localidad.ReadOnly = true;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // ConsultaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 501);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultaCliente";
            this.Text = "Consulta de clientes";
            this.Load += new System.EventHandler(this.ConsultaCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.DataGridViewButtonColumn edicion;
        private System.Windows.Forms.DataGridViewButtonColumn habilitar;
        private System.Windows.Forms.DataGridViewButtonColumn AdministrarTarjetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dom_calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dom_nro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dom_piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dom_dpto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;

    }
}