namespace PagoElectronico.Facturacion
{
    partial class FacturacionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.comboTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.comboTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grdItemsAPagar = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdTransacciones = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suscripcion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsAPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.comboTipoDoc);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 59);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturacion";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(184, 21);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(104, 20);
            this.txtNroDoc.TabIndex = 34;
            // 
            // comboTipoDoc
            // 
            this.comboTipoDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTipoDoc.DisplayMember = "descripcion";
            this.comboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDoc.FormattingEnabled = true;
            this.comboTipoDoc.Location = new System.Drawing.Point(78, 20);
            this.comboTipoDoc.Name = "comboTipoDoc";
            this.comboTipoDoc.Size = new System.Drawing.Size(100, 21);
            this.comboTipoDoc.TabIndex = 33;
            this.comboTipoDoc.ValueMember = "codigo";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(6, 28);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 35;
            this.lblDocumento.Text = "Documento";
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Location = new System.Drawing.Point(6, 25);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(66, 13);
            this.lblTransaccion.TabIndex = 39;
            this.lblTransaccion.Text = "Transaccion";
            // 
            // comboTipoTransaccion
            // 
            this.comboTipoTransaccion.DisplayMember = "descripcion";
            this.comboTipoTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoTransaccion.Enabled = false;
            this.comboTipoTransaccion.FormattingEnabled = true;
            this.comboTipoTransaccion.Location = new System.Drawing.Point(78, 17);
            this.comboTipoTransaccion.Name = "comboTipoTransaccion";
            this.comboTipoTransaccion.Size = new System.Drawing.Size(175, 21);
            this.comboTipoTransaccion.TabIndex = 38;
            this.comboTipoTransaccion.SelectedIndexChanged += new System.EventHandler(this.comboTipoTransaccion_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarTodos);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.grdItemsAPagar);
            this.groupBox2.Controls.Add(this.grdTransacciones);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.chkSeleccionarTodos);
            this.groupBox2.Controls.Add(this.lblTransaccion);
            this.groupBox2.Controls.Add(this.comboTipoTransaccion);
            this.groupBox2.Controls.Add(this.btnFacturar);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 418);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Location = new System.Drawing.Point(259, 185);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(141, 28);
            this.btnAgregarTodos.TabIndex = 45;
            this.btnAgregarTodos.Text = "Agregar Todos";
            this.btnAgregarTodos.UseVisualStyleBackColor = true;
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(78, 185);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 28);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.Text = "Agregar Seleccionados";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grdItemsAPagar
            // 
            this.grdItemsAPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItemsAPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Date});
            this.grdItemsAPagar.Location = new System.Drawing.Point(9, 219);
            this.grdItemsAPagar.MultiSelect = false;
            this.grdItemsAPagar.Name = "grdItemsAPagar";
            this.grdItemsAPagar.ReadOnly = true;
            this.grdItemsAPagar.Size = new System.Drawing.Size(518, 135);
            this.grdItemsAPagar.TabIndex = 43;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "tipo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cuenta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nro. Cuenta";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 82;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoDescription";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tipo de Transacción";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CostoTotal";
            this.dataGridViewTextBoxColumn5.HeaderText = "Costo Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "fecha";
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // grdTransacciones
            // 
            this.grdTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTransacciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.Codigo,
            this.TipoTransaccion,
            this.NroCuenta,
            this.Tipo,
            this.Costo,
            this.Suscripcion,
            this.Fecha});
            this.grdTransacciones.Location = new System.Drawing.Point(9, 44);
            this.grdTransacciones.Name = "grdTransacciones";
            this.grdTransacciones.Size = new System.Drawing.Size(518, 135);
            this.grdTransacciones.TabIndex = 42;
            this.grdTransacciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdTransacciones_CellFormatting);
            // 
            // Seleccionar
            // 
            this.Seleccionar.FalseValue = "false";
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.TrueValue = "true";
            this.Seleccionar.Width = 30;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            // 
            // TipoTransaccion
            // 
            this.TipoTransaccion.DataPropertyName = "tipo";
            this.TipoTransaccion.HeaderText = "Tipo";
            this.TipoTransaccion.Name = "TipoTransaccion";
            this.TipoTransaccion.ReadOnly = true;
            this.TipoTransaccion.Visible = false;
            // 
            // NroCuenta
            // 
            this.NroCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NroCuenta.DataPropertyName = "cuenta";
            this.NroCuenta.HeaderText = "Nro. Cuenta";
            this.NroCuenta.Name = "NroCuenta";
            this.NroCuenta.ReadOnly = true;
            this.NroCuenta.Width = 82;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "TipoDescription";
            this.Tipo.HeaderText = "Tipo de Transacción";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 130;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "costo";
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 50;
            // 
            // Suscripcion
            // 
            this.Suscripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Suscripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Suscripcion.HeaderText = "Suscripción";
            this.Suscripcion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.Suscripcion.MaxDropDownItems = 5;
            this.Suscripcion.Name = "Suscripcion";
            this.Suscripcion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Suscripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Suscripcion.Width = 87;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(9, 369);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(169, 43);
            this.btnLimpiar.TabIndex = 41;
            this.btnLimpiar.Text = "Limpiar y Actualizar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiarLista_Click);
            // 
            // chkSeleccionarTodos
            // 
            this.chkSeleccionarTodos.AutoSize = true;
            this.chkSeleccionarTodos.Checked = true;
            this.chkSeleccionarTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(259, 21);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(141, 17);
            this.chkSeleccionarTodos.TabIndex = 40;
            this.chkSeleccionarTodos.Text = "Todas las transacciones";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodos_CheckedChanged);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(184, 369);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(298, 43);
            this.btnFacturar.TabIndex = 38;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(312, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(98, 21);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FacturacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FacturacionForm";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.FacturacionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsAPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransacciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.ComboBox comboTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.ComboBox comboTipoTransaccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.CheckBox chkSeleccionarTodos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView grdTransacciones;
        private System.Windows.Forms.DataGridView grdItemsAPagar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAgregarTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Suscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Button btnBuscar;

    }
}