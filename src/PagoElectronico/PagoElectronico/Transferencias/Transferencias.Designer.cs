namespace PagoElectronico.Transferencias
{
    partial class Transferencias
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.txtCuentaDestino = new System.Windows.Forms.TextBox();
            this.lblCuentaOrigen = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.groupBoxTransferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTransferencia
            // 
            this.groupBoxTransferencia.Controls.Add(this.comboCuentaOrigen);
            this.groupBoxTransferencia.Controls.Add(this.label1);
            this.groupBoxTransferencia.Controls.Add(this.lblImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtImporte);
            this.groupBoxTransferencia.Controls.Add(this.txtCuentaDestino);
            this.groupBoxTransferencia.Controls.Add(this.lblCuentaOrigen);
            this.groupBoxTransferencia.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTransferencia.Name = "groupBoxTransferencia";
            this.groupBoxTransferencia.Size = new System.Drawing.Size(466, 108);
            this.groupBoxTransferencia.TabIndex = 4;
            this.groupBoxTransferencia.TabStop = false;
            this.groupBoxTransferencia.Text = "Transferencia";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(354, 153);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(124, 44);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(21, 153);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(117, 44);
            this.btnTransferir.TabIndex = 7;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
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
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(87, 76);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(120, 20);
            this.txtImporte.TabIndex = 11;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cuenta Destino";
            // 
            // comboCuentaOrigen
            // 
            this.comboCuentaOrigen.FormattingEnabled = true;
            this.comboCuentaOrigen.Location = new System.Drawing.Point(87, 19);
            this.comboCuentaOrigen.Name = "comboCuentaOrigen";
            this.comboCuentaOrigen.Size = new System.Drawing.Size(121, 21);
            this.comboCuentaOrigen.TabIndex = 14;
            // 
            // Transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 222);
            this.Controls.Add(this.groupBoxTransferencia);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "Transferencias";
            this.Text = "Transferencias entre cuentas";
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
    }
}