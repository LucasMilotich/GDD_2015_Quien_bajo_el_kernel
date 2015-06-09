namespace PagoElectronico.Consulta_Saldos
{
    partial class ConsultaSaldos
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
            this.groupBoxListado = new System.Windows.Forms.GroupBox();
            this.DataGridViewListado = new System.Windows.Forms.DataGridView();
            this.groupBoxConsulta = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblSaldo2 = new System.Windows.Forms.Label();
            this.lblSaldo1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rbTransferencias = new System.Windows.Forms.RadioButton();
            this.rbRetiros = new System.Windows.Forms.RadioButton();
            this.rbDepositos = new System.Windows.Forms.RadioButton();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.groupBoxListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewListado)).BeginInit();
            this.groupBoxConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxListado
            // 
            this.groupBoxListado.Controls.Add(this.DataGridViewListado);
            this.groupBoxListado.Location = new System.Drawing.Point(15, 136);
            this.groupBoxListado.Name = "groupBoxListado";
            this.groupBoxListado.Size = new System.Drawing.Size(521, 284);
            this.groupBoxListado.TabIndex = 2;
            this.groupBoxListado.TabStop = false;
            this.groupBoxListado.Text = "Listado";
            // 
            // DataGridViewListado
            // 
            this.DataGridViewListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewListado.Location = new System.Drawing.Point(6, 19);
            this.DataGridViewListado.Name = "DataGridViewListado";
            this.DataGridViewListado.Size = new System.Drawing.Size(509, 259);
            this.DataGridViewListado.TabIndex = 3;
            // 
            // groupBoxConsulta
            // 
            this.groupBoxConsulta.Controls.Add(this.btnLimpiar);
            this.groupBoxConsulta.Controls.Add(this.lblSaldo2);
            this.groupBoxConsulta.Controls.Add(this.lblSaldo1);
            this.groupBoxConsulta.Controls.Add(this.btnBuscar);
            this.groupBoxConsulta.Controls.Add(this.rbTransferencias);
            this.groupBoxConsulta.Controls.Add(this.rbRetiros);
            this.groupBoxConsulta.Controls.Add(this.rbDepositos);
            this.groupBoxConsulta.Controls.Add(this.txtCuenta);
            this.groupBoxConsulta.Controls.Add(this.lblCuenta);
            this.groupBoxConsulta.Location = new System.Drawing.Point(15, 12);
            this.groupBoxConsulta.Name = "groupBoxConsulta";
            this.groupBoxConsulta.Size = new System.Drawing.Size(515, 97);
            this.groupBoxConsulta.TabIndex = 3;
            this.groupBoxConsulta.TabStop = false;
            this.groupBoxConsulta.Text = "Consulta";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(284, 18);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblSaldo2
            // 
            this.lblSaldo2.AutoSize = true;
            this.lblSaldo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo2.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaldo2.Location = new System.Drawing.Point(441, 20);
            this.lblSaldo2.Name = "lblSaldo2";
            this.lblSaldo2.Size = new System.Drawing.Size(64, 18);
            this.lblSaldo2.TabIndex = 9;
            this.lblSaldo2.Text = "elSaldo";
            this.lblSaldo2.Visible = false;
            // 
            // lblSaldo1
            // 
            this.lblSaldo1.AutoSize = true;
            this.lblSaldo1.Location = new System.Drawing.Point(401, 24);
            this.lblSaldo1.Name = "lblSaldo1";
            this.lblSaldo1.Size = new System.Drawing.Size(34, 13);
            this.lblSaldo1.TabIndex = 8;
            this.lblSaldo1.Text = "Saldo";
            this.lblSaldo1.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(193, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rbTransferencias
            // 
            this.rbTransferencias.AutoSize = true;
            this.rbTransferencias.Location = new System.Drawing.Point(236, 61);
            this.rbTransferencias.Name = "rbTransferencias";
            this.rbTransferencias.Size = new System.Drawing.Size(143, 17);
            this.rbTransferencias.TabIndex = 6;
            this.rbTransferencias.Text = "Ultimas 10 transferencias";
            this.rbTransferencias.UseVisualStyleBackColor = true;
            // 
            // rbRetiros
            // 
            this.rbRetiros.AutoSize = true;
            this.rbRetiros.Location = new System.Drawing.Point(131, 61);
            this.rbRetiros.Name = "rbRetiros";
            this.rbRetiros.Size = new System.Drawing.Size(99, 17);
            this.rbRetiros.TabIndex = 5;
            this.rbRetiros.Text = "Ultimos 5 retiros";
            this.rbRetiros.UseVisualStyleBackColor = true;
            // 
            // rbDepositos
            // 
            this.rbDepositos.AutoSize = true;
            this.rbDepositos.Checked = true;
            this.rbDepositos.Location = new System.Drawing.Point(9, 61);
            this.rbDepositos.Name = "rbDepositos";
            this.rbDepositos.Size = new System.Drawing.Size(116, 17);
            this.rbDepositos.TabIndex = 4;
            this.rbDepositos.TabStop = true;
            this.rbDepositos.Text = "Ultimos 5 depositos";
            this.rbDepositos.UseVisualStyleBackColor = true;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(53, 21);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(120, 20);
            this.txtCuenta.TabIndex = 3;
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
            // ConsultaSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 432);
            this.Controls.Add(this.groupBoxConsulta);
            this.Controls.Add(this.groupBoxListado);
            this.Name = "ConsultaSaldos";
            this.Text = "Consulta de saldos";
            this.groupBoxListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewListado)).EndInit();
            this.groupBoxConsulta.ResumeLayout(false);
            this.groupBoxConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxListado;
        private System.Windows.Forms.DataGridView DataGridViewListado;
        private System.Windows.Forms.GroupBox groupBoxConsulta;
        private System.Windows.Forms.Label lblSaldo2;
        private System.Windows.Forms.Label lblSaldo1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rbTransferencias;
        private System.Windows.Forms.RadioButton rbRetiros;
        private System.Windows.Forms.RadioButton rbDepositos;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Button btnLimpiar;

    }
}