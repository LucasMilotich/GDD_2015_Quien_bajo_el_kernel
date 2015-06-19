namespace PagoElectronico.ABM_Cuenta
{
    partial class EdicionCuenta
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbMonedas = new System.Windows.Forms.ComboBox();
            this.cmbTiposCuenta = new System.Windows.Forms.ComboBox();
            this.cmbPaises = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 189);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 27;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(116, 186);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(159, 20);
            this.txtCliente.TabIndex = 26;
            this.txtCliente.Visible = false;
            // 
            // cmbMonedas
            // 
            this.cmbMonedas.DisplayMember = "descripcion";
            this.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonedas.FormattingEnabled = true;
            this.cmbMonedas.Location = new System.Drawing.Point(116, 101);
            this.cmbMonedas.Name = "cmbMonedas";
            this.cmbMonedas.Size = new System.Drawing.Size(121, 21);
            this.cmbMonedas.TabIndex = 25;
            this.cmbMonedas.ValueMember = "codigo";
            // 
            // cmbTiposCuenta
            // 
            this.cmbTiposCuenta.DisplayMember = "descripcion";
            this.cmbTiposCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiposCuenta.FormattingEnabled = true;
            this.cmbTiposCuenta.Location = new System.Drawing.Point(116, 145);
            this.cmbTiposCuenta.Name = "cmbTiposCuenta";
            this.cmbTiposCuenta.Size = new System.Drawing.Size(121, 21);
            this.cmbTiposCuenta.TabIndex = 24;
            this.cmbTiposCuenta.ValueMember = "codigo";
            // 
            // cmbPaises
            // 
            this.cmbPaises.DisplayMember = "descripcionPais";
            this.cmbPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaises.FormattingEnabled = true;
            this.cmbPaises.Location = new System.Drawing.Point(116, 62);
            this.cmbPaises.Name = "cmbPaises";
            this.cmbPaises.Size = new System.Drawing.Size(188, 21);
            this.cmbPaises.TabIndex = 23;
            this.cmbPaises.ValueMember = "codigoPais";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(155, 247);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 33);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(25, 152);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(65, 13);
            this.lblTipoCuenta.TabIndex = 21;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(25, 111);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 20;
            this.lblMoneda.Text = "Moneda";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(25, 69);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(27, 13);
            this.lblPais.TabIndex = 19;
            this.lblPais.Text = "Pais";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(25, 30);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblCuenta.TabIndex = 18;
            this.lblCuenta.Text = "Número Cuenta";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Location = new System.Drawing.Point(116, 26);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(188, 20);
            this.txtCuenta.TabIndex = 17;
            // 
            // EdicionCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 313);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.cmbMonedas);
            this.Controls.Add(this.cmbTiposCuenta);
            this.Controls.Add(this.cmbPaises);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.txtCuenta);
            this.Name = "EdicionCuenta";
            this.Text = "EdicionCuenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbMonedas;
        private System.Windows.Forms.ComboBox cmbTiposCuenta;
        private System.Windows.Forms.ComboBox cmbPaises;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.TextBox txtCuenta;
    }
}