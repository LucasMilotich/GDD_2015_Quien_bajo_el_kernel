namespace PagoElectronico.Retiros
{
    partial class Retiro
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
            this.lblSaldoPosteriorRO = new System.Windows.Forms.Label();
            this.lblSaldoActualRO = new System.Windows.Forms.Label();
            this.comboTipoMoneda = new System.Windows.Forms.ComboBox();
            this.lblTipoMoneda = new System.Windows.Forms.Label();
            this.comboCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblCuentaOrigen = new System.Windows.Forms.Label();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.comboTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.groupBoxTransferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTransferencia
            // 
            this.groupBoxTransferencia.Controls.Add(this.txtNroDoc);
            this.groupBoxTransferencia.Controls.Add(this.comboTipoDoc);
            this.groupBoxTransferencia.Controls.Add(this.lblDocumento);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoPosterior);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoActual);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoPosteriorRO);
            this.groupBoxTransferencia.Controls.Add(this.lblSaldoActualRO);
            this.groupBoxTransferencia.Controls.Add(this.comboTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.lblTipoMoneda);
            this.groupBoxTransferencia.Controls.Add(this.comboCuentaOrigen);
            this.groupBoxTransferencia.Controls.Add(this.lblImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtImporte);
            this.groupBoxTransferencia.Controls.Add(this.lblCuentaOrigen);
            this.groupBoxTransferencia.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTransferencia.Name = "groupBoxTransferencia";
            this.groupBoxTransferencia.Size = new System.Drawing.Size(513, 171);
            this.groupBoxTransferencia.TabIndex = 5;
            this.groupBoxTransferencia.TabStop = false;
            this.groupBoxTransferencia.Text = "Retiro";
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
            this.comboTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoMoneda.Enabled = false;
            this.comboTipoMoneda.FormattingEnabled = true;
            this.comboTipoMoneda.Location = new System.Drawing.Point(87, 118);
            this.comboTipoMoneda.Name = "comboTipoMoneda";
            this.comboTipoMoneda.Size = new System.Drawing.Size(192, 21);
            this.comboTipoMoneda.TabIndex = 4;
            // 
            // lblTipoMoneda
            // 
            this.lblTipoMoneda.AutoSize = true;
            this.lblTipoMoneda.Location = new System.Drawing.Point(6, 118);
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
            this.comboCuentaOrigen.Size = new System.Drawing.Size(192, 21);
            this.comboCuentaOrigen.TabIndex = 1;
            this.comboCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.comboCuentaOrigen_SelectedIndexChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(6, 88);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 12;
            this.lblImporte.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(87, 85);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(192, 20);
            this.txtImporte.TabIndex = 3;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
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
            // btnRetirar
            // 
            this.btnRetirar.Location = new System.Drawing.Point(21, 205);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(117, 44);
            this.btnRetirar.TabIndex = 7;
            this.btnRetirar.Text = "Retirar";
            this.btnRetirar.UseVisualStyleBackColor = true;
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(354, 205);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 44);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(6, 59);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 21;
            this.lblDocumento.Text = "Documento";
            // 
            // comboTipoDoc
            // 
            this.comboTipoDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDoc.FormattingEnabled = true;
            this.comboTipoDoc.Location = new System.Drawing.Point(86, 51);
            this.comboTipoDoc.Name = "comboTipoDoc";
            this.comboTipoDoc.Size = new System.Drawing.Size(83, 21);
            this.comboTipoDoc.TabIndex = 22;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(175, 52);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(104, 20);
            this.txtNroDoc.TabIndex = 23;
            // 
            // Retiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 269);
            this.Controls.Add(this.btnRetirar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBoxTransferencia);
            this.Name = "Retiro";
            this.Text = "Retiro";
            this.Load += new System.EventHandler(this.Retiro_Load);
            this.groupBoxTransferencia.ResumeLayout(false);
            this.groupBoxTransferencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTransferencia;
        private System.Windows.Forms.Label lblSaldoPosterior;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.Label lblSaldoPosteriorRO;
        private System.Windows.Forms.Label lblSaldoActualRO;
        private System.Windows.Forms.ComboBox comboTipoMoneda;
        private System.Windows.Forms.Label lblTipoMoneda;
        private System.Windows.Forms.ComboBox comboCuentaOrigen;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblCuentaOrigen;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.ComboBox comboTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
    }
}