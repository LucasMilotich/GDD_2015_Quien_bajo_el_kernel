namespace PagoElectronico.Depositos
{
    partial class DepositoForm
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
            this.groupBoxTransferencia = new System.Windows.Forms.GroupBox();
            this.comboTarjeta = new System.Windows.Forms.ComboBox();
            this.lblTC = new System.Windows.Forms.Label();
            this.lblFechaDeposito = new System.Windows.Forms.Label();
            this.lblSaldoPosterior = new System.Windows.Forms.Label();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.lblSaldoPosteriorRO = new System.Windows.Forms.Label();
            this.lblSaldoActualRO = new System.Windows.Forms.Label();
            this.comboTipoMoneda = new System.Windows.Forms.ComboBox();
            this.lblTipoMoneda = new System.Windows.Forms.Label();
            this.comboCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTransferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTransferencia
            // 
            this.groupBoxTransferencia.Controls.Add(this.dateTimePicker1);
            this.groupBoxTransferencia.Controls.Add(this.comboTarjeta);
            this.groupBoxTransferencia.Controls.Add(this.lblTC);
            this.groupBoxTransferencia.Controls.Add(this.lblFechaDeposito);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoPosterior);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoActual);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoPosteriorRO);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoActualRO);
            this.groupBoxTransferencia.Controls.Add(this.comboTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.lblTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.comboCuentaOrigen);
            this.groupBoxTransferencia.Controls.Add(this.lblImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtImporte);
            this.groupBoxTransferencia.Controls.Add(this.lblCuenta);
            this.groupBoxTransferencia.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTransferencia.Name = "groupBoxTransferencia";
            this.groupBoxTransferencia.Size = new System.Drawing.Size(475, 190);
            this.groupBoxTransferencia.TabIndex = 6;
            this.groupBoxTransferencia.TabStop = false;
            this.groupBoxTransferencia.Text = "Deposito";
            // 
            // comboTarjeta
            // 
            this.comboTarjeta.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTarjeta.DisplayMember = "tarjetaNumero";
            this.comboTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTarjeta.FormattingEnabled = true;
            this.comboTarjeta.Location = new System.Drawing.Point(102, 67);
            this.comboTarjeta.Name = "comboTarjeta";
            this.comboTarjeta.Size = new System.Drawing.Size(192, 21);
            this.comboTarjeta.TabIndex = 6;
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(6, 75);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(90, 13);
            this.lblTC.TabIndex = 28;
            this.lblTC.Text = "Tarjeta de credito";
            // 
            // lblFechaDeposito
            // 
            this.lblFechaDeposito.AutoSize = true;
            this.lblFechaDeposito.Location = new System.Drawing.Point(8, 133);
            this.lblFechaDeposito.Name = "lblFechaDeposito";
            this.lblFechaDeposito.Size = new System.Drawing.Size(80, 13);
            this.lblFechaDeposito.TabIndex = 27;
            this.lblFechaDeposito.Text = "Fecha deposito";
            // 
            // lblSaldoPosterior
            // 
            this.lblSaldoPosterior.AutoSize = true;
            this.lblSaldoPosterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoPosterior.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaldoPosterior.Location = new System.Drawing.Point(389, 48);
            this.lblSaldoPosterior.Name = "lblSaldoPosterior";
            this.lblSaldoPosterior.Size = new System.Drawing.Size(64, 18);
            this.lblSaldoPosterior.TabIndex = 20;
            this.lblSaldoPosterior.Text = "elSaldo";
            this.lblSaldoPosterior.Visible = false;
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoActual.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoActual.Location = new System.Drawing.Point(389, 23);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(64, 18);
            this.lblSaldoActual.TabIndex = 18;
            this.lblSaldoActual.Text = "elSaldo";
            // 
            // lblSaldoPosteriorRO
            // 
            this.lblSaldoPosteriorRO.AutoSize = true;
            this.lblSaldoPosteriorRO.Location = new System.Drawing.Point(306, 53);
            this.lblSaldoPosteriorRO.Name = "lblSaldoPosteriorRO";
            this.lblSaldoPosteriorRO.Size = new System.Drawing.Size(77, 13);
            this.lblSaldoPosteriorRO.TabIndex = 19;
            this.lblSaldoPosteriorRO.Text = "Saldo posterior";
            this.lblSaldoPosteriorRO.Visible = false;
            // 
            // lblSaldoActualRO
            // 
            this.lblSaldoActualRO.AutoSize = true;
            this.lblSaldoActualRO.Location = new System.Drawing.Point(306, 27);
            this.lblSaldoActualRO.Name = "lblSaldoActualRO";
            this.lblSaldoActualRO.Size = new System.Drawing.Size(66, 13);
            this.lblSaldoActualRO.TabIndex = 17;
            this.lblSaldoActualRO.Text = "Saldo actual";
            // 
            // comboTipoMoneda
            // 
            this.comboTipoMoneda.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTipoMoneda.DisplayMember = "descripcion";
            this.comboTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoMoneda.FormattingEnabled = true;
            this.comboTipoMoneda.Location = new System.Drawing.Point(103, 40);
            this.comboTipoMoneda.Name = "comboTipoMoneda";
            this.comboTipoMoneda.Size = new System.Drawing.Size(191, 21);
            this.comboTipoMoneda.TabIndex = 5;
            this.comboTipoMoneda.ValueMember = "codigo";
            // 
            // lblTipoMoneda
            // 
            this.lblTipoMoneda.AutoSize = true;
            this.lblTipoMoneda.Location = new System.Drawing.Point(6, 48);
            this.lblTipoMoneda.Name = "lblTipoMoneda";
            this.lblTipoMoneda.Size = new System.Drawing.Size(70, 13);
            this.lblTipoMoneda.TabIndex = 15;
            this.lblTipoMoneda.Text = "Tipo Moneda";
            // 
            // comboCuentaOrigen
            // 
            this.comboCuentaOrigen.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboCuentaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCuentaOrigen.FormattingEnabled = true;
            this.comboCuentaOrigen.Location = new System.Drawing.Point(102, 16);
            this.comboCuentaOrigen.Name = "comboCuentaOrigen";
            this.comboCuentaOrigen.Size = new System.Drawing.Size(192, 21);
            this.comboCuentaOrigen.TabIndex = 1;
            this.comboCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.comboCuentaOrigen_SelectedIndexChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(8, 99);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 12;
            this.lblImporte.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(103, 96);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(119, 20);
            this.txtImporte.TabIndex = 4;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(6, 24);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(41, 13);
            this.lblCuenta.TabIndex = 2;
            this.lblCuenta.Text = "Cuenta";
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(57, 242);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(117, 44);
            this.btnDepositar.TabIndex = 11;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(271, 242);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 44);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // DepositoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 413);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBoxTransferencia);
            this.Name = "DepositoForm";
            this.Text = "Deposito";
            this.Load += new System.EventHandler(this.DepositoForm_Load);
            this.groupBoxTransferencia.ResumeLayout(false);
            this.groupBoxTransferencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTransferencia;
        private System.Windows.Forms.ComboBox comboTarjeta;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label lblFechaDeposito;
        private System.Windows.Forms.Label lblSaldoPosterior;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.Label lblSaldoPosteriorRO;
        private System.Windows.Forms.Label lblSaldoActualRO;
        private System.Windows.Forms.ComboBox comboTipoMoneda;
        private System.Windows.Forms.Label lblTipoMoneda;
        private System.Windows.Forms.ComboBox comboCuentaOrigen;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}