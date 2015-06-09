namespace PagoElectronico.Listados
{
    partial class ListadoEstadistico
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
            this.groupBoxConsulta = new System.Windows.Forms.GroupBox();
            this.rbPaisesCantMovimientos = new System.Windows.Forms.RadioButton();
            this.rbTotalFacturado = new System.Windows.Forms.RadioButton();
            this.rbClientesCantTransacciones = new System.Windows.Forms.RadioButton();
            this.rbClientesCantComisiones = new System.Windows.Forms.RadioButton();
            this.rbClientesCuentasInhabilitadas = new System.Windows.Forms.RadioButton();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.comboTrimestres = new System.Windows.Forms.ComboBox();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.groupBoxListado = new System.Windows.Forms.GroupBox();
            this.dataGridViewListado = new System.Windows.Forms.DataGridView();
            this.groupBoxConsulta.SuspendLayout();
            this.groupBoxListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxConsulta
            // 
            this.groupBoxConsulta.Controls.Add(this.rbPaisesCantMovimientos);
            this.groupBoxConsulta.Controls.Add(this.rbTotalFacturado);
            this.groupBoxConsulta.Controls.Add(this.rbClientesCantTransacciones);
            this.groupBoxConsulta.Controls.Add(this.rbClientesCantComisiones);
            this.groupBoxConsulta.Controls.Add(this.rbClientesCuentasInhabilitadas);
            this.groupBoxConsulta.Controls.Add(this.btnLimpiar);
            this.groupBoxConsulta.Controls.Add(this.comboTrimestres);
            this.groupBoxConsulta.Controls.Add(this.lblTrimestre);
            this.groupBoxConsulta.Controls.Add(this.btnBuscar);
            this.groupBoxConsulta.Controls.Add(this.txtCuenta);
            this.groupBoxConsulta.Controls.Add(this.lblAnio);
            this.groupBoxConsulta.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConsulta.Name = "groupBoxConsulta";
            this.groupBoxConsulta.Size = new System.Drawing.Size(515, 250);
            this.groupBoxConsulta.TabIndex = 5;
            this.groupBoxConsulta.TabStop = false;
            this.groupBoxConsulta.Text = "Consulta";
            // 
            // rbPaisesCantMovimientos
            // 
            this.rbPaisesCantMovimientos.AutoSize = true;
            this.rbPaisesCantMovimientos.Location = new System.Drawing.Point(6, 125);
            this.rbPaisesCantMovimientos.Name = "rbPaisesCantMovimientos";
            this.rbPaisesCantMovimientos.Size = new System.Drawing.Size(366, 17);
            this.rbPaisesCantMovimientos.TabIndex = 18;
            this.rbPaisesCantMovimientos.TabStop = true;
            this.rbPaisesCantMovimientos.Text = "Paises con mayor cantidad de movimientos tanto ingresos como egresos";
            this.rbPaisesCantMovimientos.UseVisualStyleBackColor = true;
            // 
            // rbTotalFacturado
            // 
            this.rbTotalFacturado.AutoSize = true;
            this.rbTotalFacturado.Location = new System.Drawing.Point(6, 148);
            this.rbTotalFacturado.Name = "rbTotalFacturado";
            this.rbTotalFacturado.Size = new System.Drawing.Size(259, 17);
            this.rbTotalFacturado.TabIndex = 17;
            this.rbTotalFacturado.TabStop = true;
            this.rbTotalFacturado.Text = "Total facturado para los distintos tipos de cuentas";
            this.rbTotalFacturado.UseVisualStyleBackColor = true;
            // 
            // rbClientesCantTransacciones
            // 
            this.rbClientesCantTransacciones.AutoSize = true;
            this.rbClientesCantTransacciones.Location = new System.Drawing.Point(6, 102);
            this.rbClientesCantTransacciones.Name = "rbClientesCantTransacciones";
            this.rbClientesCantTransacciones.Size = new System.Drawing.Size(397, 17);
            this.rbClientesCantTransacciones.TabIndex = 16;
            this.rbClientesCantTransacciones.TabStop = true;
            this.rbClientesCantTransacciones.Text = "Clientes con mayor cantidad de transacciones realizadas entre cuentas propias";
            this.rbClientesCantTransacciones.UseVisualStyleBackColor = true;
            // 
            // rbClientesCantComisiones
            // 
            this.rbClientesCantComisiones.AutoSize = true;
            this.rbClientesCantComisiones.Location = new System.Drawing.Point(6, 82);
            this.rbClientesCantComisiones.Name = "rbClientesCantComisiones";
            this.rbClientesCantComisiones.Size = new System.Drawing.Size(385, 17);
            this.rbClientesCantComisiones.TabIndex = 15;
            this.rbClientesCantComisiones.TabStop = true;
            this.rbClientesCantComisiones.Text = "Clientes con mayor cantidad de comisiones facturadas en todas sus cuentas";
            this.rbClientesCantComisiones.UseVisualStyleBackColor = true;
            // 
            // rbClientesCuentasInhabilitadas
            // 
            this.rbClientesCuentasInhabilitadas.AutoSize = true;
            this.rbClientesCuentasInhabilitadas.Checked = true;
            this.rbClientesCuentasInhabilitadas.Location = new System.Drawing.Point(6, 61);
            this.rbClientesCuentasInhabilitadas.Name = "rbClientesCuentasInhabilitadas";
            this.rbClientesCuentasInhabilitadas.Size = new System.Drawing.Size(473, 17);
            this.rbClientesCuentasInhabilitadas.TabIndex = 14;
            this.rbClientesCuentasInhabilitadas.TabStop = true;
            this.rbClientesCuentasInhabilitadas.Text = "Clientes que alguna de sus cuentas fueron inhabilitadas por no pagar los costos d" +
                "e transaccion";
            this.rbClientesCuentasInhabilitadas.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(407, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // comboTrimestres
            // 
            this.comboTrimestres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestres.FormattingEnabled = true;
            this.comboTrimestres.Location = new System.Drawing.Point(240, 20);
            this.comboTrimestres.Name = "comboTrimestres";
            this.comboTrimestres.Size = new System.Drawing.Size(91, 21);
            this.comboTrimestres.TabIndex = 11;
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Location = new System.Drawing.Point(184, 25);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(50, 13);
            this.lblTrimestre.TabIndex = 10;
            this.lblTrimestre.Text = "Trimestre";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(166, 185);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(165, 59);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(70, 21);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(91, 20);
            this.txtCuenta.TabIndex = 3;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(38, 25);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Año";
            // 
            // groupBoxListado
            // 
            this.groupBoxListado.Controls.Add(this.dataGridViewListado);
            this.groupBoxListado.Location = new System.Drawing.Point(9, 268);
            this.groupBoxListado.Name = "groupBoxListado";
            this.groupBoxListado.Size = new System.Drawing.Size(521, 296);
            this.groupBoxListado.TabIndex = 4;
            this.groupBoxListado.TabStop = false;
            this.groupBoxListado.Text = "Listado";
            // 
            // dataGridViewListado
            // 
            this.dataGridViewListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewListado.Name = "dataGridViewListado";
            this.dataGridViewListado.Size = new System.Drawing.Size(509, 271);
            this.dataGridViewListado.TabIndex = 3;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 576);
            this.Controls.Add(this.groupBoxConsulta);
            this.Controls.Add(this.groupBoxListado);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.groupBoxConsulta.ResumeLayout(false);
            this.groupBoxConsulta.PerformLayout();
            this.groupBoxListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConsulta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.GroupBox groupBoxListado;
        private System.Windows.Forms.DataGridView dataGridViewListado;
        private System.Windows.Forms.ComboBox comboTrimestres;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.RadioButton rbPaisesCantMovimientos;
        private System.Windows.Forms.RadioButton rbTotalFacturado;
        private System.Windows.Forms.RadioButton rbClientesCantTransacciones;
        private System.Windows.Forms.RadioButton rbClientesCantComisiones;
        private System.Windows.Forms.RadioButton rbClientesCuentasInhabilitadas;

    }
}