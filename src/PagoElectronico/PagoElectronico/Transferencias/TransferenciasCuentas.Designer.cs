namespace PagoElectronico.Transferencias
{
    partial class TransferenciasCuentas
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
            this.lblSaldoPosterior = new System.Windows.Forms.Label();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaldoReadOnly = new System.Windows.Forms.Label();
            this.comboTipoMoneda = new System.Windows.Forms.ComboBox();
            this.lblTipoMoneda = new System.Windows.Forms.Label();
            this.comboCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtCuentaDestino = new System.Windows.Forms.TextBox();
            this.lblCuentaOrigen = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.groupBoxTransferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTransferencia
            // 
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoPosterior);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoActual);
            this.groupBoxTransferencia.Controls.Add(this.label3);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoReadOnly);
            this.groupBoxTransferencia.Controls.Add(this.comboTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.lblTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.comboCuentaOrigen);
            this.groupBoxTransferencia.Controls.Add(this.label1);
            this.groupBoxTransferencia.Controls.Add(this.lblImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtCuentaDestino);
            this.groupBoxTransferencia.Controls.Add(this.lblCuentaOrigen);
            this.groupBoxTransferencia.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTransferencia.Name = "groupBoxTransferencia";
            this.groupBoxTransferencia.Size = new System.Drawing.Size(513, 135);
            this.groupBoxTransferencia.TabIndex = 4;
            this.groupBoxTransferencia.TabStop = false;
            this.groupBoxTransferencia.Text = "Transferencia";
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
            this.lblSaldoActual.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Saldo posterior";
            this.label3.Visible = false;
            // 
            // lblSaldoReadOnly
            // 
            this.lblSaldoReadOnly.AutoSize = true;
            this.lblSaldoReadOnly.Location = new System.Drawing.Point(306, 27);
            this.lblSaldoReadOnly.Name = "lblSaldoReadOnly";
            this.lblSaldoReadOnly.Size = new System.Drawing.Size(66, 13);
            this.lblSaldoReadOnly.TabIndex = 17;
            this.lblSaldoReadOnly.Text = "Saldo actual";
            this.lblSaldoReadOnly.Visible = false;
            // 
            // comboTipoMoneda
            // 
            this.comboTipoMoneda.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoMoneda.FormattingEnabled = true;
            this.comboTipoMoneda.Location = new System.Drawing.Point(86, 106);
            this.comboTipoMoneda.Name = "comboTipoMoneda";
            this.comboTipoMoneda.Size = new System.Drawing.Size(121, 21);
            this.comboTipoMoneda.TabIndex = 16;
            // 
            // lblTipoMoneda
            // 
            this.lblTipoMoneda.AutoSize = true;
            this.lblTipoMoneda.Location = new System.Drawing.Point(6, 109);
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
            this.comboCuentaOrigen.Location = new System.Drawing.Point(87, 19);
            this.comboCuentaOrigen.Name = "comboCuentaOrigen";
            this.comboCuentaOrigen.Size = new System.Drawing.Size(121, 21);
            this.comboCuentaOrigen.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cuenta Destino";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(6, 79);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 12;
            this.lblImporte.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(87, 76);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(120, 20);
            this.txtImporte.TabIndex = 11;
            // 
            // txtCuentaDestino
            // 
            this.txtCuentaDestino.Location = new System.Drawing.Point(87, 46);
            this.txtCuentaDestino.Name = "txtCuentaDestino";
            this.txtCuentaDestino.Size = new System.Drawing.Size(120, 20);
            this.txtCuentaDestino.TabIndex = 3;
            // 
            // lblCuentaOrigen
            // 
            this.lblCuentaOrigen.AutoSize = true;
            this.lblCuentaOrigen.Location = new System.Drawing.Point(6, 24);
            this.lblCuentaOrigen.Name = "lblCuentaOrigen";
            this.lblCuentaOrigen.Size = new System.Drawing.Size(75, 13);
            this.lblCuentaOrigen.TabIndex = 2;
            this.lblCuentaOrigen.Text = "Cuenta Origen";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(354, 178);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 44);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(21, 178);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(117, 44);
            this.btnTransferir.TabIndex = 7;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // TransferenciasCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 280);
            this.Controls.Add(this.groupBoxTransferencia);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "TransferenciasCuentas";
            this.Text = "Transferencias entre cuentas";
            this.Load += new System.EventHandler(this.TransferenciasCuentas_Load);
            this.groupBoxTransferencia.ResumeLayout(false);
            this.groupBoxTransferencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTransferencia;
        private System.Windows.Forms.ComboBox comboCuentaOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.TextBox txtCuentaDestino;
        private System.Windows.Forms.Label lblCuentaOrigen;
        private System.Windows.Forms.ComboBox comboTipoMoneda;
        private System.Windows.Forms.Label lblTipoMoneda;
        private System.Windows.Forms.Label lblSaldoPosterior;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSaldoReadOnly;
    }
}