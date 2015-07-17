namespace PagoElectronico.ABM_Cuenta
{
    partial class AltaCuenta
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
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbPaises = new System.Windows.Forms.ComboBox();
            this.cmbTiposCuenta = new System.Windows.Forms.ComboBox();
            this.cmbMonedas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.chkResuscribir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCuenta
            // 
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Location = new System.Drawing.Point(116, 26);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(188, 20);
            this.txtCuenta.TabIndex = 0;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(25, 30);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblCuenta.TabIndex = 5;
            this.lblCuenta.Text = "Número Cuenta";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(25, 68);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(27, 13);
            this.lblPais.TabIndex = 6;
            this.lblPais.Text = "Pais";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(25, 107);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 7;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(25, 151);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(65, 13);
            this.lblTipoCuenta.TabIndex = 9;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(64, 248);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 33);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbPaises
            // 
            this.cmbPaises.DisplayMember = "descripcionPais";
            this.cmbPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaises.FormattingEnabled = true;
            this.cmbPaises.Location = new System.Drawing.Point(116, 64);
            this.cmbPaises.Name = "cmbPaises";
            this.cmbPaises.Size = new System.Drawing.Size(188, 21);
            this.cmbPaises.TabIndex = 12;
            this.cmbPaises.ValueMember = "codigoPais";
            // 
            // cmbTiposCuenta
            // 
            this.cmbTiposCuenta.DisplayMember = "descripcion";
            this.cmbTiposCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiposCuenta.FormattingEnabled = true;
            this.cmbTiposCuenta.Location = new System.Drawing.Point(116, 147);
            this.cmbTiposCuenta.Name = "cmbTiposCuenta";
            this.cmbTiposCuenta.Size = new System.Drawing.Size(121, 21);
            this.cmbTiposCuenta.TabIndex = 13;
            this.cmbTiposCuenta.ValueMember = "codigo";
            // 
            // cmbMonedas
            // 
            this.cmbMonedas.DisplayMember = "descripcion";
            this.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonedas.FormattingEnabled = true;
            this.cmbMonedas.Location = new System.Drawing.Point(116, 103);
            this.cmbMonedas.Name = "cmbMonedas";
            this.cmbMonedas.Size = new System.Drawing.Size(121, 21);
            this.cmbMonedas.TabIndex = 14;
            this.cmbMonedas.ValueMember = "codigo";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(26, 190);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Visible = false;
            // 
            // cmbClientes
            // 
            this.cmbClientes.DisplayMember = "nombreCompleto";
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(116, 186);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(189, 21);
            this.cmbClientes.TabIndex = 17;
            this.cmbClientes.ValueMember = "numeroDocumento";
            this.cmbClientes.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(228, 248);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(119, 33);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chkResuscribir
            // 
            this.chkResuscribir.AutoSize = true;
            this.chkResuscribir.Location = new System.Drawing.Point(248, 149);
            this.chkResuscribir.Name = "chkResuscribir";
            this.chkResuscribir.Size = new System.Drawing.Size(78, 17);
            this.chkResuscribir.TabIndex = 19;
            this.chkResuscribir.Text = "Resuscribir";
            this.chkResuscribir.UseVisualStyleBackColor = true;
            this.chkResuscribir.Visible = false;
            // 
            // AltaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 310);
            this.Controls.Add(this.chkResuscribir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbMonedas);
            this.Controls.Add(this.cmbTiposCuenta);
            this.Controls.Add(this.cmbPaises);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.txtCuenta);
            this.Name = "AltaCuenta";
            this.Text = "Alta de Cuenta";
            this.Load += new System.EventHandler(this.AltaCuenta_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaCuenta_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbPaises;
        private System.Windows.Forms.ComboBox cmbTiposCuenta;
        private System.Windows.Forms.ComboBox cmbMonedas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox chkResuscribir;
    }
}