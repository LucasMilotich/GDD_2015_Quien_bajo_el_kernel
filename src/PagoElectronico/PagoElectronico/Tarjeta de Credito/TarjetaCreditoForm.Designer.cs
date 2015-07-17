namespace PagoElectronico.Tarjeta_de_Credito
{
    partial class TarjetaCreditoForm
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
            this.groupBoxConsultarTarjetasCredito = new System.Windows.Forms.GroupBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.dgvTarjetas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBoxAsociarNuevaTarjeta = new System.Windows.Forms.GroupBox();
            this.btnAsociarTarjeta = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.lblEmisor = new System.Windows.Forms.Label();
            this.cmbEmisor = new System.Windows.Forms.ComboBox();
            this.txtCodSeguridad = new System.Windows.Forms.TextBox();
            this.lblCodSeguridad = new System.Windows.Forms.Label();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.btnHabilitarNuevaTarjeta = new System.Windows.Forms.Button();
            this.desasociar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tarjetaNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoSeguridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxConsultarTarjetasCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).BeginInit();
            this.groupBoxAsociarNuevaTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConsultarTarjetasCredito
            // 
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.btnHabilitarNuevaTarjeta);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.btnVolver);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.cmbTipoDoc);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.lblDni);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.lblTipoDoc);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.txtNroDoc);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.dgvTarjetas);
            this.groupBoxConsultarTarjetasCredito.Controls.Add(this.btnBuscar);
            this.groupBoxConsultarTarjetasCredito.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConsultarTarjetasCredito.Name = "groupBoxConsultarTarjetasCredito";
            this.groupBoxConsultarTarjetasCredito.Size = new System.Drawing.Size(690, 321);
            this.groupBoxConsultarTarjetasCredito.TabIndex = 3;
            this.groupBoxConsultarTarjetasCredito.TabStop = false;
            this.groupBoxConsultarTarjetasCredito.Text = "Consulta tarjetas de credito";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(568, 17);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(107, 39);
            this.btnVolver.TabIndex = 34;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DisplayMember = "descripcion";
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.Enabled = false;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(16, 35);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(161, 21);
            this.cmbTipoDoc.TabIndex = 4;
            this.cmbTipoDoc.ValueMember = "codigo";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(180, 16);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(66, 13);
            this.lblDni.TabIndex = 32;
            this.lblDni.Text = "Numero DNI";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(13, 17);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(49, 13);
            this.lblTipoDoc.TabIndex = 30;
            this.lblTipoDoc.Text = "Tipo doc";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(183, 35);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(154, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // dgvTarjetas
            // 
            this.dgvTarjetas.AllowUserToAddRows = false;
            this.dgvTarjetas.AllowUserToDeleteRows = false;
            this.dgvTarjetas.AllowUserToOrderColumns = true;
            this.dgvTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarjetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desasociar,
            this.tarjetaNumero,
            this.fechaEmision,
            this.fechaVencimiento,
            this.codigoSeguridad,
            this.codEmisor,
            this.tipoDoc,
            this.nroDoc,
            this.habilitado});
            this.dgvTarjetas.Location = new System.Drawing.Point(16, 75);
            this.dgvTarjetas.Name = "dgvTarjetas";
            this.dgvTarjetas.ReadOnly = true;
            this.dgvTarjetas.Size = new System.Drawing.Size(668, 217);
            this.dgvTarjetas.TabIndex = 22;
            this.dgvTarjetas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarjetas_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(343, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 39);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBoxAsociarNuevaTarjeta
            // 
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.btnAsociarTarjeta);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.btnLimpiar);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.lblFechaVencimiento);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.lblFechaEmision);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.dtpFechaVencimiento);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.dtpFechaEmision);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.lblEmisor);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.cmbEmisor);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.txtCodSeguridad);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.lblCodSeguridad);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.txtNumeroTarjeta);
            this.groupBoxAsociarNuevaTarjeta.Controls.Add(this.lblNumero);
            this.groupBoxAsociarNuevaTarjeta.Location = new System.Drawing.Point(12, 349);
            this.groupBoxAsociarNuevaTarjeta.Name = "groupBoxAsociarNuevaTarjeta";
            this.groupBoxAsociarNuevaTarjeta.Size = new System.Drawing.Size(690, 149);
            this.groupBoxAsociarNuevaTarjeta.TabIndex = 4;
            this.groupBoxAsociarNuevaTarjeta.TabStop = false;
            this.groupBoxAsociarNuevaTarjeta.Text = "Asociar nueva tarjeta";
            this.groupBoxAsociarNuevaTarjeta.Visible = false;
            // 
            // btnAsociarTarjeta
            // 
            this.btnAsociarTarjeta.Location = new System.Drawing.Point(117, 86);
            this.btnAsociarTarjeta.Name = "btnAsociarTarjeta";
            this.btnAsociarTarjeta.Size = new System.Drawing.Size(181, 48);
            this.btnAsociarTarjeta.TabIndex = 35;
            this.btnAsociarTarjeta.Text = "Asociar tarjeta a cliente";
            this.btnAsociarTarjeta.UseVisualStyleBackColor = true;
            this.btnAsociarTarjeta.Click += new System.EventHandler(this.btnAsociarTarjeta_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(338, 86);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(189, 48);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(565, 29);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(97, 13);
            this.lblFechaVencimiento.TabIndex = 23;
            this.lblFechaVencimiento.Text = "Fecha vencimiento";
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Location = new System.Drawing.Point(395, 29);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(75, 13);
            this.lblFechaEmision.TabIndex = 22;
            this.lblFechaEmision.Text = "Fecha emision";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(533, 45);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(135, 20);
            this.dtpFechaVencimiento.TabIndex = 21;
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(398, 45);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaEmision.TabIndex = 20;
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.Location = new System.Drawing.Point(281, 28);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(38, 13);
            this.lblEmisor.TabIndex = 19;
            this.lblEmisor.Text = "Emisor";
            // 
            // cmbEmisor
            // 
            this.cmbEmisor.DisplayMember = "descripcion";
            this.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmisor.FormattingEnabled = true;
            this.cmbEmisor.Location = new System.Drawing.Point(284, 44);
            this.cmbEmisor.Name = "cmbEmisor";
            this.cmbEmisor.Size = new System.Drawing.Size(108, 21);
            this.cmbEmisor.TabIndex = 18;
            this.cmbEmisor.ValueMember = "id";
            // 
            // txtCodSeguridad
            // 
            this.txtCodSeguridad.Location = new System.Drawing.Point(200, 44);
            this.txtCodSeguridad.Name = "txtCodSeguridad";
            this.txtCodSeguridad.Size = new System.Drawing.Size(78, 20);
            this.txtCodSeguridad.TabIndex = 17;
            // 
            // lblCodSeguridad
            // 
            this.lblCodSeguridad.AutoSize = true;
            this.lblCodSeguridad.Location = new System.Drawing.Point(197, 28);
            this.lblCodSeguridad.Name = "lblCodSeguridad";
            this.lblCodSeguridad.Size = new System.Drawing.Size(78, 13);
            this.lblCodSeguridad.TabIndex = 16;
            this.lblCodSeguridad.Text = "Cod. seguridad";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(8, 45);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(186, 20);
            this.txtNumeroTarjeta.TabIndex = 15;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(5, 29);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 14;
            this.lblNumero.Text = "Numero";
            // 
            // btnHabilitarNuevaTarjeta
            // 
            this.btnHabilitarNuevaTarjeta.Location = new System.Drawing.Point(456, 19);
            this.btnHabilitarNuevaTarjeta.Name = "btnHabilitarNuevaTarjeta";
            this.btnHabilitarNuevaTarjeta.Size = new System.Drawing.Size(106, 37);
            this.btnHabilitarNuevaTarjeta.TabIndex = 36;
            this.btnHabilitarNuevaTarjeta.Text = "Asociar nueva tarjeta";
            this.btnHabilitarNuevaTarjeta.UseVisualStyleBackColor = true;
            this.btnHabilitarNuevaTarjeta.Click += new System.EventHandler(this.btnHabilitarNuevaTarjeta_Click);
            // 
            // desasociar
            // 
            this.desasociar.DataPropertyName = "desasociar";
            this.desasociar.HeaderText = "Desasociar";
            this.desasociar.Name = "desasociar";
            this.desasociar.ReadOnly = true;
            this.desasociar.Text = "Desasociar";
            this.desasociar.UseColumnTextForButtonValue = true;
            this.desasociar.Width = 110;
            // 
            // tarjetaNumero
            // 
            this.tarjetaNumero.DataPropertyName = "tarjetaNumero";
            this.tarjetaNumero.HeaderText = "Numero tarjeta";
            this.tarjetaNumero.Name = "tarjetaNumero";
            this.tarjetaNumero.ReadOnly = true;
            this.tarjetaNumero.Width = 150;
            // 
            // fechaEmision
            // 
            this.fechaEmision.DataPropertyName = "fechaEmision";
            this.fechaEmision.HeaderText = "Fecha Emision";
            this.fechaEmision.Name = "fechaEmision";
            this.fechaEmision.ReadOnly = true;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.DataPropertyName = "fechaVencimiento";
            this.fechaVencimiento.HeaderText = "Fecha Vencimiento";
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.ReadOnly = true;
            // 
            // codigoSeguridad
            // 
            this.codigoSeguridad.DataPropertyName = "codigoSeguridad";
            this.codigoSeguridad.HeaderText = "Codigo de Seguridad";
            this.codigoSeguridad.Name = "codigoSeguridad";
            this.codigoSeguridad.ReadOnly = true;
            // 
            // codEmisor
            // 
            this.codEmisor.DataPropertyName = "codEmisor";
            this.codEmisor.HeaderText = "Banco Emisor";
            this.codEmisor.Name = "codEmisor";
            this.codEmisor.ReadOnly = true;
            // 
            // tipoDoc
            // 
            this.tipoDoc.DataPropertyName = "tipoDoc";
            this.tipoDoc.HeaderText = "Tipo Doc.";
            this.tipoDoc.Name = "tipoDoc";
            this.tipoDoc.ReadOnly = true;
            // 
            // nroDoc
            // 
            this.nroDoc.DataPropertyName = "nroDoc";
            this.nroDoc.HeaderText = "Numero Doc.";
            this.nroDoc.Name = "nroDoc";
            this.nroDoc.ReadOnly = true;
            // 
            // habilitado
            // 
            this.habilitado.DataPropertyName = "habilitado";
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            // 
            // TarjetaCreditoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 510);
            this.Controls.Add(this.groupBoxAsociarNuevaTarjeta);
            this.Controls.Add(this.groupBoxConsultarTarjetasCredito);
            this.Name = "TarjetaCreditoForm";
            this.Text = "Asociar tarjeta de creditos";
            this.Load += new System.EventHandler(this.TarjetaCreditoForm_Load);
            this.groupBoxConsultarTarjetasCredito.ResumeLayout(false);
            this.groupBoxConsultarTarjetasCredito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).EndInit();
            this.groupBoxAsociarNuevaTarjeta.ResumeLayout(false);
            this.groupBoxAsociarNuevaTarjeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConsultarTarjetasCredito;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.DataGridView dgvTarjetas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBoxAsociarNuevaTarjeta;
        private System.Windows.Forms.Button btnAsociarTarjeta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaEmision;
        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.ComboBox cmbEmisor;
        private System.Windows.Forms.TextBox txtCodSeguridad;
        private System.Windows.Forms.Label lblCodSeguridad;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnHabilitarNuevaTarjeta;
        private System.Windows.Forms.DataGridViewButtonColumn desasociar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarjetaNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoSeguridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
    }
}